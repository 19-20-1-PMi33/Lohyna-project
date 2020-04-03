using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.ProfileService
{
    public class ProfileService : IProfileService
    {

        public Task<Person> LoadPersonAsync(string username)
        {
            return new Task<Person>(() => new Student{Name = "Roman",Surname = "Levkovych",Username="rlevkovych",Photo="profile1.jpg",Password="admin",personType = PersonType.student,GroupID="PMi-33",TicketNumber=1,ReportCard=1,Faculty="Applied Mathematics and Informatics"});
        }

        public Task<PersonType> PersonTypeAsync(string username)
        {
            return new Task<PersonType>(()=>PersonType.student);
        }
    }
}