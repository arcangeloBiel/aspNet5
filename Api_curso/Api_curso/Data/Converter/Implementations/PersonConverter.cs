using Api_curso.Data.Converter.Contract;
using Api_curso.Data.VO;
using Api_curso.Model;
using System.Collections.Generic;
using System.Linq;

namespace Api_curso.Data.Converter.Implementations {
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO> {

        public Person Parse(PersonVO origem) {
            if (origem == null) return null;
            return new Person {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender,
            };

        }

       
        public PersonVO Parse(Person origem) {
            if (origem == null) return null;
            return new PersonVO {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender,
            };
        }
        public List<Person> Parse(List<PersonVO> origem) {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origem) {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

    }
}
