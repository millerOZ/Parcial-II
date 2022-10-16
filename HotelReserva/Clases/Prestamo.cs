using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelReserva.Modelos;
using libComunes.CapaDatos; //Hacer la conexión a la base de datos

namespace HotelReserva.Clases
{
    public class clsPrestamo
    {
        public Prestamo prestamo { get; set; }
        public string Insertar()
        {
            //Invocar el método insertar
            //Método para grabar en la base de datos
            string SQL = "Prestamo_Insertar"; //Nombre del procedimiento almacenado

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;//Para indicar que es un procedimiento almacenado
            oConexion.AgregarParametro("@prNombre", prestamo.Nombre);
            oConexion.AgregarParametro("@prDocumento", prestamo.Documento);
            oConexion.AgregarParametro("@prApellidos", prestamo.Apellidos);
            oConexion.AgregarParametro("@prTelefono", prestamo.Telefono);
            oConexion.AgregarParametro("@prEmail", prestamo.Email);
            oConexion.AgregarParametro("@prlibro", prestamo.Libro);
            oConexion.AgregarParametro("@prFechaPrestamo", prestamo.FechaPrestamo);
            oConexion.AgregarParametro("@prFechaDevolucion", prestamo.FechaDevolucion);

            if (oConexion.EjecutarSentencia())
            {
                return "Se insertó el prestamo en la base de datos";
            }
            else
            {
                prestamo.Error = oConexion.Error;
                return prestamo.Error;
            }
        }
       
    }
}