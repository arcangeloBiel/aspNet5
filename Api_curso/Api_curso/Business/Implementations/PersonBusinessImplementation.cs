using Api_curso.Data.Converter.Implementations;
using Api_curso.Data.VO;
using Api_curso.Model;
using Api_curso.Repository;
using System.Collections.Generic;

namespace Api_curso.Business.Implementations {
    public class PersonBusinessImplementation : IPersonBusiness {
        //inject dependency
        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository) {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person) {
            var personEntity = _converter.Parse(person);
            personEntity =  _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public List<PersonVO> FindAll() {
            return _converter.Parse(_repository.FindAll());
        }


        public PersonVO FindById(long id) {
            return _converter.Parse(_repository.FindById(id));
        }

        public void Delete(long id) {
            _repository.Delete(id);
        }

      
        public PersonVO Update(PersonVO person) {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

    }
}
