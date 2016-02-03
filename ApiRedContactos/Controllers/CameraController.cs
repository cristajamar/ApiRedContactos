using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRedContactos.Utils;
using ContactosModel.Model;

namespace ApiRedContactos.Controllers
{
    public class CameraController : ApiController
    {
        [ResponseType(typeof (String))]

        public IHttpActionResult Post(FotosModel model)
        {
            //recuperamos los datos y credenciales de Azure Storage
            var cuenta = ConfigurationManager.AppSettings["cuenta"];
            var clave = ConfigurationManager.AppSettings["clave"];
            var contenedor = ConfigurationManager.AppSettings["contendor"];

            //Creamos la cuenta
            var sto=new AzureStorageUtils(cuenta,clave,contenedor);
            //Generamos el nombre del fichero con un Guid
            var nombre = Guid.NewGuid() + ".jpg";

            //Subumos el fichero convirtiendolo de base64 a un array de byte
            sto.SubirFichero(Convert.FromBase64String(model.Datos),nombre);

            return Ok(nombre);
        }
    }
}
