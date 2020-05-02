using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BelexpLogistikWebApp.Models;
using BelexpLogistikWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.EntityFrameworkCore;

namespace BelexpLogistikWebApp.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;
        BelexpLogistikContext db;
        public UsersController(UserManager<User> userManager, BelexpLogistikContext context)
        {
            db = context;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.UserName};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, UserName=user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.UserName = model.UserName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult CreateDriver()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult CreateDriver(Drivers driver)
        {
            db.Drivers.Add(driver);
            db.SaveChanges();
            return RedirectToAction("Home/Index");
        }
        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public ActionResult DeleteDriver(int id)
        {
            Drivers driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }
        public IActionResult DriverList()
        {
            var drivers = db.Drivers;
            return View(drivers);
        }
        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult EditDriver(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Drivers driver = db.Drivers.Find(id);
            if (driver != null)
            {
                return View(driver);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditDriver(Drivers driver)
        {
            db.Entry(driver).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Home/Index");
        }
        [HttpPost, ActionName("DeleteDriver")]
        [Authorize(Roles = "Администратор")]
        public ActionResult DeleteConfirmed(int id)
        {
            Drivers driver = db.Drivers.Find(id);
            if(driver == null)
            {
                return HttpNotFound();
            }
            db.Drivers.Remove(driver);
            db.SaveChanges();
            return RedirectToAction("Home/Index");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}