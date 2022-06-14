using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.Migrations
{
    public partial class DatosIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("69d20de1-4182-4ce6-98d5-a73d2a50511a"), "Son actividades que necesitan ser terminadas", "Actividades en Espera", 30 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("69d20de1-4182-4ce6-98d5-a73d2a505120"), "Son actividades que estan terminadas", "Actividades terminadas", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("69d20de1-4182-4ce6-98d5-a73d2a505110"), new Guid("69d20de1-4182-4ce6-98d5-a73d2a50511a"), "Terminar toda la escuela de C# en platzi hasta fin de mes", new DateTime(2022, 6, 13, 22, 8, 21, 471, DateTimeKind.Local).AddTicks(6276), 2, "Terminar curso de platzi en c#" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("69d20de1-4182-4ce6-98d5-a73d2a505130"), new Guid("69d20de1-4182-4ce6-98d5-a73d2a505120"), "Ingresar los certificados obtenidos en platzi al CV", new DateTime(2022, 6, 13, 22, 8, 21, 471, DateTimeKind.Local).AddTicks(6294), 1, "Terminar CV de programador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("69d20de1-4182-4ce6-98d5-a73d2a505110"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("69d20de1-4182-4ce6-98d5-a73d2a505130"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("69d20de1-4182-4ce6-98d5-a73d2a50511a"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("69d20de1-4182-4ce6-98d5-a73d2a505120"));
        }
    }
}
