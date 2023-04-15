using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShareYouTube.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                   }

        public DbSet<ShareYouTube.Models.ApplicationUserViewModels.ApplicationRolesViewModel> ApplicationRolesViewModel { get; set; }

        public DbSet<ShareYouTube.Models.ApplicationUserViewModels.UserListViewModel> UserListViewModel { get; set; }

        public DbSet<ShareYouTube.Models.ApplicationUserViewModels.UserViewModel> UserViewModel { get; set; }

        public DbSet<ShareYouTube.Models.ApplicationUserViewModels.UserEditViewModel> UserEditViewModel { get; set; }

        public DbSet<ShareYouTube.Models.ApplicationUserViewModels.RoleClaimsViewModel> RoleClaimsViewModel { get; set; }
    }
}
