using System.Threading.Tasks;
using System.Collections.Generic;
using Core;


namespace Services.RatingService
{
    public interface IRatingService
    {
        Task<List<Model.Rating>> LoadRatingAsync(Model.Student student);
    }
}