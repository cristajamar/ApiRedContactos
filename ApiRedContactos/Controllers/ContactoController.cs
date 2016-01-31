using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRedContactos.Reporsitorios;
using ContactosModel.Model;
using Microsoft.Practices.Unity;

namespace ApiRedContactos.Controllers
{
    public class ContactoController : ApiController
    {
        [Dependency]
        public ContactoRepositorio ContactoRepositorio { get; set; }

        public ICollection<ContactoModel> Get(int id, bool amigos)
        {
            if (amigos)
            {
                return ContactoRepositorio.GetByOrigen(id);
            }
            return ContactoRepositorio.GetNoContactosByOrigen(id);
        }

        [ResponseType(typeof (ContactoModel))]
        public IHttpActionResult Post(ContactoModel model)
        {
            var data = ContactoRepositorio.Add(model);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [ResponseType(typeof (void))]
        public IHttpActionResult Put(ContactoModel model)
        {
            var data = ContactoRepositorio.Update(model);
            if (data < 1)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
