using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class ESTUDIANTE : Form
    {
        public ESTUDIANTE()
        {
            InitializeComponent();
            ListarEstudiante();
        }
        public void LimpiarEntradas()
        {
        
        }
        private void ListarEstudiante()
        {
            SqlCommand cmd = null;
            List<entEstudiante> lista = new List<entEstudiante>(); 
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                string sql = "Select *from Estudiante";
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entEstudiante Est = new entEstudiante
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        P_Nombre = dr["p_Nombre"].ToString(),
                        S_Nombre = dr["s_Nombre"].ToString(),
                        P_Apellido = dr["p_Apellido"].ToString(),
                        S_Apellido = dr["s_Apellido"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Celular = dr["celular"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Email = dr["email"].ToString(),
                        F_Nacimiento = Convert.ToDateTime(dr["fecha_Nacimiento"]),
                        Observaciones = dr["observaciones"].ToString(),

                    };
                    lista.Add(Est);
                }
                dgvListaEstudiante.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region CRUD
        private void btnCrear_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                entEstudiante Est = new entEstudiante
                {
                    Id = Convert.ToInt16(txtId.Text),
                    P_Nombre = txtP_Nombre.Text,
                    S_Nombre = txtS_Nombre.Text,
                    P_Apellido = txtP_Apellido.Text,
                    S_Apellido = txtS_Apellido.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    F_Nacimiento = dtpFecha_Nacimiento.Value,
                    Observaciones = txtObservaciones.Text,

                };
                SqlConnection cn = Conexion.Instancia.Conectar();
                string sql = "insert into estudiante values('"+Est.P_Nombre+"', '"+Est.S_Nombre+"', '"+Est.P_Apellido+"', '"+Est.S_Apellido+"', " +
                    "'"+Est.Telefono+"', '"+Est.Celular+"', '"+Est.Direccion+"', '"+Est.Email+"', " +
                    "'"+Est.F_Nacimiento+"', '"+Est.Observaciones+"');";
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ListarEstudiante();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private void dgvListaEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgvListaEstudiante.Rows[e.RowIndex];
                txtId.Text = fila.Cells[0].Value.ToString();
                txtP_Nombre.Text = fila.Cells[1].Value.ToString();
                txtS_Nombre.Text = fila.Cells[2].Value.ToString();
                txtP_Apellido.Text = fila.Cells[3].Value.ToString();
                txtS_Apellido.Text = fila.Cells[4].Value.ToString();
                txtTelefono.Text = fila.Cells[5].Value.ToString();
                txtCelular.Text = fila.Cells[6].Value.ToString();
                txtDireccion.Text = fila.Cells[7].Value.ToString();
                txtEmail.Text = fila.Cells[8].Value.ToString();
                dtpFecha_Nacimiento.Value = Convert.ToDateTime(fila.Cells[9].Value);
                txtObservaciones.Text = fila.Cells[10].Value.ToString();

            }
            catch (Exception)
            {

            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)//El actualizar es lo mismo que el crear sino que se le manda el id
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                entEstudiante Est = new entEstudiante
                {
                    Id = Convert.ToInt16(txtId.Text),
                    P_Nombre = txtP_Nombre.Text,
                    S_Nombre = txtS_Nombre.Text,
                    P_Apellido = txtP_Apellido.Text,
                    S_Apellido = txtS_Apellido.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text,
                    Direccion = txtDireccion.Text,
                    Email = txtEmail.Text,
                    F_Nacimiento = dtpFecha_Nacimiento.Value,
                    Observaciones = txtObservaciones.Text,

                };
                SqlConnection cn = Conexion.Instancia.Conectar();
                string sql = "update estudiante set p_Nombre = '"+Est.P_Nombre+ "', s_Nombre = '"+Est.S_Nombre+ "', p_Apellido = '"+Est.P_Apellido+ "', s_Apellido = '"+Est.S_Apellido+ "', telefono = '"+Est.Telefono+"', " +
                    "celular = '"+Est.Celular+ "', direccion = '"+Est.Direccion+ "',email = '"+Est.Email+ "', fecha_Nacimiento = '"+Est.F_Nacimiento+ "', observaciones = '"+Est.Observaciones+ "' where id = '"+Est.Id+"';";
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ListarEstudiante();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                string sql = "delete from estudiante where id = " + txtId.Text;
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)//Si es que existieron filas afectadas
                {
                    ListarEstudiante();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        #endregion CRUD

        private void dgvListaEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
