using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankCardss",
                columns: table => new
                {
                    BankCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankCardName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCardss", x => x.BankCardId);
                });

            migrationBuilder.CreateTable(
                name: "Branchess",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchess", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Employeess",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeess", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Customerss",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BankCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customerss", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customerss_BankCardss_BankCardId",
                        column: x => x.BankCardId,
                        principalTable: "BankCardss",
                        principalColumn: "BankCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchEmployee",
                columns: table => new
                {
                    BrancheBranchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchEmployee", x => new { x.BrancheBranchId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_BranchEmployee_Branchess_BrancheBranchId",
                        column: x => x.BrancheBranchId,
                        principalTable: "Branchess",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchEmployee_Employeess_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employeess",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accountss",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountss", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accountss_Customerss_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customerss",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactionss",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactionss", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactionss_Accountss_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accountss",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accountss_CustomerId",
                table: "Accountss",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchEmployee_EmployeeId",
                table: "BranchEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customerss_BankCardId",
                table: "Customerss",
                column: "BankCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactionss_AccountId",
                table: "Transactionss",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchEmployee");

            migrationBuilder.DropTable(
                name: "Transactionss");

            migrationBuilder.DropTable(
                name: "Branchess");

            migrationBuilder.DropTable(
                name: "Employeess");

            migrationBuilder.DropTable(
                name: "Accountss");

            migrationBuilder.DropTable(
                name: "Customerss");

            migrationBuilder.DropTable(
                name: "BankCardss");
        }
    }
}
