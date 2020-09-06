using System.IO;
using System.Threading.Tasks;
using AspNetCoreInvoice.Web.Models;

namespace AspNetCoreInvoice.Web.Services
{
    public interface IPdfService<T> where T : class
    {
        public Task<MemoryStream> GetPdfStreamAsync(T entity);
    }
}