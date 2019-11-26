using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DataServices;

namespace ViewModel
{
	public class Authorisation
	{
        readonly DataServices.Services.IPersonService service;
        public Authorisation(DataServices.Services.IPersonService personService)
        {
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
            service = personService;
        }

        public bool IsCorrectPersonData(string username, string password)
        {

            var person = service.LoadLogInPersonAsync(username);

            Console.WriteLine($"Password hashed: {ComputeSha256Hash(password)}");

            return person != null && person.Password.Equals(ComputeSha256Hash(password));
        }

        static string ComputeSha256Hash(string rawData)
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
