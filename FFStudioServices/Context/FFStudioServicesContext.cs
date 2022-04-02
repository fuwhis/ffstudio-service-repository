using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FFStudioServices.Context
{
    public class FFStudioServicesContext: DbContext
    {
        public FFStudioServicesContext(DbContextOptions<FFStudioServicesContext> options): base(options)
        {
            
        }

    }
}
