using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeuEstacionamento.Infraestrutura;

namespace Web.UI.Controllers
{
    public class EstacionarController : ApiController
    {
        [HttpPost]
        public void Estacionar(DtoEstacionar dtoEstacionar)
        {

        }

        [HttpDelete]
        public void Retirar(DtoRetirar dtoRetirar)
        {

        }

    }
}