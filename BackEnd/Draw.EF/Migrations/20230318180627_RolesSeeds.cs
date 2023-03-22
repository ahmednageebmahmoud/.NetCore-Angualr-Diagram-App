using Draw.Core.Consts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Draw.EF.Migrations
{
    public partial class RolesSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    table: "AspNetRoles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new[] { Guid.NewGuid().ToString(), "User", RoleConst.User, Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
                    table: "AspNetRoles",
                    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                    values: new[] { Guid.NewGuid().ToString(), "Admin", RoleConst.Admin, Guid.NewGuid().ToString() }
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles");
        }
    }
}
