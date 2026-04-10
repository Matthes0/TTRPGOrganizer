using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Models;

namespace TTRPGOrganizer.Data;

public class OrganizerContext(DbContextOptions<OrganizerContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<RpgSystem> RpgSystems => Set<RpgSystem>();
    
}