using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Employee_API.Model;

namespace Employee_API.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20220718103735_StoreProcedure")]
    public class StoreProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Resource.GetEmployees_Proc);
            migrationBuilder.Sql(Resource.CreateEmployees_Proc);
            migrationBuilder.Sql(Resource.UpdateEmployees_Proc);
            migrationBuilder.Sql(Resource.DeleteEmployees_Proc);
        }
    }
}
