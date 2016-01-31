using ApiRedContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiRedContactos.Adapters
{
    public class MensajeAdapter : BaseAdapter<Mensaje,MensajeModel>
    {
        public override Mensaje FromViewModel(MensajeModel model)
        {
            return new Mensaje()
            {
                id = model.id,
                idOrigen = model.idOrigen,
                idDestino = model.idDestino,
                asunto = model.asunto,
                contenido = model.contenido,
                leido=model.leido,
                fecha=model.fecha
            };
        
        }

        public override MensajeModel FromModel(Mensaje model)
        {
            return new MensajeModel()
            {
                id = model.id,
                idOrigen = model.idOrigen,
                idDestino = model.idDestino,
                asunto = model.asunto,
                contenido = model.contenido,
                leido = model.leido,
                fecha = model.fecha
            };
        }
    }
}