using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Dataa;
using Microsoft.AspNetCore.Http;
using Onion_Architecture.Models;

namespace Onion_Architecture.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            _userService = userService;
            _userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            _userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = _userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                model.Add(user);
            });


            return View(model);
        }



    }
}
