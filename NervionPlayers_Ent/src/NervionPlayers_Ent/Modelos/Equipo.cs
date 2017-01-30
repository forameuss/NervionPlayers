﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class Equipo
    {
        private int id;
        private int id_Creador;
        private String nombre;
        private DateTime fecha_Creacion;
        private Byte[] foto;
        private bool confirmado;

        public Equipo()
        {

        }
        public Equipo(int id, int id_Creador, string nombre, DateTime fecha_Creacion, byte[] foto, bool confirmado)
        {
            Id = id;
            Id_Creador = id_Creador;
            Nombre = nombre;
            Fecha_Creacion = fecha_Creacion;
            Foto = foto;
            Confirmado = confirmado;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Id_Creador
        {
            get
            {
                return id_Creador;
            }

            set
            {
                id_Creador = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public DateTime Fecha_Creacion
        {
            get
            {
                return fecha_Creacion;
            }

            set
            {
                fecha_Creacion = value;
            }
        }

        public byte[] Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        public bool Confirmado
        {
            get
            {
                return confirmado;
            }

            set
            {
                confirmado = value;
            }
        }
    }
}
