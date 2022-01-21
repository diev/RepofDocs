using Microsoft.EntityFrameworkCore;

namespace Rosd.Data.Conventions;

public interface IDatabaseConventionConverter
{
    void SetConvention(ModelBuilder modelBuilder);
}
