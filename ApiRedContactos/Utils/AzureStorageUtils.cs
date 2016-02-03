using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace ApiRedContactos.Utils
{
    public class AzureStorageUtils
    {

        //propiedades para la conexión a Azure Storage
        private CloudStorageAccount _cuenta; //Objeto que almacena la cuenta
        private String _contenedor;

        public AzureStorageUtils(String cuenta, String clave, String contenedor)
        {
            StorageCredentials cred = new StorageCredentials(cuenta, clave); //para consturirlo necesitmos pasarle las credenciales
            _cuenta = new CloudStorageAccount(cred, true);
            _contenedor = contenedor;
        }

        private void ComprobarContenedor(String contenedor = null)
        {
            if (contenedor != null)
            {
                _contenedor = contenedor;
            }

            var cliente = _cuenta.CreateCloudBlobClient();
            var cont = cliente.GetContainerReference(_contenedor);
            cont.CreateIfNotExists();

        }

        //le tenemos que pasar el fichero, el nombre y el contenedor
        public void SubirFichero(Stream fichero, String nombre, String contenedor = null)
        {
            //comprobamos el cliente
            ComprobarContenedor(contenedor);

            //obtenemos el nombre del cliente
            var client = _cuenta.CreateCloudBlobClient();
            //obtenemos el nombre del contenedor
            var cont = client.GetContainerReference(_contenedor);
            //obtenemos el nombre del blob
            var blob = cont.GetBlockBlobReference(nombre);
            //subimos fichero
            blob.UploadFromStream(fichero);
            //cerramos el fichero
            fichero.Close(); 
        }

        public byte[] RecuperarFichero(String nombre, String contenedor)
        {
            //comprobamos el cliente
            ComprobarContenedor(contenedor);

            //obtenemos el nombre del cliente
            var client = _cuenta.CreateCloudBlobClient();
            //obtenemos el nombre del contenedor
            var cont = client.GetContainerReference(_contenedor);
            //obtenemos el nombre del blob
            var blob = cont.GetBlockBlobReference(nombre);


            blob.FetchAttributes();
            var lon = blob.Properties.Length;
            var dest = new byte[lon];
            blob.DownloadToByteArray(dest, 0);
            return dest;
        }

        //Para la subida de la foto urilizamos un byte array, porque es como lo tenemos definido, en vez de un stream
        public void SubirFichero(byte[] fichero, String nombre, String contenedor = null)
        {
            ComprobarContenedor(contenedor);

            var client = _cuenta.CreateCloudBlobClient();
            var cont = client.GetContainerReference(_contenedor);
            var blob = cont.GetBlockBlobReference(nombre);
            //Aqui lo que le decimos para la subida, lo que subimos(ficheros)
            //desde que posición[0]
            //El tamaño .Length
            blob.UploadFromByteArray(fichero,0,fichero.Length); 
            
        }
        
    }
}