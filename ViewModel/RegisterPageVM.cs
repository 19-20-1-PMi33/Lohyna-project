using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataServices.Services;

namespace ViewModel
{
    public class RegisterPageVM
    {
        private IPersonService service;
        public RegisterPageVM(IPersonService service)
        {
            this.service = service;
        }
        public string copyImage(string fileName,string nom_zal)
        {
            string path = Directory.GetCurrentDirectory();
            string destFolder = Path.Combine("..","..","..", "View", "Widgets", "Images", "Profile_Images");
            string destFile = Path.Combine(destFolder, nom_zal + Path.GetExtension(fileName));
            File.Copy(fileName, destFile);
            return destFile;
        }
        public bool validateValues(string name, string surname, string zal, string username, string password, string passwordRepeat)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(surname))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(zal))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(username))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            if (password != passwordRepeat)
            {
                return false;
            }
            return true;
        }
        public bool registerUser(string name, string surname, string zal, string username, string password, string photo)
        {
            Model.Person person = new Model.Person { Name = name, Surname = surname, Password = password, Photo = photo, Username = username };
            service.CreatePersonAsync(person).Wait();
            return true;
        }
    }
}
