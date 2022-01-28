using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<MedicineBranch> MedicineBranchs { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<MedicineCard> MedicineCards { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<MedicineAsset> MedicineAssets { get; set; }
        public DbSet<Hold> Holds { get; set; }
    }
}
