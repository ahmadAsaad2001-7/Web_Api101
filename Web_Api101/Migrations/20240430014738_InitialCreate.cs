using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api101.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "burns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<int>(type: "int", nullable: false),
                    sensitivity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    worktime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clinics_locations_locid",
                        column: x => x.locid,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_doctors_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hospital_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitals", x => x.id);
                    table.ForeignKey(
                        name: "FK_hospitals_locations_locid",
                        column: x => x.locid,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patients_locations_locid",
                        column: x => x.locid,
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "doctor_Clinics",
                columns: table => new
                {
                    clinic_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor_Clinics", x => new { x.clinic_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_doctor_Clinics_clinics_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctor_Clinics_doctors_clinic_id",
                        column: x => x.clinic_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hospital_Doctors",
                columns: table => new
                {
                    hospital_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital_Doctors", x => new { x.doctor_id, x.hospital_id });
                    table.ForeignKey(
                        name: "FK_hospital_Doctors_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hospital_Doctors_hospitals_hospital_id",
                        column: x => x.hospital_id,
                        principalTable: "hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "burn_Patients",
                columns: table => new
                {
                    burn_id = table.Column<int>(type: "int", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burn_Patients", x => new { x.patient_id, x.burn_id });
                    table.ForeignKey(
                        name: "FK_burn_Patients_burns_burn_id",
                        column: x => x.burn_id,
                        principalTable: "burns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_burn_Patients_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hospitalId = table.Column<int>(type: "int", nullable: true),
                    patientId = table.Column<int>(type: "int", nullable: true),
                    doctorId = table.Column<int>(type: "int", nullable: true),
                    clinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phones_clinics_clinicId",
                        column: x => x.clinicId,
                        principalTable: "clinics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_phones_doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_phones_hospitals_hospitalId",
                        column: x => x.hospitalId,
                        principalTable: "hospitals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_phones_patients_patientId",
                        column: x => x.patientId,
                        principalTable: "patients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "483289d8-e4b8-4bcc-b1a0-c1f3e9648e6c", "7af9af4a-5137-49f0-96c4-3733c7f3fa2e", "User", "USER" },
                    { "d718eabf-ce9f-46e3-b821-c3e8762eeafd", "4f4b36e1-e4c6-45e9-8d58-d90a8935f2e8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "id", "location_name" },
                values: new object[,]
                {
                    { 1, "farshut" },
                    { 2, "qous" }
                });

            migrationBuilder.InsertData(
                table: "clinics",
                columns: new[] { "Id", "locid", "name", "worktime" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "LocationId", "gender", "name", "speciality" },
                values: new object[,]
                {
                    { 1, 1, "M", "Hasanin", "Cardiology" },
                    { 2, 1, "F", "Mohsen", "Pediatrics" },
                    { 3, 2, "m", "ragab", "Pediatrics" }
                });

            migrationBuilder.InsertData(
                table: "hospitals",
                columns: new[] { "id", "hospital_name", "locid" },
                values: new object[,]
                {
                    { 1, "Hospital A", 1 },
                    { 2, "Hospital B", 2 }
                });

            migrationBuilder.InsertData(
                table: "phones",
                columns: new[] { "Id", "clinicId", "doctorId", "hospitalId", "patientId", "phone_number" },
                values: new object[] { 1, null, 1, null, null, "0100212121" });

            migrationBuilder.InsertData(
                table: "phones",
                columns: new[] { "Id", "clinicId", "doctorId", "hospitalId", "patientId", "phone_number" },
                values: new object[] { 2, null, 2, null, null, "0100333333" });

            migrationBuilder.CreateIndex(
                name: "IX_burn_Patients_burn_id",
                table: "burn_Patients",
                column: "burn_id");

            migrationBuilder.CreateIndex(
                name: "IX_clinics_locid",
                table: "clinics",
                column: "locid");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_Clinics_doctor_id",
                table: "doctor_Clinics",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_LocationId",
                table: "doctors",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_hospital_Doctors_hospital_id",
                table: "hospital_Doctors",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "IX_hospitals_locid",
                table: "hospitals",
                column: "locid");

            migrationBuilder.CreateIndex(
                name: "IX_patients_locid",
                table: "patients",
                column: "locid");

            migrationBuilder.CreateIndex(
                name: "IX_phones_clinicId",
                table: "phones",
                column: "clinicId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_doctorId",
                table: "phones",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_hospitalId",
                table: "phones",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_patientId",
                table: "phones",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "burn_Patients");

            migrationBuilder.DropTable(
                name: "doctor_Clinics");

            migrationBuilder.DropTable(
                name: "hospital_Doctors");

            migrationBuilder.DropTable(
                name: "phones");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "burns");

            migrationBuilder.DropTable(
                name: "clinics");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "hospitals");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
