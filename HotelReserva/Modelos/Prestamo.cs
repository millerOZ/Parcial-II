using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReserva.Modelos
{
    public class Prestamo
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
  
        public string Error { get; set; }
        public string Comando { get; set; }
    }
}