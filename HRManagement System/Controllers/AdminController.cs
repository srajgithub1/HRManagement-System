using HRManagement_System.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static System.Net.WebRequestMethods;

namespace HRManagement_System.Controllers
{
    
    public class AdminController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
            
        }

        [HttpGet]
        public IActionResult Profile()
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(userid==0)
            {
                return RedirectToAction("Login");
            }
            
           return View(_db.admins.Find(userid));
            

        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(Admin ad)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ad);
                await _db.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(ad);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login log)
        {
            if (ModelState.IsValid)
            {
                var user = _db.admins.Where(x => x.Email == log.Email && x.Password == log.Password).FirstOrDefault();
                if (user == null)
                {
                    ViewBag.Message = "Invalid Credential";
                    return View(log);
                }
                else
                {
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("UserFullName",user.Name??""),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {

                    });



                    return RedirectToAction("Index");
                }
            }
            return View(log);

        }
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return RedirectToAction("Login");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ad = await _db.admins.FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }
        

    }
}
