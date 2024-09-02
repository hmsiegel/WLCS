﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WLCS.Modules.Competitions.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "competitions");

            migrationBuilder.CreateTable(
                name: "meets",
                schema: "competitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    venue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "athletes",
                schema: "competitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    membership = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    club = table.Column<string>(type: "text", nullable: true),
                    coach = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_athletes", x => x.id);
                    table.ForeignKey(
                        name: "fk_athletes_meets_meet_id",
                        column: x => x.meet_id,
                        principalSchema: "competitions",
                        principalTable: "meets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competitions",
                schema: "competitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    scope = table.Column<int>(type: "integer", nullable: false),
                    competition_type = table.Column<int>(type: "integer", nullable: false),
                    age_division = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_competitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_competitions_meets_meet_id",
                        column: x => x.meet_id,
                        principalSchema: "competitions",
                        principalTable: "meets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "athlete_competition",
                schema: "competitions",
                columns: table => new
                {
                    athletes_id = table.Column<Guid>(type: "uuid", nullable: false),
                    competition_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_athlete_competition", x => new { x.athletes_id, x.competition_id });
                    table.ForeignKey(
                        name: "fk_athlete_competition_athletes_athletes_id",
                        column: x => x.athletes_id,
                        principalSchema: "competitions",
                        principalTable: "athletes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_athlete_competition_competitions_competition_id",
                        column: x => x.competition_id,
                        principalSchema: "competitions",
                        principalTable: "competitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_athlete_competition_competition_id",
                schema: "competitions",
                table: "athlete_competition",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "ix_athletes_meet_id",
                schema: "competitions",
                table: "athletes",
                column: "meet_id");

            migrationBuilder.CreateIndex(
                name: "ix_competitions_meet_id",
                schema: "competitions",
                table: "competitions",
                column: "meet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "athlete_competition",
                schema: "competitions");

            migrationBuilder.DropTable(
                name: "athletes",
                schema: "competitions");

            migrationBuilder.DropTable(
                name: "competitions",
                schema: "competitions");

            migrationBuilder.DropTable(
                name: "meets",
                schema: "competitions");
        }
    }
}
