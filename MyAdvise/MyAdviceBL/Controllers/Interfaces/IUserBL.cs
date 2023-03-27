using DataAccessLayer.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdviceBL.Controllers.Interfaces
{
    public interface IUserBL
    {
        public IEnumerable<UserVM> GetAllUser();
        public UserVM Login(string email, string password);
        public UserVM CreateUser(UserVM userVM);
        public UserVM UpdateUser(UserVM userVM);
    }
}
