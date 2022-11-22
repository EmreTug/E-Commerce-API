using Prasoft.Business.Abstract;
using Prasoft.Data;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminRepository _AdminRepository;
        public AdminManager()
        {
            _AdminRepository = new AdminRepository();
        }
        public bool getAdminByUserName(string username,string password)
        {
            return _AdminRepository.getAdminByUserName(username, password);
        }
    }
}
