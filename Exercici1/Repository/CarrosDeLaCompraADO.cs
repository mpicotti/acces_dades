using Microsoft.Data.SqlClient;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.Repository
{
    class CarroDeLaCompraADO
    {
        public static void Insert(DatabaseConnection dbConn, CarroDeLaCompra carroCompra)
        {
            dbConn.Open();

            string sql = @"INSERT INTO CarroDeLaCompra (Id, IdCarro, IdProduct, Quantitat)
                           VALUES (@Id, @IdCarro, @IdProduct, @Quantitat)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", carroCompra.Id);
            cmd.Parameters.AddWithValue("@IdCarro", carroCompra.IdCarro);
            cmd.Parameters.AddWithValue("@IdProduct", carroCompra.IdProduct);
            cmd.Parameters.AddWithValue("@Quantitat", carroCompra.Quantitat);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<CarroDeLaCompra> GetAll(DatabaseConnection dbConn)
        {
            List<CarroDeLaCompra> llista = new();

            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                llista.Add(new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1),
                    IdProduct = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3)
                });
            }

            dbConn.Close();
            return llista;
        }

        public static CarroDeLaCompra? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            CarroDeLaCompra? carroCompra = null;

            if (reader.Read())
            {
                carroCompra = new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1),
                    IdProduct = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3)
                };
            }

            dbConn.Close();
            return carroCompra;
        }
    }
}
