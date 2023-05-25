using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
	public class _Statistics : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			using var c = new Context();
			ViewBag.destinations = c.Destinations.Count();
			ViewBag.guides = c.Guides.Count();
			ViewBag.musteriler = "285";
			return View();
		}
	}
}
