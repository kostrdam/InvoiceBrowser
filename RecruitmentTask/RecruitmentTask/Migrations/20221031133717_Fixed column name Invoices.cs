using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentTask.Migrations
{
    public partial class FixedcolumnnameInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceItem",
                newName: "InvoicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoicesId",
                table: "InvoiceItem",
                column: "InvoicesId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoicesId",
                table: "InvoiceItem");

            migrationBuilder.RenameColumn(
                name: "InvoicesId",
                table: "InvoiceItem",
                newName: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
