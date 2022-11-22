using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class AdminService
    {
        public bool getAdminByUserName(string username,string password)
        {
           
                using (var prapazdbContext = new PrapazdbContext())
                {
                bool x= prapazdbContext.Admin.Any(x => x.UserName.ToLower() == username&&x.Password==password);
                return x;
                }
            
        }
    }
}
