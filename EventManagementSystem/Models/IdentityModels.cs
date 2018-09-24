using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        [Display(Name = " Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "This field is required")]

        [Display(Name = "Contact")]
        public string Contact { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<ClientFeedback> ClientFeedback { get; set; }
        public DbSet<DecorationType> DecorationTypes { get; set; }
        public DbSet<DecorationImage> DecorationImages { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EventBill> EventBills { get; set; }
        public DbSet<EventPayment> EventPayments { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<EventsCatering> EventsCaterings { get; set; }
        public DbSet<EventSchedule> EventSchedules { get; set; }
        public DbSet<EventsCinematography> EventsCinematographies { get; set; }

        public DbSet<EventsDecoration> EventsDecorations { get; set; }
        public DbSet<EventServices> EventServicess { get; set; }
        public DbSet<EventsPhotography> EventsPhotographies { get; set; }
        public DbSet<EventSubType> EventSubTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}