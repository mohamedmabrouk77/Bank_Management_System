using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Customer> Customerss { get; set; }
        public DbSet<Account> Accountss { get; set; }
        public DbSet<Employee> Employeess { get; set; }
        public DbSet<Transaction> Transactionss { get; set; }
        public DbSet<Branch> Branchess { get; set; }
        public DbSet<BankCard> BankCardss { get; set; }
    }
}
