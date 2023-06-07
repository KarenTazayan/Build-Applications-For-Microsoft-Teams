using Microsoft.AspNetCore.Mvc;

namespace TabsAndPersonalPages.Controllers;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		ViewBag.Message = "Hello from Tabs And Personal Pages!";
		return View();
	}
}