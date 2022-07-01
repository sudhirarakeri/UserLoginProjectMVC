using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserLoginProjectMVC.Models;

namespace UserLoginProjectMVC.Controllers
{
    public class UserController : Controller
    {
        UserDal db=new UserDal();

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
            User u = new User();
            u.Name = form["Name"];
            u.Email=form["Email"];
            u.Password=form["Password"];
            u.RoleId = 2;
            int res=db.Save(u);
            if (res == 1)
                return RedirectToAction("SignIn");
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            User u=new User();
            u.Name = form["username"];
            u.Password = form["password"];
            int res = db.Search(u.Name, u.Password);
            if (res == 1)
                return RedirectToAction("Index", "Product");
            else
            {
                ViewBag.Message = "Invalid Username or password";
                return View();
            }
              
        }

    }
}
