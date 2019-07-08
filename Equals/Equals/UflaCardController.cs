using Camadas.Entidade;
using Camadas.Negocio;
using Camadas.Projecao;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Equals
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/UflaCard")]
    public class UflaCardController : ApiController
    {
        [HttpPost]
        [Route("Incluir")]
        public UflaCardInclusaoRetornoProjecao IncluirUflaCard(ArquivoEntidade uflaCardEntidade)
        {
            return new ArquivoNegocio().IncluirUflaCard(uflaCardEntidade);
        }

        [HttpGet]
        [Route("Recuperar")]
        public ArquivoEntidade RecuperarUflaCard(int Identificador)
        {
            return new ArquivoNegocio().RecuperarUflaCard(Identificador);
        }

        [HttpGet]
        [Route("Recuperar")]
        public IList<ArquivoEntidade> RecuperarTodosUflaCard()
        {
            return new ArquivoNegocio().RecuperarUflaCard();
        }

        [HttpGet]
        [Route("Enviar")]
        public void EnviarUflaCard(string Identificador)
        {
            new ArquivoNegocio().EnviarUflaCard(Identificador);
        }
    }
}