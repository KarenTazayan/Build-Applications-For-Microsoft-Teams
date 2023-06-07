using Microsoft.AspNetCore.Mvc;
using TabsAndPersonalPages.Models;

namespace TabsAndPersonalPages.Controllers;

[Route("personal-tab")]
public class PersonalTabController : Controller
{
	public IActionResult PersonalTab()
	{
		var color = new PersonalTab("PersonalTab says: 'Hello ");
		ViewBag.Gray = ($"{color.GetColor()} Gray!'");
		ViewBag.Red = ($"{color.GetColor()} Red!'");
            
		return View();
	}
}