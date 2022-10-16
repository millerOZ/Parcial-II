using HotelReserva.Clases;
using HotelReserva.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HotelReserva.Controladores
{
    /// <summary>
    /// Summary description for BibliotecaControlador
    /// </summary>
    public class BibliotecaControlador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosPrestamo;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosPrestamo = reader.ReadToEnd();
               

                Prestamo prestamo = JsonConvert.DeserializeObject<Prestamo>(DatosPrestamo);

                context.Response.Write(ProcesarComando(prestamo));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        private string ProcesarComando(Prestamo prestamo)
        {
            clsPrestamo oPrestamo = new clsPrestamo();
            oPrestamo.prestamo = prestamo;
            switch (prestamo.Comando.ToUpper())
            {
                case "INSERTAR":
                    return oPrestamo.Insertar();
             
                default:
                    return "No se ha definido el comando";
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}