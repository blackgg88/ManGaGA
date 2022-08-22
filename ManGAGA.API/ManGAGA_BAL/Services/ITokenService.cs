using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
