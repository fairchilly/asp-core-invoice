using System.IO;
using System.Threading.Tasks;
using AspNetCoreInvoice.Web.Models;
using Wkhtmltopdf.NetCore;

namespace AspNetCoreInvoice.Web.Services
{
    public class PdfService : IPdfService<Invoice>
    {
        private readonly IGeneratePdf _generatePdf;

        public PdfService(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        public async Task<MemoryStream> GetPdfStreamAsync(Invoice invoice)
        {
            var pdf = await _generatePdf.GetByteArray("Views/Templates/InvoicePdf.cshtml", invoice);
            var pdfStream = new System.IO.MemoryStream();
            pdfStream.Write(pdf, 0, pdf.Length);
            pdfStream.Position = 0;

            return pdfStream;
        }
    }
}