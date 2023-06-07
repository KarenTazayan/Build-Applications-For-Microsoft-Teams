using Microsoft.AspNetCore.Mvc;

namespace TabsAndPersonalPages.Controllers;

[Route("privacy")]
public class PrivacyController : Controller
{
	public IActionResult Privacy()
	{
		ViewBag.Message = "Add your privacy statement here...";
		return View();
	}
}