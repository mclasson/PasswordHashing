﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class Generator
    {
        public static HashedPassword Generate(string password)
        {
            byte[] _salt = new byte[8];
            using (RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider())
            {
                csp.GetBytes(_salt);
            }
            byte[] _password = System.Text.Encoding.UTF8.GetBytes(password);
            Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(_password, _salt, 10000);
            var _saltedPasswordHash = k1.GetBytes(24);
            return new HashedPassword()
            {
                Password = Convert.ToBase64String(_saltedPasswordHash),
                Salt = Convert.ToBase64String(_salt)
            };
        }
        public static bool Validate(string passwordHash, string saltHash, string enteredPassword)
        {
            byte[] _password = System.Text.Encoding.UTF8.GetBytes(enteredPassword);
            Rfc2898DeriveBytes keyEntered = new Rfc2898DeriveBytes(_password, Convert.FromBase64String(saltHash), 10000);           
            return Convert.ToBase64String(keyEntered.GetBytes(24)) == passwordHash;

        }
    }
    public struct HashedPassword
    {
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
