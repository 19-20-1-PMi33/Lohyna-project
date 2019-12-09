using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataServices.Services;

namespace ViewModel
{
    public class RegisterPageVM
    {
        private const string profileImagesFolder = "Widgets/Images/Profile_Images/";
        private string userPhoto = "Widgets/Images/profile_placeholder.jpg";
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
            string returningPath = profileImagesFolder + nom_zal + Path.GetExtension(fileName);
            this.userPhoto = returningPath;
            return returningPath;
        }
        public bool validateValues(params string[] values)
        {
            bool res = true;
            new List<String>(values).ForEach(value =>
            {
                if (String.IsNullOrWhiteSpace(value))
                    res = false;
            });
            if (values[values.Length-1] != values[values.Length-2])
            {
                res = false;
            }
            return res;
        }
        public bool registerUser(string name, string surname, string zal, string username, string password)
        {
            Model.Person person = new Model.Person { Name = name, Surname = surname, Password = password, Photo = userPhoto, Username = username };
            service.CreatePersonAsync(person).Wait();
            return true;
        }
    }
}
