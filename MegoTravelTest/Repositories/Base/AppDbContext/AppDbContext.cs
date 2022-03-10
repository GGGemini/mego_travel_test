using System.ComponentModel.DataAnnotations.Schema;
using MegoTravelTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegoTravelTest.Repositories.Base.AppDbContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ExternalSearch> ExternalSearches { get; set; }
}