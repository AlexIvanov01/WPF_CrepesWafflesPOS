﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace CrepesWaffelsPOS.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public UserModel(string name, string password, double balance)
        {
            Username = name;
            Password = password;
            Balance = balance;
        }

        public UserModel() { }

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
