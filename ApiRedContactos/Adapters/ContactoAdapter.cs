using ApiRedContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiRedContactos.Adapters
{
    public class ContactoAdapter:BaseAdapter<Usuario,ContactoModel>
    {
        public override Usuario FromViewModel(ContactoModel model)
        {
            return null;
        }

        public override ContactoModel FromModel(Usuario model)
        {
            return null;
        }
    }
}