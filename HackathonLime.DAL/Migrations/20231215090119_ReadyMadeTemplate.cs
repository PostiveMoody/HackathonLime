using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HackathonLime.DAL.Migrations
{
    public partial class ReadyMadeTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "FilmIdSequence",
                minValue: 1L,
                maxValue: 100000L);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Film",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"FilmIdSequence\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "FilmIdSequence");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Film",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"FilmIdSequence\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
