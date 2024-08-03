using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Entity;
using OnlineHotelReservation.ViewModels;

namespace OnlineHotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RoomsController(IRoomRepository roomRepository, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var rooms = _roomRepository.GetAll(1, 10);
            var roomViewModels = _mapper.Map<List<RoomViewModel>>(rooms.Data);
            return View(roomViewModels);
        }

        #region create
        public IActionResult Create(RoomViewModel vm)
        {
            string fileName = null;
            if (vm.RoomPictureFile != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string file = Guid.NewGuid().ToString() + "_" + vm.RoomPictureFile.FileName;
                string filePath = Path.Combine(uploadsFolder, file);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    vm.RoomPictureFile.CopyTo(ms);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomViewModel);
                _roomRepository.AddRoom(room);
                return RedirectToAction("Index");
            }
            return View(roomViewModel);
        }
        #endregion

        #region edit
        public IActionResult Edit(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            var roomViewModel = _mapper.Map<RoomViewModel>(room);
            return View(roomViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomViewModel);
                _roomRepository.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            return View(roomViewModel);
        }
        #endregion

        #region delete
        public IActionResult Delete(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            var roomViewModel = _mapper.Map<RoomViewModel>(room);
            return View(roomViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RoomViewModel roomViewModel)
        {
            var room = _mapper.Map<Room>(roomViewModel);
            _roomRepository.DeleteRoom(room.Id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
