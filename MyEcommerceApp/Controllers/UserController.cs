using Microsoft.AspNetCore.Mvc;
using MyEcommerceApp.Models;
using System.Linq;

public class UserController : Controller
{
    private readonly EcommerceDbContext _context;

    public UserController(EcommerceDbContext context)
    {
        _context = context;
    }

    // Đăng ký
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            // Lưu thông tin người dùng
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View(user);
    }

    // Đăng nhập
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null && user.PasswordHash == password)
        {
            // Đăng nhập thành công
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}
