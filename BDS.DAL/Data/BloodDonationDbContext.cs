using BDS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BDS.DAL.Data;

public partial class BloodDonationDbContext : DbContext
{
    public BloodDonationDbContext()
    {
    }

    public BloodDonationDbContext(DbContextOptions<BloodDonationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BloodCompatibility> BloodCompatibilities { get; set; }

    public virtual DbSet<BloodComponentType> BloodComponentTypes { get; set; }

    public virtual DbSet<BloodDonationRegister> BloodDonationRegisters { get; set; }

    public virtual DbSet<BloodInventory> BloodInventories { get; set; }

    public virtual DbSet<BloodRequest> BloodRequests { get; set; }

    public virtual DbSet<BloodType> BloodTypes { get; set; }

    public virtual DbSet<DonationForm> DonationForms { get; set; }

    public virtual DbSet<ReportLog> ReportLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:cnn"];

        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BloodCompatibility>(entity =>
        {
            entity.HasKey(e => e.CompatibilityId).HasName("PK__BloodCom__637D0D5231DF4AD7");

            entity.HasOne(d => d.ComponentType).WithMany(p => p.BloodCompatibilities).HasConstraintName("FK__BloodComp__compo__68487DD7");

            entity.HasOne(d => d.DonorBloodType).WithMany(p => p.BloodCompatibilityDonorBloodTypes).HasConstraintName("FK__BloodComp__donor__66603565");

            entity.HasOne(d => d.RecipientBloodType).WithMany(p => p.BloodCompatibilityRecipientBloodTypes).HasConstraintName("FK__BloodComp__recip__6754599E");
        });

        modelBuilder.Entity<BloodComponentType>(entity =>
        {
            entity.HasKey(e => e.ComponentTypeId).HasName("PK__BloodCom__B4DB9EEE4FACF596");
        });

        modelBuilder.Entity<BloodDonationRegister>(entity =>
        {
            entity.HasKey(e => e.RegisterId).HasName("PK__BloodDon__0F6736685D3FEFFD");

            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.User).WithMany(p => p.BloodDonationRegisters).HasConstraintName("FK__BloodDona__userI__571DF1D5");
        });

        modelBuilder.Entity<BloodInventory>(entity =>
        {
            entity.HasKey(e => e.BloodBagId).HasName("PK__BloodInv__7CA7D7B3A46C9090");

            entity.HasOne(d => d.BloodType).WithMany(p => p.BloodInventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BloodInve__blood__534D60F1");

            entity.HasOne(d => d.ComponentType).WithMany(p => p.BloodInventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BloodInve__compo__5441852A");
        });

        modelBuilder.Entity<BloodRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__BloodReq__E3C5DE313B8A2B38");

            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.BloodType).WithMany(p => p.BloodRequests).HasConstraintName("FK__BloodRequ__blood__5CD6CB2B");

            entity.HasOne(d => d.Staff).WithMany(p => p.BloodRequestStaffs).HasConstraintName("FK__BloodRequ__staff__60A75C0F");

            entity.HasOne(d => d.User).WithMany(p => p.BloodRequestUsers).HasConstraintName("FK__BloodRequ__userI__5BE2A6F2");
        });

        modelBuilder.Entity<BloodType>(entity =>
        {
            entity.HasKey(e => e.BloodTypeId).HasName("PK__BloodTyp__C879D074382AFDE3");
        });

        modelBuilder.Entity<DonationForm>(entity =>
        {
            entity.HasOne(d => d.Request).WithMany(p => p.DonationForms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonationF__reque__6C190EBB");

            entity.HasOne(d => d.User).WithMany(p => p.DonationForms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonationF__userI__6B24EA82");
        });

        modelBuilder.Entity<ReportLog>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__ReportLo__1C9B4E2D2AD6F23D");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ReportLogs).HasConstraintName("FK__ReportLog__creat__6383C8BA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CFF236446DF");

            entity.HasOne(d => d.BloodType).WithMany(p => p.Users).HasConstraintName("FK__User__bloodTypeI__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
