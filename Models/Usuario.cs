using HistoricoApp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoApp.Models
{
    class Usuario
    {
        public int id_usuario {set;get;}
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String email { get; set; }
        public String n_usuario { get; set; }

        public String u_password { get; set; }
        public String celular { get; set; }

        public String foto_perfil { get; set; }

        public String estado { get; set; }

        ConexionBD conectar;

        public Usuario(int id_usuario, string nombre, string apellidos, string email, string n_usuario, string u_password, String celular)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.n_usuario = n_usuario;
            this.u_password = u_password;
            this.celular = celular;
            this.foto_perfil = "sinFoto";
            this.estado = "A";
        }

        public Boolean registrar_usuario() {
            String Query = "insert into usuario(nombres,apellidos,email,usuario,password,celular,fotoPerfil,estado,fkrol)" +
                " values('" + this.nombre + "', '" + this.apellidos + "', '" + this.email + "', '" + this.n_usuario + "', '" + this.u_password + "', '" + this.celular + "',null, '" + this.estado + "', '2'); exec spPadreUsuarioModulo; ";

            conectar = new ConexionBD();

            if (conectar.insertar_BD(Query))
            {
                return true;
            }

            return false;
        }


        public DataTable datos_usuario()
        {
            string queryusuario = "select * from usuario where usuario='" + this.n_usuario + "';";
            DataTable usuariotable = new DataTable();
            conectar = new ConexionBD();
            usuariotable = conectar.consultar_BD(queryusuario);
            if (usuariotable.Rows.Count > 0)
            {
                return usuariotable;
            }
            return null;
        }

        public Boolean Actualizar_NombreUsuario()
        {
            String Query = "update  usuario set usuario='" + this.nombre + "' where usuario='" + this.n_usuario + "';";

            conectar = new ConexionBD();

            if (conectar.insertar_BD(Query))
            {
                return true;
            }

            return false;

        }
        public Boolean Actualizar_datosUsuario()
        {
            String Query = "update  usuario set nombres='" + this.nombre + "',apellidos='" + this.apellidos + "',email='" + this.email + "',celular='" + this.celular + "' where usuario='" + this.n_usuario + "';";
            conectar = new ConexionBD();

            if (conectar.insertar_BD(Query))
            {
                return true;
            }

            return false;

        }
        public Boolean Actualizar_PassUsuario()
        {
            String Query = "update  usuario set  password='" + this.u_password + "' where usuario='" + this.n_usuario + "';";

            conectar = new ConexionBD();

            if (conectar.insertar_BD(Query))
            {
                return true;
            }

            return false;

        }

        public Boolean esta_registradoAsync() {
            String Query = "select usuario,password from usuario where usuario='"+this.n_usuario+"';";
            String Query_p = "select usuario,password from usuario where password='"+this.u_password+"';";

            Boolean activador = false;

            DataTable consulta = new DataTable();
            DataTable consulta1 = new DataTable();
            conectar = new ConexionBD();

            consulta =  conectar.consultar_BD(Query);
            consulta1=  conectar.consultar_BD(Query_p);

        


            if (consulta.Rows.Count > 0)
            {
                activador = true;
            }

            if (consulta1.Rows.Count > 0)
            {
                activador = true;
            }

            return activador;
        
        }

        public int dato_user() {
            String id_usuario = "";
            int id_u = 0;

            DataTable resultado = new DataTable();
            String Query = "select idusuario from usuario where usuario='"+this.n_usuario+"' and estado='A';";

            resultado =  conectar.consultar_BD(Query);

            DataRow fila;
            fila = resultado.Rows[0];

            id_usuario = fila["idusuario"].ToString();
            id_u = Convert.ToInt32(id_usuario);

            return id_u;
        }



        public Boolean verificar_credenciales() {

            Boolean activador = false;

            String Query_user = "select usuario,password from usuario where usuario='" + this.n_usuario + "';";

            String Query_password = "select usuario,password from usuario where password='" + this.u_password + "';";


            DataTable consulta_user = new DataTable();
            DataTable consulta_password = new DataTable();


            conectar = new ConexionBD();


            consulta_user =  conectar.consultar_BD(Query_user);

            DataRow fila;

            if (consulta_user.Rows.Count > 0)
            {
                fila = consulta_user.Rows[0];

                String aux_u = fila["usuario"].ToString();
                String aux_p = fila["password"].ToString();

                if (aux_u.Equals(this.n_usuario) && aux_p.Equals(this.u_password))
                {
                    activador = true;
                }

            }


            consulta_password = conectar.consultar_BD(Query_password);
            DataRow fila1_p;

            if (consulta_password.Rows.Count > 0)
            {
                fila1_p = consulta_password.Rows[0];

                String aux_u = fila1_p["usuario"].ToString();
                String aux_p = fila1_p["password"].ToString();

                if (aux_u.Equals(this.n_usuario) && aux_p.Equals(this.u_password))
                {
                    activador = true;
                }

            }


            return activador;
        }


    }
}
