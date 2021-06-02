using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Api_curso.HiperMidia.Abstract {
    public interface IResponseEnricher {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
