using Draw.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Interface
{
    public interface IAuthService : IService
    {
        Task<IResponse<AuthModel>> Register(RegisterModel register);
        Task<IResponse<AuthModel>> Login(LoginModel login);

    }
}
