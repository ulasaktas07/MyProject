using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateNewUserDto model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var appUser = new AppUser()
			{
				Name = model.Name,
				Surname = model.Surname,
				UserName = model.UserName,
				Email = model.Email
			};
			var result=await _userManager.CreateAsync(appUser, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
