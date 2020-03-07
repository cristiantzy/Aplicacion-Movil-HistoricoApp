using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HistoricoApp.Models
{
    class Tema
    {
        public int id_tema { get; set; }
        public String icon { get; set; }
        public String nombre { get; set; }

        public String descripcion { get; set; }
        public String contenido { get; set; }


        public String url_video { get; set; }

        public String estado {get;set;}

        public int fk_modulo { get; set; }

        public bool IsVisible { get; set; }


        ConexionBD conectar = new ConexionBD();

        public DataTable lista_tema(int id_modulo) {
            DataTable consulta = new DataTable();

            String Query = "select * from tema where fkmodulo='"+id_modulo+"' and estado='A';";
            consulta = conectar.consultar_BD(Query);


            return consulta;

        }


    }
}
