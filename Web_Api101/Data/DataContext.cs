using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Web_Api101.models;

namespace Web_Api101.Data
{
    public class DataContext : DbContext
    {
        

        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public  DbSet<burns> burns { get; set; }
        public DbSet<clinics> clinics { get; set; }
        public DbSet<doctors> doctors { get; set; }
        public DbSet<hospitals> hospitals { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<phones> phones { get; set; }
        public DbSet<patient> patients { get; set; }
        public DbSet<doctor_clinic> doctor_Clinics { get; set; }
        public DbSet<burn_patient> burn_Patients { get; set; }
        public DbSet<hospital_doctor> hospital_Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //doctor_clinic
            modelBuilder.Entity<doctor_clinic>().HasKey(dc => new { dc.clinic_id, dc.doctor_id });
            modelBuilder.Entity<doctor_clinic>().HasOne(d => d.doctor)
               .WithMany(dc => dc.doctor_Clinics)
               .HasForeignKey(dc => dc.clinic_id);
            modelBuilder.Entity<doctor_clinic>().HasOne(d => d.clinic)
               .WithMany(dc => dc.doctor_Clinics).
               HasForeignKey(c => c.doctor_id);
            //burn_patient

            modelBuilder.Entity<burn_patient>().HasKey(bp => new { bp.patient_id, bp.burn_id });
            modelBuilder.Entity<burn_patient>().HasOne(b => b.burn).
                WithMany(bp => bp.burn_Patients).HasForeignKey(bp => bp.burn_id);

            modelBuilder.Entity<burn_patient>().HasOne(p => p.patient).
                WithMany(bp => bp.burn_Patients).HasForeignKey(bp => bp.patient_id);
            //hospital_doctor
            modelBuilder.Entity<hospital_doctor>().HasKey(hd => new { hd.doctor_id, hd.hospital_id });
            modelBuilder.Entity<hospital_doctor>().HasOne(h => h.hospital)
                .WithMany(hd => hd.hospital_Doctors).HasForeignKey(hd => hd.hospital_id);
            modelBuilder.Entity<hospital_doctor>().HasOne(d => d.doctor)
                .WithMany(hd => hd.hospital_Doctors).HasForeignKey(hd => hd.doctor_id);
            //one-to-many relationships
            modelBuilder.Entity<doctors>()
       .HasMany(o => o.phones)             // Order has many OrderItems
       .WithOne(oi => oi.doctors)                 // OrderItem has one Order
       .HasForeignKey(oi => oi.doctorId);
            modelBuilder.Entity<hospitals>()
       .HasMany(o => o.Phones)             // Order has many OrderItems
       .WithOne(oi => oi.hospitals)                 // OrderItem has one Order
       .HasForeignKey(oi => oi.hospitalId);
            modelBuilder.Entity<patient>()
       .HasMany(o => o.Phones)             // Order has many OrderItems
       .WithOne(oi => oi.patient)                 // OrderItem has one Order
       .HasForeignKey(oi => oi.patientId);
            modelBuilder.Entity<clinics>()
       .HasMany(o => o.Phones)             // Order has many OrderItems
       .WithOne(oi => oi.clinics)                 // OrderItem has one Order
       .HasForeignKey(oi => oi.clinicId);

            // seeding
            // Seed data (sample values)
            modelBuilder.Entity<doctors>().HasData(
              new doctors { id = 1, name = "Hasanin", speciality = "Cardiology", gender = 'M', LocationId = 1 },
              new doctors { id = 2, name = "Mohsen", speciality = "Pediatrics", gender = 'F', LocationId = 1 },
              new doctors { id = 3, name = "ragab", speciality = "Pediatrics", gender = 'm', LocationId = 2 }

              );
            modelBuilder.Entity<phones>().HasData(
    new phones { Id = 1, doctorId = 1, phone_number = "0100212121" }, // Phone for Dr. Hasanin at Clinic A
    new phones { Id = 2, doctorId = 2, phone_number = "0100333333" }  // Phone for Dr. Mohsen at Clinic B
);
            modelBuilder.Entity<location>().HasData(
    new location { id = 1, location_name = "farshut",}, // Location ID 3 (farshut)
    new location { id = 2, location_name = "qous", } // Location ID 3 (farshut)
     
);
            modelBuilder.Entity<hospitals>().HasData(
                    new hospitals { id = 1, hospital_name = "Hospital A", locid = 1 },
                    new hospitals { id = 2, hospital_name = "Hospital B", locid = 2 }
                // Add more hospitals as needed
                );
            modelBuilder.Entity<clinics>().HasData(
                    new clinics { Id = 1,  locid = 1 },
                    new clinics { Id = 2,  locid = 2 }
                // Add more hospitals as needed
                );


        }
    }
}
