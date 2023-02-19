using Employee_Registration.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Employee_Registration.Data
{
    //Inherit From DbContext
    public class EmployeeRegistrationDbContext : DbContext
    {
        //Create Constructor
        public EmployeeRegistrationDbContext(DbContextOptions options) : base(options) {}     
        //Create Properties for Access table
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(e => e.Emails).WithMany().HasForeignKey(e => e.EmailId);
            modelBuilder.Entity<Employee>().HasOne(e => e.Mobile).WithMany().HasForeignKey(e => e.MobileId);
            modelBuilder.Entity<Employee>().HasOne(e => e.Address).WithMany().HasForeignKey(e => e.AddressId);
        }
    }
}
