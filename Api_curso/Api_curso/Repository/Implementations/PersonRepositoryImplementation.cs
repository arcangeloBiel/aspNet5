using Api_curso.Model;
using Api_curso.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_curso.Repository.Implementations {
    public class PersonRepositoryImplementation : IPersonRepository {
        //inject dependency
        private PersonContext _context;

        public PersonRepositoryImplementation(PersonContext context) {
            _context = context;
        }

        public Person Create(Person person) {

            try {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex) {

                throw ex;
            }
            return person;
        }

        public List<Person> FindAll() {
            return _context.persons.ToList();
        }


        public Person FindById(long id) {
            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public void Delete(long id) {
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null) {
                try {
                    _context.persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex) {

                    throw ex;
                }
            }
        }

      

        public Person Update(Person person) {
            if (!Exists(person.Id)) return null;
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex) {

                    throw ex;
                }
            }
            return person;
        }

        public bool Exists(long id) {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
