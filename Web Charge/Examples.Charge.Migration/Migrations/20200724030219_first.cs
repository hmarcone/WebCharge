using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examples.Charge.Infra.Data.Configuration.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Example",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.BusinessEntityId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.BusinessEntityId);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PhoneNumberTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone", x => new { x.BusinessEntityId, x.PhoneNumber, x.PhoneNumberTypeId });
                    table.ForeignKey(
                        name: "FK_PersonPhone_Person_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalSchema: "dbo",
                        principalTable: "PhoneNumberType",
                        principalColumn: "BusinessEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Example",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Example 1" },
                    { 2, "Example 2" },
                    { 3, "Example 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Person",
                columns: new[] { "BusinessEntityId", "Name" },
                values: new object[] { 1, "User One" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PhoneNumberType",
                columns: new[] { "BusinessEntityId", "Name" },
                values: new object[,]
                {
                    { 1, "Local phone" },
                    { 2, "Cellphone" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "BusinessEntityId", "PhoneNumber", "PhoneNumberTypeId" },
                values: new object[] { 1, "(19)99999-2883", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "BusinessEntityId", "PhoneNumber", "PhoneNumberTypeId" },
                values: new object[] { 1, "(19)99999-4021", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumberTypeId",
                schema: "dbo",
                table: "PersonPhone",
                column: "PhoneNumberTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Example",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonPhone",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PhoneNumberType",
                schema: "dbo");
        }
    }
}
