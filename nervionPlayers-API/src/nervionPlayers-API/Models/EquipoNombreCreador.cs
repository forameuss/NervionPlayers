using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nervionPlayers_API.Models
{
    public class EquipoNombreCreador : Equipo
    {
        private String nombreCreador;

        public EquipoNombreCreador(Equipo equipo, String nombreCreador)
        {
            this.Id = equipo.Id;
            this.Id_Creador = equipo.Id_Creador;
            this.Categoria = equipo.Categoria;
            this.Nombre = equipo.Nombre;
            this.Fecha_Creacion = equipo.Fecha_Creacion;
            this.Foto = equipo.Foto;
            this.Confirmado = equipo.Confirmado;

            this.nombreCreador = nombreCreador;
        }

        public string NombreCreador
        {
            get
            {
                return nombreCreador;
            }

            set
            {
                nombreCreador = value;
            }
        }
    }
}
