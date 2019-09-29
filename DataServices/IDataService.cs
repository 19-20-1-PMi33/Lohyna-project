using System;
using DataServices.Services;

namespace DataServices
{
    public interface IDataService : IDisposable, IFaqService, IMarkService,
        INoteService, IPersonService, ITimeTableService

    {

    }
}