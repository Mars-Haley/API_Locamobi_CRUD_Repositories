using Api1.Entity;
using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<UserEntity> Users { get; set; }
}