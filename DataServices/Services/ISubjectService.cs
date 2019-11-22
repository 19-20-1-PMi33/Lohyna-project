﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface ISubjectService
    {
        Task<IList<Subject>> LoadSubjectsAsync();
    }
}
