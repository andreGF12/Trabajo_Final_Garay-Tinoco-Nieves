using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CRUD
{
	public class entEstudiante
	{
		private int id;
		private string p_Nombre;
		private string s_Nombre;
		private string p_Apellido;
		private string s_Apellido;
		private string telefono;
		private string celular;
		private string direccion;
		private string email;
		private DateTime fecha_Nacimiento;
		private string observaciones;

		public int Id
		{
            get { return id; }
			set { id = value; }
        }
		public string P_Nombre
		{
			get { return p_Nombre; }
			set { p_Nombre = value; }
		}
		public string S_Nombre
		{
			get { return s_Nombre; }
            set { s_Nombre = value; }
		}
        public string P_Apellido
        {
            get { return p_Apellido; }
            set { p_Apellido = value; }
        }
        public string S_Apellido
		{
			get { return s_Apellido; }
            set { s_Apellido = value;}
		}
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime F_Nacimiento
        {
            get { return fecha_Nacimiento; }
            set { fecha_Nacimiento = value; }
        }
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
    }
}
