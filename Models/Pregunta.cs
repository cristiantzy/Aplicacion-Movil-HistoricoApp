using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HistoricoApp.Models
{
    class Pregunta
    {
        private String Preguntas;
        private String OpcA;
        private String OpcB;
        private String OpcC;
        private String OpcD;
        private String PCorr;

        public string Preguntas1 { get => Preguntas; set => Preguntas = value; }
        public string OpcA1 { get => OpcA; set => OpcA = value; }
        public string OpcB1 { get => OpcB; set => OpcB = value; }
        public string OpcC1 { get => OpcC; set => OpcC = value; }
        public string OpcD1 { get => OpcD; set => OpcD = value; }
        public string PCorr1 { get => PCorr; set => PCorr = value; }

        ConexionBD conectar = new ConexionBD();


        public Pregunta(string preguntas, string opcA, string opcB, string opcC, string opcD, string pCorr)
        {
            this.Preguntas = preguntas;
            this.OpcA = opcA;
            this.OpcB = opcB;
            this.OpcC = opcC;
            this.OpcD = opcD;
            this.PCorr = pCorr;
        }

        public Pregunta()
        {
        }

        public DataTable consultarPreguntas(int fktema)
        {

            DataTable consulta = new DataTable();
            string sql = "select top 12 * from pregunta where fkmodulo = '"+fktema+"' Order by newid();";
            consulta=  conectar.consultar_BD(sql);

            return consulta;
        }
        public DataTable consultartemaPreguntas(int fktema)
        {
            string sql = "select  * from modulo where idmodulo= '"+fktema+"';";
             return conectar.consultar_BD(sql);
         
        }

        public DataTable consultarPreguntas()
        {

            DataTable consulta = new DataTable();
            string sql = "select top 12 * from pregunta Order by newid();";
            consulta = conectar.consultar_BD(sql);

            return consulta;
        }



    }
}
