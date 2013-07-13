using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHashing
{
    class Program
    {
        static void Main(string[] args)
        {

            var keyAndSalt = Hash.Generator.Generate("P@ssword2013");

            bool isEqual1 = Hash.Generator.Validate(keyAndSalt.Password, keyAndSalt.Salt, "Password2013");
            bool isEqual2 = Hash.Generator.Validate(keyAndSalt.Password, keyAndSalt.Salt, "P@ssword2013");
        }
    }
}
