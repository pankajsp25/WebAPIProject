using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class EmpSecurity
    {
        public static bool Login(string UserName, string Password)
        {
            WebAPIEntities1 u=new WebAPIEntities1();
            return u.Login_Table.Any(user => user.UserName == UserName && user.Password == Password); ;

            
          
        }
    }
}