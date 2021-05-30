﻿using System;

namespace Api_curso.Data.Vo {
    public class BookVO {
        public int Id { get; set; }
        public string Title { get; set; }
      
        public string Author { get; set; }
      
        public decimal Price { get; set; }
      
        public DateTime LaunchDate { get; set; }
    }
}
