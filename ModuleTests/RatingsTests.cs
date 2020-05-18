using Xunit;
using System;
using System.Collections.Generic;
using Moq;
using Services;
using WebApplication.Controllers;
using Services.RatingService;
using Core.DTO;
using System.Threading.Tasks;


namespace ModuleTests
{
    public class RatingsTests
    {
        [Fact]
        public void RatingsIndexModelsIsComplete()
        {
            Mock<IRatingService> mock = new Mock<IRatingService>();
            mock.Setup(m => m.LoadRatingAsync()).
            (new List<Rating>{
                new Rating{Id = 1, Mark = 2, Time = DateTime.Now, SubjectID = "PE"},
                new Rating{Id = 2, Mark = 20, Time = new DateTime(2020,2,3), SubjectID = "Math"},
                new Rating{Id = 3, Mark = 21, Time = new DateTime(2020, 1, 15), SubjectID = "PE"},
                new Rating{Id = 4, Mark = 4, Time = new DateTime(2003,4,24), SubjectID = "Cryptology"},
                new Rating{Id = 5, Mark = 5, Time = new DateTime(2004, 12, 23), SubjectID = "Numerical methods"}
            });

            RatingController controller = new RatingController(mock.Object);

            IEnumerable<Rating> result = controller.Index() as IEnumerable<Rating>;

            Assert.Equal(mock.Object.LoadRatingAsync().Result, result);
        }
    }
}