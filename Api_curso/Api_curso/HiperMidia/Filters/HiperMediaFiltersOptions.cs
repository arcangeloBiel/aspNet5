using Api_curso.HiperMidia.Abstract;
using System.Collections.Generic;

namespace Api_curso.HiperMidia.Filters {
    public class HiperMediaFiltersOptions {

        public List<IResponseEnricher> contentResponseList { get; set; } = new List<IResponseEnricher>();
    }
}
