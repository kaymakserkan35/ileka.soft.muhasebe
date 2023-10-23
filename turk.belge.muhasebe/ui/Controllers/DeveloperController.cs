using Microsoft.AspNetCore.Mvc;
using ui.Models.UserModel;

using Microsoft.AspNetCore.Authorization;
using service.Dtos.UserDtos;
using service.services.concretes.developerService;
using service.services.abstractions;
using service.Mapper;
using ui.Models.DeveloperModel;
using service.Dtos.FirmDto;
using ui.Models.Routes;
using ui.Mapper;
using System.Diagnostics;
using ui.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ui.Controllers
{
    [Controller]
    public class DeveloperController : Controller
    {
        IDeveloperService developerService;
        IDtoModelMapper mapper;

        public DeveloperController(IDeveloperService developerService, IDtoModelMapper mapper)
        {
            this.developerService = developerService;
            this.mapper = mapper;
        }


        #region User

        public async Task<IActionResult> listuser()
        {
            var res = await developerService.ListUser();
            if (!res.IsSucceeded) { return RedirectToAction(""); }
            var model = mapper.Map<UserListingModel>(res.Dto);
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> adduser()
        {

            var res = await developerService.AddUser();
            if (!res.IsSucceeded) { return RedirectToAction(""); }
            var model = mapper.Map<UserEditingModel>(res.Dto);
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> adduser(UserEditingModel model)
        {
            var dto = mapper.Map<UserEditingDto>(model);
            var res = await developerService.AddUser(dto);
            if (!res.IsSucceeded)
            {
                string errorMessage = string.Join("\n", res.ErrorMessages);
                ModelState.AddModelError("Errors", errorMessage);
                ViewData["Errors"] = errorMessage;
                var resr = await developerService.AddUser();
                return View(mapper.Map<UserEditingModel>(resr.Dto));
            }
            return RedirectToAction(Routes.listUser);
        }

        public async Task<IActionResult> deleteuser(int id)
        {
            var res = await developerService.deleteUser(id);
            if (!res.IsSucceeded) return RedirectToAction("");
            return RedirectToAction(Routes.listUser);
        }


        public async Task<IActionResult> updateuser(int id)
        {
            var res = await developerService.UpdateUser(id);
            var dto = res.Dto;
            var model = mapper.Map<UserEditingModel>(dto);
            if (res.IsSucceeded) return View(model);
            return RedirectToAction(Routes.listUser);
        }
        [HttpPost]
        public async Task<IActionResult> updateuser(UserEditingModel model)
        {
            if (model.Id == 0) throw new Exception("");
            var res = await developerService.UpdateUser(mapper.Map<UserEditingDto>(model));
            if (res.IsSucceeded) { return RedirectToAction(Routes.listUser); }
            return RedirectToAction("");

        }
        #endregion



        /// <summary>
        /// bizim mğşterilerimiz, bunlar. contacts ile karıştırma
        /// </summary>
        #region customers


        #endregion

        #region Firm

        public async Task<IActionResult> addFirm()
        {
            var res = await developerService.AddFirm();
            if (res.IsSucceeded) return View(mapper.Map<FirmAddingModel>(res.Dto));
            return RedirectToAction("");
        }
        [HttpPost]
        public async Task<IActionResult> addFirm(FirmEditingModel model)
        {
            var dto = mapper.Map<FirmEditingDto>(model);
            var res = await developerService.AddFirm();
            if (res.IsSucceeded) return RedirectToAction(Routes.listFirm);
            return RedirectToAction("");
        }
        public  IActionResult detailFirm(int id)
        {
            return  View(new FirmAddingModel());
        }
        [HttpPost]
        public async Task<IActionResult> Firm(FirmAddingModel model)
        {
            return View();
        }


        public async Task<IActionResult> listFirm()
        {
            var res = await developerService.ListFirm();
            if (res.IsSucceeded)
            {

                return View(mapper.Map<FirmListingModel>(res.Dto));
            }

            return RedirectToAction("");
        }

        public async Task<IActionResult> updateFirm(int id)
        {
            var res = await developerService.UpdateFirm(id);
            if (res.IsSucceeded)
            {
                var m = mapper.Map<FirmEditingModel>(res.Dto);
                return View(m);
            }
            return View(new FirmEditingModel());
        }

        [HttpPost]
        public async Task<IActionResult> updateFirm(FirmEditingModel model)
        {
            var dto = mapper.Map<FirmEditingDto>(model);

            var res = await developerService.UpdateFirm(dto);
            if (res.IsSucceeded) return RedirectToAction(Routes.listFirm);
            return View(new FirmEditingModel());
        }
        public async Task<IActionResult> deleteFirm(int id)
        {
            var res = await developerService.deleteFirm(id);
            if (res.IsSucceeded) { return RedirectToAction(Routes.listFirm); }
            return RedirectToActionPermanent("Error", "Auth");
        }



        #endregion


        #region District_City_Country

        public async Task<IActionResult> listDistrict()
        {
            var res = await developerService.ListDistrict();
            if (res.IsSucceeded)
            {
                var dto = res.Dto;
                var m = mapper.Map<DistrictModel>(dto);
                return View(m);
            }
            return Redirect("");
        }

        public async Task<IActionResult> deleteDistrict(int id)
        {
            var res = await developerService.deleteDistrict(id);
            if (res.IsSucceeded) { return RedirectToAction(Routes.listDistrict); }
            if (res.ErrorMessages != null) return View("Error", new ErrorModel(res.ErrorMessages));
            return View("Error",null);

        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorModel? model)
        {
            if (model != null) return View(model);
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
