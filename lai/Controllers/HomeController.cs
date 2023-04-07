using lai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(uint soTienGui, double laiSuatGui, uint kyHanGui)
        {
            try
            {
                uint tien_lai = (uint)(soTienGui * laiSuatGui * kyHanGui / 1200);
                uint tong_tien = (uint)(soTienGui + tien_lai);
                ViewData["So_tien_gui"] = soTienGui;
                ViewData["Lai_suat_gui"] = laiSuatGui;
                ViewData["Ky_han_gui"] = kyHanGui;
                ViewData["Tien_lai"] = tien_lai;
                ViewData["Tong_tien"] = tong_tien;
            }
            catch (FormatException)
            {
                ViewData["ThongBao"] = "Bạn nhập sai dữ liệu";
            }
            catch (Exception ex)
            {
                ViewData["ThongBao"] = $"Lỗi: {ex.Message}\tThông tin lỗi: {ex.ToString}";
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}