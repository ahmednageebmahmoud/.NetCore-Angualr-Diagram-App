using Draw.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.AuthBLL
{
    public interface IJWTService
    {
        Task<string> Create(ApplicationUser user);

    }
}
