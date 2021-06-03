using Api_curso.Data.Vo;
using Api_curso.Model;

namespace Api_curso.Repository {
    public  interface IUserRepository {

        User ValidateCredentials(UserVO user);

    }
}
