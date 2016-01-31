using System;
using System.Data.Entity;
using System.Linq;
using ApiRedContactos.Adapters;
using ApiRedContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Reporsitorio;

namespace ApiRedContactos.Reporsitorios
{
    public class UsuarioRepositorio:BaseRespositorioEntity<Usuario,UsuarioModel,UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        {
        }

        public UsuarioModel Validar(String login, String password)
        {
            var data = Get(o => o.login == login && o.password == password);
            //determina si la sentencia tiene algún elemento
            if (data.Any())
            {
                return data.First();
            }
            return null;
        }

        public bool IsUnico(string login)
        {
            var data = Get(o => o.login == login);
            return !data.Any();
        }

        public override UsuarioModel Add(UsuarioModel model)
        {
            if (IsUnico(model.login))
            {
                return base.Add(model);
            }
            return null;
        }
    }
}