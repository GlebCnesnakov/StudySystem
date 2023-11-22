using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudySystem
{
    class User
    {

        string login, password;

        public int id {  get; set; }
        public string Login
        {
            set { login = value; }
            get { return login; }
        }
        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public User() { }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
