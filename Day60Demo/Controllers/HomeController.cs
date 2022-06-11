using Day60Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Day60Demo.Models.Settings;
using Day60Demo.ViewModel;
using Microsoft.Extensions.Options;

namespace Day60Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CompanyDetails _companyDetails;
        private readonly FestivalTheme _festivalTheme;

        public HomeController(
            ILogger<HomeController> logger,
            IOptions<CompanyDetails> companyDetailsOptions,
            IOptions<FestivalTheme> festivalThemeOptions)
        {
            _logger = logger;
            _companyDetails = companyDetailsOptions.Value;
            _festivalTheme = festivalThemeOptions.Value;
        }

        public IActionResult Index()
        {
            var generalPageViewModel = new GeneralPageViewModel
            {
                CompanyDetails = _companyDetails,
                FestivalTheme = _festivalTheme
            };

            return View(generalPageViewModel);
        }

        public IActionResult Privacy()
        {
            var generalPageViewModel = new GeneralPageViewModel
            {
                CompanyDetails = _companyDetails,
                FestivalTheme = _festivalTheme
            };

            return View(generalPageViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}