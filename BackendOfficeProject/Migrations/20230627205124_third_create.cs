using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendOfficeProject.Migrations
{
    /// <inheritdoc />
    public partial class third_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSalesInvoiceAmount = table.Column<int>(type: "int", nullable: false),
                    TotalVatAmount = table.Column<int>(type: "int", nullable: false),
                    TotalSalesInvoicePlusVatAmount = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadDetail_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadDetail_CustomerId",
                table: "HeadDetail",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadDetail");
        }
    }
}
