using Api_curso.HiperMidia;
using Api_curso.HiperMidia.Abstract;
using System.Collections.Generic;

namespace Api_curso.Data.VO {

    public class PersonVO : ISupportHiperMedia {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public string Address { get; set; }
       
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
