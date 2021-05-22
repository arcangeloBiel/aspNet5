using Microsoft.EntityFrameworkCore;

namespace Api_curso.Model.Context {
    public class PersonContext: DbContext {

        public PersonContext() { }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options) {
        }

        public DbSet<Person> persons { get; set; }
    }
}
