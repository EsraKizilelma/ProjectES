using Microsoft.AspNetCore.Mvc;

namespace ProjectES.Component
{
    public class MakaleListele:ViewComponent
    {
      public IViewComponentResult Invoke()
      {
            return View();
      }

    }
}
