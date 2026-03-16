using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Subscriber.Infraestructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscription_plan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    monthly_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    days_to_expire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscription_plan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subscriber",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    subscription_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    subscription_plan_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriber", x => x.id);
                    table.ForeignKey(
                        name: "fk_subscriber_subscription_plan_subscription_plan_id",
                        column: x => x.subscription_plan_id,
                        principalTable: "subscription_plan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "subscription_plan",
                columns: new[] { "id", "created_at", "days_to_expire", "monthly_price", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 16, 21, 3, 41, 951, DateTimeKind.Utc).AddTicks(826), 30, 29.90m, "Basic", 1, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 16, 21, 3, 41, 951, DateTimeKind.Utc).AddTicks(832), 30, 59.90m, "Premium", 1, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 16, 21, 3, 41, 951, DateTimeKind.Utc).AddTicks(835), 30, 99.90m, "Enterprise", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_subscriber_email",
                table: "subscriber",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subscriber_subscription_plan_id",
                table: "subscriber",
                column: "subscription_plan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriber");

            migrationBuilder.DropTable(
                name: "subscription_plan");
        }
    }
}
