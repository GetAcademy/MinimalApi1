using System.Data.SqlClient;
using Dapper;
using WebApplication2.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TerjeTest;Integrated Security=True";
app.MapGet("/measurement", async () =>
{
    var conn = new SqlConnection(connStr);
    var sql = "select * from measurement";
    var measurements = await conn.QueryAsync<Measurement>(sql);
    return measurements;
});
app.MapPost("/measurement", async (Measurement measurement) =>
{
    var conn = new SqlConnection(connStr);
    var sql = @"insert into measurement values (@Id, @MeasurePointId, @PersonId, @Value, @TimeStamp)";
    var rowsAffected = await conn.ExecuteAsync(sql, measurement);
    return rowsAffected;
});
app.UseStaticFiles();
app.Run();

