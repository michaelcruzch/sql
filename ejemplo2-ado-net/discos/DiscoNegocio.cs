using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace discos
{
    internal class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco>lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, D.CantidadCanciones, UrlImagenTapa , E.Descripcion Estilo, T.Descripcion TipoEdicion from DISCOS D, ESTILOS E , TIPOSEDICION T Where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.estilo = new Estilo();
                    aux.estilo.Descripcion = (string)lector["Estilo"];
                    aux.TipoEdicion = new Estilo();
                    aux.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];

                    lista.Add(aux);

                }


                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

    }
}
