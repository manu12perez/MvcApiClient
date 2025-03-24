using Microsoft.AspNetCore.Mvc;
using MvcApiClient.Models;
using MvcApiClient.Services;

namespace MvcApiClient.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospitales service;

        public HospitalesController(ServiceHospitales service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales = await this.service.GetHospitalesAsync();
            return View(hospitales);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }
    }
}
