using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class DefaultImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7512a027-6c2b-44ec-9dc1-450dc630a1e0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7512a027-6c2b-44ec-9dc1-460dc630a1e0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("255f76df-5217-4de6-9941-f011ea2042cb"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/stilllife.jpg" },
                    { new Guid("50182c2e-8bd1-4d57-9c13-d7f231642d5b"), new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"), "/img/products/portret.jpg" },
                    { new Guid("266ed356-5467-48ac-b1b2-ec3a45ca722a"), new Guid("e66f97c7-6414-423b-9589-8c92a964df62"), "/img/products/landscape.jpg" },
                    { new Guid("8acc7169-6d98-456d-803e-9694472ceceb"), new Guid("ba082277-4b6f-4e86-a922-07353ce4ad13"), "/img/products/abstraction.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("255f76df-5217-4de6-9941-f011ea2042cb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("266ed356-5467-48ac-b1b2-ec3a45ca722a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("50182c2e-8bd1-4d57-9c13-d7f231642d5b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8acc7169-6d98-456d-803e-9694472ceceb"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("7512a027-6c2b-44ec-9dc1-460dc630a1e0"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/stilllife.jpg" },
                    { new Guid("7228b05f-8fb9-4171-a2e9-ab3aaeaf44cd"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/portret.jpg" },
                    { new Guid("7512a027-6c2b-44ec-9dc1-450dc630a1e0"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/landscape.jpg" },
                    { new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), new Guid("a604ee7e-aa0e-4ffc-b596-816570a9bc79"), "/img/products/abstraction.jpg" }
                });
        }
    }
}
