using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2_form
{
    class ConexionMysql
    {
        MySqlConnection conexion;

        static string server = "localhost";
        static string database = "practica2";
        static string uid = "root";
        static string password = "";
        public static string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        // Abrir la conexión a la BD
        public bool Open()
        {
            try
            {
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                conexion = new MySqlConnection(connectionString);
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            return false;
        }

        // Cerrar conexión
        public void Close()
        {
            conexion.Close();
            conexion.Dispose();
        }

        // Método para insertar en la BD un nuevo registro
        public bool AgregarDistribuidor(string id, string nombre, string paterno, string materno, string calle, string numero, string colonia)
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                // Las operaciones a la BD se encierran en bloques try-catch 
                // Si ocurre algún error (excepción), la aplicación lo mostrará
                try
                {
                    // Se usan parámetros en el query para evitar la inyección SQL
                    string query = "INSERT INTO distributors (id, fecha_registro) VALUES (@id, @fecha);" +
                        "INSERT INTO persons (id, nombre, ap_paterno, ap_materno) VALUES (@id, @nombre, @paterno, @materno);" +
                        "INSERT INTO addresses (id, calle, num_casa, colonia) VALUES (@id, @calle, @numero, @colonia);";                   

                    cn.Open();

                    // Yet again, we are creating a new object that implements the IDisposable
                    // interface. So we create a new using statement.
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        // Asignar valores de los parámetros
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@paterno", paterno);
                        cmd.Parameters.AddWithValue("@materno", materno);
                        cmd.Parameters.AddWithValue("@calle", calle);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@colonia", colonia);

                        // Ejecutar
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    // Si todo se insertó correctamente, se regresa el valor 'true'
                    return true;
                }
                catch (MySqlException)
                {
                    // Si hubo algún error, se retorna 'false'
                    return false;
                }
            }
        }

        // Método para consultar un distribuidor, usando un procedimiento almacenado
        public System.Data.DataTable ConsultaDistribuidor(string procedimiento, params MySqlParameter[] datos)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(datos); // Parámetro (código del distribuidor)

                        connection.Open();

                        // Regresa una tabla
                        DataTable dt = new DataTable();
                        dt.Load(command.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (MySqlException)
            {
                return null;
            }
        }


    }
}
