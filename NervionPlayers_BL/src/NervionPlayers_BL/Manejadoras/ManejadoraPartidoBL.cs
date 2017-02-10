

using NervionPlayers_BL.Model;
/**
* No se insertará en BBDD las fecha de Creación
* Fecha de partido posterior a fecha de creación
* lugar menor igual 30
* El equipo local y visitante deberán pertencer a la misma categoría
*/
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    

    public class ManejadoraPartidoBL
    {
        #region Var & Const

        private ManejadoraPartidoDAL manejadora;

        #endregion

        #region Constructores
        
        /// <summary>
        /// Inicializa <see cref="ManejadoraPartidoDAL"/>
        /// </summary>
        public ManejadoraPartidoBL()
        {
            manejadora = new ManejadoraPartidoDAL();
        }

        #endregion


        /// <summary>
        /// Obtiene un partido desde su id
        /// </summary>
        /// <param name="id">id del partido</param>
        /// <returns>El objeto partido o nulo</returns>
        public Partido obtenerPartido(int id)
        {
            return manejadora.obtenerPartido(id);
        }

        /// <summary>
        /// Inserta un partido en caso de cumplir los requisitos. Lugar Menor o igual que 30 y Fecha partido mayor que creacion.
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de no cumplir los requisitos</exception>
        /// <param name="partido">Objeto partido</param>
        /// <returns>Vaor devuelto por <see cref="ManejadoraPartidoDAL.insertarPartido(Partido)"/></returns>
        public int insertarPartido(Partido partido)
        {

            if (partido.Lugar.Length > 30)
                throw new InvalidValueException("El lugar del partido es mayor de lo permitido (30)");

            if (partido.Fecha_Partido < DateTime.Now)
                throw new InvalidValueException("La fecha del partido es inferior a la fecha de creacion");

            if (isEquiposValid(partido.Id_Local, partido.Id_Visitante))
                throw new InvalidValueException("El id local y el id visitante no pertenecen a la misma categoria");

            return manejadora.insertarPartido(partido);
        }

        /// <summary>
        /// Borra un partido por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraPartidoDAL.borrarPartido(int)"/></returns>
        public int borrarPartido(int id)
        {
            return manejadora.borrarPartido(id);
        }

        /// <summary>
        /// Actualiza un duelo si cumple con los requisitos.  Lugar Menor o igual que 30 y Fecha partido mayor que creacion.
        /// </summary>
        /// <exception cref="InvalidValueException">Si no cunple los requisitos</exception>
        /// <param name="partido">Objeto duelo actualizado</param>
        /// <returns>Valor devuelto por <see cref="ManejadoraPartidoDAL.actualizarPartido(Partido)"/></returns>
        public int actualizarPartido(Partido partido)
        {

            if (partido.Lugar.Length > 30)
                throw new InvalidValueException("El lugar del partido es mayor de lo permitido (30)");

            if (partido.Fecha_Partido < DateTime.Now)
                throw new InvalidValueException("La fecha del partido es inferior a la fecha de creacion");

            return manejadora.actualizarPartido(partido);
        }

        /// <summary>
        /// Comprueba tras una llamada a <see cref="ManejadoraPartidoDAL.obtenerPartido(int)"/> si los equipos son de la misma categoria o no.
        /// </summary>
        /// <param name="id_Local"></param>
        /// <param name="id_Visitante"></param>
        /// <returns>True o False en caso de ser o no valido</returns>
        private bool isEquiposValid(int id_Local, int id_Visitante)
        {
            bool isvalid = false;
            ManejadoraEquipoDAL manejadoraEquipo = new ManejadoraEquipoDAL();

            Equipo eLocal = manejadoraEquipo.obtenerEquipo(id_Local);
            Equipo eVisitante = manejadoraEquipo.obtenerEquipo(id_Visitante);

            if (eLocal.Categoria == eVisitante.Categoria)
                isvalid = true;


            return isvalid;
        }
    }
}
