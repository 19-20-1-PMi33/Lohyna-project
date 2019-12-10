using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataServices.Services;
using DataServices;
using Model;
namespace ViewModel
{
    public struct ParamsForRegister
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordRepeat { get; set; }
        public string group { get; set; }
        public string zal { get; set; }
        public string ticket { get; set; }
        public ParamsForRegister(string name,string surname,string username,string password,string passwordRep,string group,string zal,string ticket)
        {
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
            this.passwordRepeat = passwordRep;
            this.group = group;
            this.zal = zal;
            this.ticket = ticket;
        }
    }
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
        public bool validateValues(ParamsForRegister values)
        {
            bool res = true;
            new List<String>{values.name,values.surname,values.username,values.password,values.group,values.zal,values.ticket }.ForEach(value =>
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    res = false;
                }
            });
            if (values.password != values.passwordRepeat)
            {
                res = false;
            }
            long temp;
            if(!long.TryParse(values.ticket,out temp))
            {
                res = false;
            }
            if (!long.TryParse(values.zal, out temp))
            {
                res = false;
            }
            return res;
        }
        public bool registerUser(ParamsForRegister values)
        {
            Model.Person person = new Model.Person { Name = values.name, Surname = values.surname, Password = values.password, Photo = userPhoto, Username = values.username };
            Model.Student student = new Model.Student { TicketNumber = long.Parse(values.ticket), ReportCard = long.Parse(values.zal), PersonID = values.username, GroupID = values.group };
            if (service.LoadLogInPersonAsync(values.username) == null)
            {
                service.CreatePersonAsync(person).Wait();
                service.CreateStudentAsync(student).Wait();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<String> GetGroups()
        {
            List<String> res = new List<string>();
            foreach (Group s in (new SQLiteDataService()).LoadGroupsAsync().Result)
            {
                res.Add(s.Name);
            }
            return res;
        }
    }
}
