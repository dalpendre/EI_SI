using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthService
{
    public class AuthService : IAuthService
    {

        /// <summary>
        /// Exemplo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string VerifyAcessToBD()
        {
            User user = SqlServerHelper.GetUser(1);
            if (user == null)
                return "Erro ao aceder à base de dados";
            return user.Name;
        }


        public User[] GetUsers(string login, string password) 
        {
            if(SqlServerHelper.UserExists(login, password) == 0)
            {
                //NOT AUTHENTICATED
                return null;
            }

            //AUTHENTICATED
            return SqlServerHelper.GetUsers().ToArray();
        }

        public User GetUser(int id)
        {
            return SqlServerHelper.GetUser(id);
        }

        public bool UpdateUserDescription(string login, string password, string description) 
        {
            int userID = SqlServerHelper.UserExists(login, password);
            if(userID == 0)
            {
                return false;
            }

            var result = SqlServerHelper.UpdateUserDescription(userID, description);

            return result == 1;
        }

        public string[] GetHashes() 
        {
            string[] hashes = new string[2];

            using(SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider())
            {
                hashes[0] = 
                Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes("123")));

                hashes[1] =
                Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes("456")));
            }

            return hashes;
        }
    }

}
