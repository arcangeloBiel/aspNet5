using Api_curso.Model;
using System.Collections.Generic;
using System.Threading;

namespace Api_curso.Services.Implementations {
    public class PersonServiceImplementation : IPersonService {
        //mockando id toda vez vai incrementar um numero a +
        private volatile int count;

        public Person Create(Person person) {
            return person;
        }

        public void Delete(long id) {
            
        }

        public List<Person> FindAll() {
            List<Person> persons = new List<Person>(); 
            for(int i = 0; i < 8; i++) {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }


        public Person FindById(long id) {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "joao",
                LastName = "ribeiro",
                Address = "brusque",
                Gender = "male"
            };
        }

        public Person Update(Person person) {
            return person;
        }


        private Person MockPerson(int i) {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Some Address" +i,
                Gender = "male"
            };
        }

        private long IncrementAndGet() {
            return Interlocked.Increment(ref count);
        }
    }
}
