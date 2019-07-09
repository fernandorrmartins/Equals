using Camadas.Entidade;
using Camadas.Negocio;
using Camadas.Projecao;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Equals
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Arquivo")]
    public class ArquivoController : ApiController
    {
        [HttpPost]
        [Route("Incluir")]
        public ArquivoInclusaoRetornoProjecao IncluirArquivo(ArquivoEntidade arquivoEntidade)
        {
            return new ArquivoNegocio().IncluirArquivo(arquivoEntidade);
        }

        [HttpGet]
        [Route("Recuperar")]
        public ArquivoEntidade RecuperarArquivo(int Identificador)
        {
            return new ArquivoNegocio().RecuperarArquivo(Identificador);
        }

        [HttpGet]
        [Route("Recuperar")]
        public IList<ArquivoEntidade> RecuperarTodosArquivos()
        {
            return new ArquivoNegocio().RecuperarArquivo();
        }

        [HttpGet]
        [Route("Enviar")]
        public void EnviarArquivo(string Identificador)
        {
            new ArquivoNegocio().EnviarArquivo(Identificador);
        }
    }
}