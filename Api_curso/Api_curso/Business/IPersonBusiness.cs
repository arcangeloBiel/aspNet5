using Api_curso.Data.VO;
using System.Collections.Generic;

namespace Api_curso.Business {
    public interface IPersonBusiness {

        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);

        void Delete(long id);

    }
}
