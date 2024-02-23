using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AuthenticateClassLibrary;

namespace AuthenticateAPI.Data;

public class SecurityDbContext : IdentityDbContext<IdentityUser>
{
    public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
    
}

