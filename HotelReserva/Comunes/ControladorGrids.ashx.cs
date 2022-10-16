using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using libComunes.CapaObjetos;
namespace HotelReserva.Comunes
{
    /// <summary>
    /// Summary description for ControladorGrids
    /// </summary>
    public class ControladorGrids : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String DatosGrid;

            StreamReader reader = new StreamReader(context.Request.InputStream);
            DatosGrid = reader.ReadToEnd();

            viewGrid oGrid = JsonConvert.DeserializeObject<viewGrid>(DatosGrid);

            string Respuesta;

            switch (oGrid.Comando)
            {
                case "TABLAPRESTAMOS":
                    Respuesta = LlenarGrid(oGrid, "Prestamo_LlenarGrid");
                    break;
              
                default:
                    Respuesta = "Sin definir";
                    break;
            }
            context.Response.ContentType = "application/json";

            context.Response.Write(Respuesta);
        }
        private string LlenarGrid(viewGrid oGrid, string SQL)
        {
            oGrid.SQL = SQL;
            clsGridListas oGridListas = new clsGridListas();
            oGridListas.oGrid = oGrid;
            return JsonConvert.SerializeObject(oGridListas.ListarGrid());
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