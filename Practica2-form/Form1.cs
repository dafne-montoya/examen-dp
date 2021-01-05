using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2_form
{
    public partial class frmDist : Form //herencia de la Clase Windows.Forms
    {
        //mi conexion
        ConexionMysql conexion = new ConexionMysql();

        public frmDist() //constructor
        {
            InitializeComponent();
        }

        // Función para guardar un nuevo registro
        private void Button1_Click(object sender, EventArgs e)
        {
            if (conexion.AgregarDistribuidor(txtID.Text, txtNombre.Text, txtPaterno.Text, 
                txtMaterno.Text, txtCalle.Text, txtNum.Text, txtColonia.Text) == true)
            {
                MessageBox.Show("¡Nuevo distribuidor agregado exitosamente!");
            }
            else
            {
                MessageBox.Show("Ocurrió un error");
            }
        }

        // Función para consultar un registro
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            // Se le pide al usuario que ingrese el ID para buscarlo en la BD
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el ID del distribuidor",
                       "Consulta de distribuidor", "", 0, 0);

            // Si no se dejó vacío el cuadro de texto
            if(input != "")
            {
                // Busca en la Base de datos y muestra el resultado en una Tabla
                DataTable datos = conexion.ConsultaDistribuidor("consulta_distribuidor", new MySqlParameter("id_dist", input));

                BindingSource SBind = new BindingSource();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = SBind;

                for (int i = 0; i < dataGridView1.ColumnCount; ++i)
                {
                    datos.Columns.Add(new DataColumn(dataGridView1.Columns[i].Name));
                    dataGridView1.Columns[i].DataPropertyName = dataGridView1.Columns[i].Name;
                }

                dataGridView1.DataSource = datos;

            }

        }
    }
}
