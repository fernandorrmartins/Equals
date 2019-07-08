using Camadas.Entidade;
using Camadas.Negocio;
using Camadas.Projecao;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Equals
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/FagammonCard")]
    public class FagammonCardController : ApiController
    {
        [HttpPost]
        [Route("Incluir")]
        public FagammonCardInclusaoRetornoProjecao IncluirUflaCard(FagammonCardEntidade fragammonCardEntidade)
        {
            return new FagammonCardNegocio().IncluirFagammonCard(fragammonCardEntidade);
        }

        [HttpGet]
        [Route("Recuperar")]
        public FagammonCardEntidade RecuperarUflaCard(int Identificador)
        {
            return new FagammonCardNegocio().RecuperarFagammonCard(Identificador);
        }

        [HttpGet]
        [Route("Recuperar")]
        public IList<FagammonCardEntidade> RecuperarTodosUflaCard()
        {
            return new FagammonCardNegocio().RecuperarFagammonCard();
        }

        [HttpGet]
        [Route("Enviar")]
        public void EnviarFagammonCard(string Identificador)
        {
            new FagammonCardNegocio().EnviarFagammonCard(Identificador);
        }
    }
}