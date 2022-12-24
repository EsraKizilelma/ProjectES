using Microsoft.AspNetCore.Mvc;

namespace ProjectES.Component
{
    public class MakaleListele2: ViewComponent
    {
        public IViewComponentResult Invoke(string str)
        {
            char ch = ';';
            List<string> makaleler = str.Split(ch).ToList();
           
            //char ch = ';';
            //str.Split(ch);
            //List<string> makaleler = new List<string>() { "m1", "m2","m3"};
            return View(makaleler);
        }

        //public IViewComponentResult Invoke()
        //{
        //    List<string> makaleler = new List<string>() { "m1", "m2", "m3" };
        //    return View(makaleler);
        //}
    }
}
