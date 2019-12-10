using System;
using DataServices.Services;

namespace DataServices
{
    /// <summary>
    /// Global data service.
    /// </summary>
    public interface IDataService : IDisposable, IFaqService, IMarkService,
        INoteService, IPersonService, ITimeTableService, ISubjectService, IGroupService
    {

    }
}