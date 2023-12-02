using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Negocio
{
    public class AccesoDB
    {
        private SqlConnection _conexion;
        private SqlCommand _comando;
        private SqlDataReader _lector;
        public SqlDataReader Lector
        {
            get { return _lector; }
        }

        public AccesoDB()
        {
            //_conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            
            string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
            
            _conexion = new SqlConnection(connectionString);
            _comando = new SqlCommand();
        }

        public void CerrarConexion()
        {
            if (_lector != null)
                _lector.Close();
            _conexion.Close();
        }
        public void SetQuery(string consulta)
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.CommandText = consulta;
        }

        public void SetParameter(string nombre, object valor)
        {
            _comando.Parameters.AddWithValue(nombre, valor);
        }
        public void SetProcedure(string sp)
        {
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.CommandText = sp;
        }

        public void EjecutarAccion()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EjecutarLectura()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _lector = _comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EjecutarScalar()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();

                object id = _comando.ExecuteScalar();
                string stringId = id.ToString();
                int idNuevo = Convert.ToInt32(stringId);

                return idNuevo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
