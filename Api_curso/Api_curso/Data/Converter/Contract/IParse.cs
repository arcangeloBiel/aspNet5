using System.Collections.Generic;

namespace Api_curso.Data.Converter.Contract {
    public  interface IParse<O, D> {

        D Parse(O origem);
       List<D> Parse(List<O> origem);
    }
}
