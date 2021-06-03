using Api_curso.Data.Vo;

namespace Api_curso.Business {
    public interface ILoginBusiness {

        TokenVO ValidateCredentials(UserVO user);
    }
}
