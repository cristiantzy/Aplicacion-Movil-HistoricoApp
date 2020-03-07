using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoApp.Connection
{
    class ConexionBD
    {
        public String cadena_conexion;
        public SqlConnection connect;
        public SqlCommand comando;
        public SqlDataReader reader;
        public String mensaje;


        public ConexionBD()
        {
             // cadena_conexion = @"data source=192.168.1.9;initial catalog=Empresa;user id=root;password=root;Connect Timeout=60";

            cadena_conexion = @"data source=192.168.43.95;initial catalog=softwareeducativobd;user id=historico;password=root;Connect Timeout=60";
            connect = new SqlConnection(cadena_conexion);
            comando = new SqlCommand();
            mensaje = "";



        }

        public Boolean OpenConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public Boolean CloseConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }




        public Boolean existe_en_BD(String Query)
        {
            Boolean respuesta = false;
            if (OpenConnection())
            {
                try
                {
                    comando.Connection = connect;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = Query;

                    try
                    {
                        object consulta_BD = comando.ExecuteScalar().ToString();
                        //estado_empresa = Convert.ToInt32(consulta_BD);

                        if (consulta_BD.Equals(""))
                        {
                            // NO esta en la lista
                            respuesta = false;
                        }
                        else
                        {
                            // SI esta en la lista
                            respuesta = true;
                        }
                        CloseConnection();
                    }
                    catch
                    {
                        return false;
                    }
                }
                catch { }
            }
            else
            {
                respuesta = false;

            }
            return respuesta;
        }


        public Boolean insertar_BD(String query)
        {

            if (this.OpenConnection())
            {
                try
                {
                    comando.Connection = connect;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = query;

                    try
                    {
                        comando.ExecuteNonQuery();
                        CloseConnection();
                        return true;
                    }
                    catch
                    {

                        mensaje = "Error en la ejecucion de la consulta";
                    }
                }
                catch
                {
                    mensaje = "Error en la consulta";
                }
            }
            else
            {
                mensaje = "Error en la conexion";
            }
            return false;
        }


        public DataTable consultar_BD(String Query)
        {
            DataTable consulta = new DataTable();
            if (OpenConnection())
            {
                comando.Connection = connect;
                comando.CommandType = CommandType.Text;
                comando.CommandText = Query;
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                     adaptador.Fill(consulta);

                    CloseConnection();
                }
                catch { }
            }
            return consulta;
        }

    }
}
