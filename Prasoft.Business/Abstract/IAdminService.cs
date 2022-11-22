using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IAdminService
    {
        bool getAdminByUserName(string username,string password);
    }
}
