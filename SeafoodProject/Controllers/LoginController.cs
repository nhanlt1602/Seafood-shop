using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeafoodProject.Models.group.user;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SeafoodProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckLoginController(string userName, string password)
        {
            UserDAO userDAO = new UserDAO();
            UserDTO userDTO = userDAO.CheckLogin(userName, password);
            if (userDTO != null)
            {
                if (userDTO.Role == 1)
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userDTO));
                    ViewBag.Session = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("SessionUser"));

                    return View("Result");
                }
                else
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userDTO));
                    ViewBag.Message = "User";
                    return View("Result");
                }
            }
            else
            {
                ViewBag.Message = "Not Login";
                return View("Result");
            }
        }
    }
}
