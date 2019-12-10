using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DataServices.Services;

namespace ViewModel
{
	public class Authorisation
	{
        /// <summary>
        /// Class providing services for autherisate user using username and password
        /// </summary>
        readonly IPersonService service;
        public Authorisation(IPersonService personService)
        {
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
            service = personService;
        }
        /// <summary>
        /// Method to validate username and password
        /// </summary>
        /// <param name="username">Username of person</param>
        /// <param name="password">Password of person</param>
        /// <returns>True if values are valid, in other cases false</returns>
        public bool IsCorrectPersonData(string username, string password)
        {

            var person = service.LoadLogInPersonAsync(username);

            Console.WriteLine($"Password hashed: {ComputeSha256Hash(password)}");

            return person != null && person.Password.Equals(ComputeSha256Hash(password));
        }
        /// <summary>
        /// Method to hash password to store it in db
        /// </summary>
        /// <param name="rawData">Password as usual string</param>
        /// <returns>Password as hashed string</returns>
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
