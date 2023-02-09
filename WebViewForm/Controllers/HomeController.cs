using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewForm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Redirect("/index.html");
        public IActionResult Page1() => Redirect("/page1.html");
        public IActionResult Data() => new JsonResult(new
        {
            msg = "這是page 2"
        });
    }
}
