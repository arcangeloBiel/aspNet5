using System.ComponentModel.DataAnnotations.Schema;

namespace Api_curso.Model.Base {
    public class BaseEntity {
        [Column("id")]
        public int Id { get; set; }
    }
}
