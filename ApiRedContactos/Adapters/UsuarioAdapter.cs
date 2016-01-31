using ApiRedContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiRedContactos.Adapters
{
    public class UsuarioAdapter : BaseAdapter<Usuario,UsuarioModel>
    {
        public override Usuario FromViewModel(UsuarioModel model)
        {
            return new Usuario()
            {
                id = model.id,
                login = model.login,
                password = model.password,
                nombre = model.nombre,
                apellidos = model.apellidos,
                foto = model.foto
                };
        }

        public override UsuarioModel FromModel(Usuario model)
        {
            return new UsuarioModel()
            {
                id = model.id,
                login = model.login,
                password = model.password,
                nombre = model.nombre,
                apellidos = model.apellidos,
                foto = model.foto
            };
        }
    }
}