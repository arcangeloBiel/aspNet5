using Api_curso.Model.Base;
using Api_curso.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_curso.Repository.Generic {
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity {

        private MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context) {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item) {
            try {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public List<T> FindAll() {
            return dataset.ToList();
        }

        public T FindById(long id) {
           return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item) {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception ex) {

                    throw ex;
                }
            } else {
                return null;
            }
        }

        public void Delete(long id) {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null) {
                try {
                    dataset.Remove(result);
                    _context.SaveChanges();
                   
                }
                catch (Exception ex) {

                    throw ex;
                }
            }
        }

        public bool Exists(long id) {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
