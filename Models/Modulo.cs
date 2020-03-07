using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HistoricoApp.Models
{
    class Modulo
    {
        public int  id_modulo {get;set;}
        public string nombre { get; set; }

        public string imagen { get; set; }

        ConexionBD conexion;

        public Modulo(int id_modulo, string nombre, string imagen)
        {
            this.id_modulo = id_modulo;
            this.nombre = nombre;
            this.imagen = imagen;

            conexion = new ConexionBD();
        }

        public DataTable consultaBD(int id_usuario) {

            DataTable consulta = null;
            String Query = "select idusuario_modulo, fkmodulo, progreso, nombre, informacion, imagen from usuario_modulo inner join modulo ON fkmodulo = idmodulo where fkusuario ='"+id_usuario+"' AND estado='A';";
            consulta = conexion.consultar_BD(Query);

            return consulta;
        }

        public DataTable contenido() {

            DataTable consulta = null;
            String Query = "select tema.nombre,contenido from tema inner join modulo on tema.fkmodulo = modulo.idmodulo where modulo.nombre='"+this.nombre+"';";
            consulta = conexion.consultar_BD(Query);


            return consulta;
        }


        public DataTable consultar_temaModulo(int fk_modulo) {

            DataTable consulta = new DataTable();
            String Query = "select * from tema where fkmodulo='"+fk_modulo+"';";


            consulta = conexion.consultar_BD(Query);


            return consulta;
        }









        public int consulta_idModulo() {
            DataTable consulta = new DataTable();
            String Query = "select idmodulo from modulo where nombre='"+this.nombre+"';";

            consulta = conexion.consultar_BD(Query);
            int id = 0;

            foreach (DataRow fila in consulta.Rows)
            {
                id = Convert.ToInt32(fila["idmodulo"].ToString());
            }


                return id;
        }

    }
}
