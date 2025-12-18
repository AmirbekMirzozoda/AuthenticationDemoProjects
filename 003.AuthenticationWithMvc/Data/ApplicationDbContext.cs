using _002.AuthenticationWithMvc.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _002.AuthenticationWithMvc.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<User, IdentityRole<long>, long>(options)
{
    public DbSet<User> Users { get; set; }
}