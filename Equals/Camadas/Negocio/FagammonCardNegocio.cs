using Camadas.Dados;
using Camadas.Entidade;
using Camadas.Projecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camadas.Negocio
{
    /// <summary>
    /// Classe responsável pelos métodos de negocio relacionados ao FagammonCard
    /// </summary>
    public class FagammonCardNegocio
    {
        private FagammonCardDados fagammonCardDados;

        /// <summary>
        /// Método Construtor da Classe Negocio
        /// </summary>
        public FagammonCardNegocio()
        {
            fagammonCardDados = new FagammonCardDados();
        }

        public FagammonCardInclusaoRetornoProjecao IncluirFagammonCard(FagammonCardEntidade fragammonCardEntidade)
        {
            FagammonCardInclusaoRetornoProjecao fragammonRetorno = new FagammonCardInclusaoRetornoProjecao();

            try
            {
                if (fragammonCardEntidade != null
                    && fragammonCardEntidade.LinhaArquivo.ToLower().Contains("fagammoncard")
                    && fragammonCardEntidade.LinhaArquivo.Length == 36)
                {
                    fragammonCardEntidade.TipoRegistro = fragammonCardEntidade.LinhaArquivo.Substring(0, 1);
                    fragammonCardEntidade.DataProcessamento = fragammonCardEntidade.LinhaArquivo.Substring(1, 10);
                    fragammonCardEntidade.Estabelecimento = fragammonCardEntidade.LinhaArquivo.Substring(9, 8);
                    fragammonCardEntidade.EmpresaAdquirente = fragammonCardEntidade.LinhaArquivo.Substring(17, 12);
                    fragammonCardEntidade.Sequencia = fragammonCardEntidade.LinhaArquivo.Substring(29, 7);

                    return fagammonCardDados.IncluirFagammonCard(fragammonCardEntidade);
                }
                else
                {
                    fragammonRetorno.codigo = "1";
                    fragammonRetorno.mensagem = "Formato de arquivo incorreto!";

                    return fragammonRetorno;
                }
            }
            catch (Exception e)
            {
                fragammonRetorno.codigo = "1";
                fragammonRetorno.codigo = "Ocorreu algum erro durante o processamento. Entre em contato com a equipe de suporte.";

                return fragammonRetorno;
            }
        }

        public void EnviarFagammonCard(String Identificador)
        {
            fagammonCardDados.EnviarFagammonCard(Identificador);
        }

        public FagammonCardEntidade RecuperarFagammonCard(int Identificador)
        {
            return fagammonCardDados.RecuperarFagammonCard(Identificador);
        }

        public IList<FagammonCardEntidade> RecuperarFagammonCard()
        {
            return fagammonCardDados.RecuperarFagammonCard();
        }
    }
}