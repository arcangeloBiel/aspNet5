using Microsoft.EntityFrameworkCore;

namespace Api_curso.Model.Context {
    public class MySQLContext: DbContext {

        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {
        }

        public DbSet<Person> persons { get; set; }

        public DbSet<Book> books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
