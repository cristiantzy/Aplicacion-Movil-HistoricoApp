using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HistoricoApp.Models
{
    class Ranking
    {

        public int idpuntuacion { get; set; }
        public int puntaje { get; set; }
        public int fkusuario { get; set; }
        public TimeSpan tiempo { get; set; }

        ConexionBD Connection = new ConexionBD();

        
        public Ranking(int idpuntuacion, int puntaje, int fkusuario, TimeSpan tiempo)
        {
            this.idpuntuacion = idpuntuacion;
            this.puntaje = puntaje;
            this.fkusuario = fkusuario;
            this.tiempo = tiempo;
        }

        public Ranking()
        {
        }

        public DataTable consultarRanking()
        {
            
             return Connection.consultar_BD("SELECT u.nombres, u.apellidos, u.email, r.idpuntuacion, r.puntaje, r.tiempo FROM ranking r INNER JOIN usuario u ON r.fkusuario = u.idusuario ORDER BY r.puntaje DESC");


        }

       
    }
}
