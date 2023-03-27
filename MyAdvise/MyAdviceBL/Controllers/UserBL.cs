using DataAccessLayer;
using DataAccessLayer.Models.Models;
using DataAccessLayer.ViewModels.ViewModels;
using MyAdviceBL.Controllers.Interfaces;
using MyAdviceWebApi.MailHelper;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MyAdviceBL.Controllers
{
    public class UserBL : IUserBL
    {
        private readonly IUnitOfWork uow;

        public UserBL(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public UserVM CreateUser(UserVM userVM)
        {
            try
            {
                User user = new User()
                {
                    UserId = userVM.UserId,
                    Address = userVM.Address,
                    DocType = userVM.DocType,
                    Email = userVM.Email,
                    Name = userVM.Name,
                    Password = userVM.Password,
                    RegisterDate = DateTime.Now,
                    Surname = userVM.Surname
                };

                if (userVM != null)
                {
                    uow.User.Insert(user);
                    uow.Commit();
                    EmailHelper.SendEmail(userVM);
                    UserVM u = new UserVM(user);
                    u.IsCreated = true;
                    return u;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }

        public IEnumerable<UserVM> GetAllUser()
        {
            return uow.User.FindAll().Select(x => new UserVM(x));
        }

        public UserVM Login(string email, string password)
        {
            User user = uow.User.FindAll(x => x.Email == email && x.Password == password).First();
            return (user != null) ? new UserVM(user) : null;
        }

        public UserVM UpdateUser(UserVM userVM)
        {
            try
            {
                if (uow.User.FindAll(x => x.UserId == userVM.UserId) != null)
                {
                    User user = new User()
                    {
                        UserId = userVM.UserId,
                        Name = userVM.Name,
                        Surname = userVM.Surname,
                        Address = userVM.Address,
                        DocType = userVM.DocType,
                        Email = userVM.Email,
                        Password = userVM.Password
                    };
                    uow.User.Update(user);
                    uow.Commit();
                    return new UserVM(user);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error ocurred" + ex);
            }
        }
    }
}
