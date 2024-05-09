using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace CrepesWaffelsPOS.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public UserModel(string name, string password, double balance)
        {
            Username = name;
            Password = password;
            Balance = balance;
        }
        public void HashPassword()
        {
            // Compute hash from password bytes
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(Password));

            // Convert hash bytes to string
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2")); // Convert byte to hexadecimal string
            }
            Password = stringBuilder.ToString();
        }
    }


}
