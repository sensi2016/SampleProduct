using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SampleProduct.Application.Common
{
    public class Helpers
    {
        public static string CreateHashPassword(string input)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            HashAlgorithm algorithm = new SHA256CryptoServiceProvider();
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes).Replace("-","");
        }
    }
}
