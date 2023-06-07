using Microsoft.AspNetCore.Mvc;

namespace TabsAndPersonalPages.Controllers;

[Route("terms-of-use")]
public class TermsOfUseController : Controller
{
	public IActionResult TermsOfUse()
	{
		ViewBag.Message = "Add your Terms of Use statement here...";
		return View();
	}
}