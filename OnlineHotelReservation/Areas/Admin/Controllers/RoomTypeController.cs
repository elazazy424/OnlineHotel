using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Entity;
using OnlineHotelReservation.ViewModels;

namespace OnlineHotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomTypeController : Controller
    {
        //inject IRoomTypeRepository
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;
        public RoomTypeController(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var roomTypes = _roomTypeRepository.GetAllRoomTypes(1, 10);
            var roomTypeViewModels = _mapper.Map<List<RoomTypeViewModel>>(roomTypes.Data);
            return View(roomTypeViewModels);
        }
        #region create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomTypeViewModel roomTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomType roomType = new RoomType
                {
                    Name = roomTypeViewModel.Name
                };
                await _roomTypeRepository.AddRoomType(roomType);
                return RedirectToAction("Index");
            }
            return View(roomTypeViewModel);
        }
        #endregion
        #region edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var roomType = _roomTypeRepository.GetRoomTypeById(id);
          //use automapper to map the entity to viewmodel
            RoomTypeViewModel roomTypeViewModel = _mapper.Map<RoomTypeViewModel>(roomType);
            return View(roomTypeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoomTypeViewModel roomTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomType roomType = new RoomType
                {
                    Id = roomTypeViewModel.Id,
                    Name = roomTypeViewModel.Name
                };
                await _roomTypeRepository.UpdateRoomType(roomType);
                return RedirectToAction("Index");
            }
            return View(roomTypeViewModel);
        }
        #endregion
        #region delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var roomType = _roomTypeRepository.GetRoomTypeById(id);
            RoomTypeViewModel roomTypeViewModel = new RoomTypeViewModel
            {
                Id = roomType.Id,
                Name = roomType.Name
            };
            return View(roomTypeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RoomTypeViewModel roomTypeViewModel)
        {
            await _roomTypeRepository.DeleteRoomType(roomTypeViewModel.Id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
