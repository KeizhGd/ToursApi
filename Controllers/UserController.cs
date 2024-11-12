using Microsoft.AspNetCore.Mvc;

namespace slothlandapi.Controllers
{

	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
