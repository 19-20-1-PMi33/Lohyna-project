using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.RatingService
{
    public class RatingService: IRatingService
    {
        public async Task<List<Rating>> LoadRatingAsync()
        {
            List<Rating> listRatings = new List<Rating>()
            {
                new Rating{id = 1, Mark = 2, Time = DateTime.Now(), SubjectID = "PE"},
                new Rating{id = 2, Mark = 20, Time = new DateTime(2020,2,3), SubjectID = "Math"},
                new Rating{id = 3, Mark = 21, Time = new DateTime(2020, 1, 15), SubjectID = "PE"},
                new Rating{id = 4, Mark = 4, Time = new DateTime(2003,4,24), SubjectID = "Cryptology"},
                new Rating{id = 5, Mark = 5, Time = new DateTime(2004, 12, 23), SubjectID = "Numerical methods"}
            }
            return listRatings;
        }
    }
}