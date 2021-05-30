using Api_curso.Data.Converter.Contract;
using Api_curso.Data.Vo;
using Api_curso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_curso.Data.Converter.Implementations {
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO> {
        public Book Parse(BookVO origem) {
            if (origem == null) return null;
            return new Book {
                Id = origem.Id,
                Title = origem.Title,
                Author = origem.Author,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate
            };
        }

      

        public BookVO Parse(Book origem) {
            if (origem == null) return null;
            return new BookVO {
                Id = origem.Id,
                Title = origem.Title,
                Author = origem.Author,
                Price = origem.Price,
                LaunchDate = origem.LaunchDate
            };
        }

        public List<Book> Parse(List<BookVO> origem) {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origem) {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
