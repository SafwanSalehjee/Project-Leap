using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Project_Leap_V3
{
    /// <summary>
    /// it handles the security of information 
    /// </summary>
    public class Security
    {
        /// <summary>
        /// It encrypts the parameter. It used as a hash Function
        /// </summary>
        /// <param name="password">The String that needs to hashed</param>
        /// <returns></returns>
        public static String Encrypt(String password)
        {
            SHA1 hashAlgorithm = SHA1.Create(); //Hash algorithm declaration
            byte[] c;                           //Byte array to store the returned hashed data

            //Convert the input string to a byte array and compute the hash
            c = hashAlgorithm.ComputeHash(Encoding.Default.GetBytes(password));
            //String variable that will store the returned hashed string
            String hashedpassword = "";

            //Loop through each byte of the hashed data and format each one as a hexadecimal string
            for (int a = 0; a < c.Length; a++)
            {
                hashedpassword += c[a].ToString("x2");
            }

            //Return the hexadecimal string
            return hashedpassword;
        }
    }
}