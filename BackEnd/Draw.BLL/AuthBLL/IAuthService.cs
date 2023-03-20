using Draw.BLL.ReponseBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.AuthBLL
{
    public interface IAuthService  
    {
        Task<IResponse<AuthModel>> Register(RegisterModel register);
        Task<IResponse<AuthModel>> Login(LoginModel login);

    }
}
