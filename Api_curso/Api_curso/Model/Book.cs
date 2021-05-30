﻿
using Api_curso.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api_curso.Model {
    [Table("books")]
    public class Book: BaseEntity {
       
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

    }
}