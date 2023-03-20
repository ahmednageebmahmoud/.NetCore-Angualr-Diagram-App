using Draw.BLL.Helpers.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Helpers.Auth
{
    public interface IAuthService : IService
    {
        Task<IResponse<AuthModel>> Register(RegisterModel register);
        Task<IResponse<AuthModel>> Login(LoginModel login);

    }
}
