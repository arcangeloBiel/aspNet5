using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_curso.HiperMidia.Filters {
    public class HiperMediaFilter : ResultFilterAttribute {

        private readonly HiperMediaFiltersOptions _hiperMediaFiltersOptions;

        public HiperMediaFilter(HiperMediaFiltersOptions hiperMediaFiltersOptions) {
            _hiperMediaFiltersOptions = hiperMediaFiltersOptions;

        }

        public override void OnResultExecuting(ResultExecutingContext context) {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context) {
            if(context.Result is OkObjectResult okobjectResult) {
                var enricher = _hiperMediaFiltersOptions.contentResponseList.FirstOrDefault(x => x.CanEnrich(context));

                if (enricher != null) Task.FromResult(enricher.Enrich(context));
            }
        }
    }
}
