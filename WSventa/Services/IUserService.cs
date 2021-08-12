using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WSventa.Models.Response;
using WSventa.Models.Request;


namespace WSventa.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
