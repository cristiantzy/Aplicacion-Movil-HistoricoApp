using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HistoricoApp.Models
{
    class UsuarioModulo
    {

        public int idusuario_modulo { get; set; }
        public int fkusuario { get; set; }
        public int fkmodulo { get; set; }
        public int progreso { get; set; }

        ConexionBD conexion;



        public UsuarioModulo(int idusuario_modulo, int fkusuario, int fkmodulo, int progreso)
        {
            this.idusuario_modulo = idusuario_modulo;
            this.fkusuario = fkusuario;
            this.fkmodulo = fkmodulo;
            this.progreso = progreso;

        }

    
        public Boolean Actualizar_progreso()
        {
            String Query = "UPDATE usuario_modulo SET progreso ='" + this.progreso + "' WHERE fkusuario = '" + this.fkusuario + "' and fkmodulo = '" + this.fkmodulo + "'; ";

            conexion = new ConexionBD();

            if (conexion.insertar_BD(Query))
            {
                return true;
            }

            return false;

        }
        public DataTable datos_usuario_modulo()
        {
            string queryusuario = "Select * from usuario_modulo WHERE fkusuario = '" + this.fkusuario + "' and fkmodulo = '" + this.fkmodulo + "'; ";
            DataTable usuariotable = new DataTable();
            conexion = new ConexionBD();
            usuariotable = conexion.consultar_BD(queryusuario);
            if (usuariotable.Rows.Count > 0)
            {
                return usuariotable;
            }
            return usuariotable;
        }
    }
}
