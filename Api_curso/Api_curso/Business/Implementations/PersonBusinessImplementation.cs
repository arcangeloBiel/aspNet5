using Api_curso.Model;
using Api_curso.Repository;
using System.Collections.Generic;

namespace Api_curso.Business.Implementations {
    public class PersonBusinessImplementation : IPersonBusiness {
        //inject dependency
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository) {
            _repository = repository;
        }

        public Person Create(Person person) {
            return _repository.Create(person);
        }

        public List<Person> FindAll() {
            return _repository.FindAll();
        }


        public Person FindById(long id) {
            return _repository.FindById(id);
        }

        public void Delete(long id) {
            _repository.Delete(id);
        }

      
        public Person Update(Person person) {
            return _repository.Update(person);
        }

    }
}
