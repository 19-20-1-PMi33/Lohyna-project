using System.Threading.Tasks;
using System.Collections.Generic;
using Core;

namespace Services.RatingService
{
    public interface IRatingService
    {
        Task<List<Core.DTO.Rating>> LoadRatingAsync();
    }
}