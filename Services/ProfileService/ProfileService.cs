using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        public async Task<Person> LoadPersonAsync(string username)
        {
            return new Student{Name = "Roman",Surname = "Levkovych",Username=username,Photo="profile1.jpg",Password="admin",personType = PersonType.student,Group="PMi-33",TicketNumber=1,ReportCard=1,Faculty="Applied Mathematics and Informatics"};
        }
    }
}