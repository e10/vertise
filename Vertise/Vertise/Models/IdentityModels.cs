using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Vertise.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public IList<Message> Messages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Media
    {
        public int Id { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }

        public IList<Message> Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        
        [MaxLength(420)]
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Deleted { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsReply { get; set; }
        public IList<Message> Replies { get; set; }
        public IList<Media> Media { get; set; }

        public Message Parent { get; set; }
        public int? ParentId { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Media> Media { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}