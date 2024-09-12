using Microsoft.EntityFrameworkCore;
using ProjectManager.Infrastructure.Data;

namespace ProjectManager.UnitTests.Mocks
{
    public class DatabaseMock
    {
        public static ProjectManagerDbContext instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ProjectManagerDbContext>()
                    .UseInMemoryDatabase("ProjectTrackerInMemoryDb"
                        + DateTime.Now.Ticks.ToString())
                    .Options;

                return new ProjectManagerDbContext(dbContextOptions);
            }
        }
    }
}
