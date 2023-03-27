using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public bool DocType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsCreated { get; set; }
        public UserVM() { }
        public UserVM(User u)
        {
            UserId = u.UserId;
            Name = u.Name;
            Surname = u.Surname;
            Address = u.Address;
            DocType = u.DocType;
            Email = u.Email;
            Password = u.Password;
        }
    }
}
