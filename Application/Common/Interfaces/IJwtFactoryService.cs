using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
     public interface IJwtFactoryService
    {
        Task<string> GenerateEncodedToken(string userName,int id);
    }
}
