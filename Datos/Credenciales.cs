using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Datos
{
    public class Credenciales
    {
        private readonly string _connectionString;

        public Credenciales()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }

        public bool Add(string nombre, string usuario, string password, int idcategoria)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO credenciales" +
                    " (nombre, usuario, password, idcategoria)" +
                    " VALUES (@nombre, @usuario, @password, @idcategoria)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@idcategoria", idcategoria);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }

        public DataTable Get()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT cre.*, ca.nombre as categoria" +
                    " FROM credenciales cre" +
                    " INNER JOIN categorias ca ON cre.idcategoria = ca.id", conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM credenciales WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filesAffected = cmd.ExecuteNonQuery();
                    return filesAffected > 0;
                }
            }
        }
    }
}
