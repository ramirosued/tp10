using System.Data.SqlClient;
using Dapper;

using System.Collections.Generic;

public static class BD
{
    private static string connectionString = @"Server=localhost;DataBase=BDSeries;Trusted_Connection=True;";
    static List<Series> ListaSeries = new List<Series>();
static List<string> ListaTemporadasSeries = new List<string>();
    static List<string> ListaActoresSeries = new List<string>();



    public static List<Series> TraerSeries()
    {
        using (SqlConnection BD = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Series";
            ListaSeries = BD.Query<Series>(sql).ToList();
        }
        return ListaSeries;
    }

    public static Series GetSerie(int id)
    {
        Series Serie;
        using (SqlConnection BD = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Series where IdSerie = @IdSerie";
            Serie = BD.QueryFirstOrDefault<Series>(sql, new { IdSerie = id });
        }
        return Serie;
    }

     public static List<string> GetTemporadas(int id)
    {
        using (SqlConnection BD = new SqlConnection(connectionString))
        {
            string sql = "SELECT TituloTemporada FROM Temporadas where IdSerie = @IdSerie";
            ListaTemporadasSeries = BD.Query<string>(sql, new { IdSerie = id }).ToList();
        }
        return ListaTemporadasSeries;
    }


     public static List<string> GetActores(int id)
    {
        using (SqlConnection BD = new SqlConnection(connectionString))
        {
            string sql = "SELECT Nombre FROM Actores where IdSerie = @IdSerie";
            ListaActoresSeries = BD.Query<string>(sql, new { IdSerie = id }).ToList();
        }
        return ListaActoresSeries;
    }
}
