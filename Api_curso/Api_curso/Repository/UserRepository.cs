using Api_curso.Data.Vo;
using Api_curso.Model;
using Api_curso.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api_curso.Repository {
    public class UserRepository : IUserRepository {

        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context) {
            _context = context;
        }

        public User ValidateCredentials(UserVO user) {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }
        public User RefreshUserInfo(User user) {

            if (!_context.Users.Any(p => user.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception ex) {

                    throw ex;
                }
            }
            return result;
        }
        private string ComputeHash(string inputSenha, SHA256CryptoServiceProvider algoritohm) {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(inputSenha);
            Byte[] hashedBytes = algoritohm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
