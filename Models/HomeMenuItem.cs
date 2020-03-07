using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricoApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Perfil,
        Inicio,
        Instrucciones,
        ModulosTematicos,
        TestdelConocimiento,
        Ranking,
        Configuracion,

        Salir
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string NamePage { get; set; }
    }
}
