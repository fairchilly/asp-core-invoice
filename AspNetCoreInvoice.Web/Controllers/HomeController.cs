using System;
using System.Threading.Tasks;
using AspNetCoreInvoice.Web.Models;
using AspNetCoreInvoice.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace AspNetCoreInvoice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPdfService<Invoice> _pdfService;
        private readonly IGeneratePdf _generatePdf;

        public HomeController(IPdfService<Invoice> pdfService, IGeneratePdf generatePdf)
        {
            _pdfService = pdfService;
            _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Demo()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateInvoice(Invoice invoice)
        {
            return await _generatePdf.GetPdf("Views/Templates/InvoicePdf.cshtml", invoice);
        }
    }
}