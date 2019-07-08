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
    /// Classe responsável pelos métodos de negocio relacionados ao UflaCard
    /// </summary>
    public class ArquivoNegocio
    {
        private ArquivoDados uflaCardDados;

        /// <summary>
        /// Método Construtor da Classe Negocio
        /// </summary>
        public ArquivoNegocio ()
        {
            uflaCardDados = new ArquivoDados();
        }

        public UflaCardInclusaoRetornoProjecao IncluirUflaCard(ArquivoEntidade uflaCardEntidade)
        {
            UflaCardInclusaoRetornoProjecao uflaRetorno = new UflaCardInclusaoRetornoProjecao();

            try
            {
                if (uflaCardEntidade != null
                    && uflaCardEntidade.LinhaArquivo.ToLower().Contains("uflacard")
                    && uflaCardEntidade.LinhaArquivo.Length == 50)
                {
                    uflaCardEntidade.TipoRegistro = uflaCardEntidade.LinhaArquivo.Substring(0, 1);
                    uflaCardEntidade.Estabelecimento = uflaCardEntidade.LinhaArquivo.Substring(1, 10);
                    uflaCardEntidade.DataProcessamento = uflaCardEntidade.LinhaArquivo.Substring(11, 8);
                    uflaCardEntidade.PeriodoInicial = uflaCardEntidade.LinhaArquivo.Substring(19, 8);
                    uflaCardEntidade.PeriodoFinal = uflaCardEntidade.LinhaArquivo.Substring(27, 8);
                    uflaCardEntidade.Sequencia = uflaCardEntidade.LinhaArquivo.Substring(35, 7);
                    uflaCardEntidade.EmpresaAdquirente = uflaCardEntidade.LinhaArquivo.Substring(42, 8);

                    return uflaCardDados.IncluirUflaCard(uflaCardEntidade);
                }
                else
                {
                    uflaRetorno.codigo = "1";
                    uflaRetorno.mensagem = "Formato de arquivo incorreto!";

                    return uflaRetorno;
                }
            } catch(Exception e)
            {
                uflaRetorno.codigo = "1";
                uflaRetorno.codigo = "Ocorreu algum erro durante o processamento. Entre em contato com a equipe de suporte.";

                return uflaRetorno;
            }
        }

        public void EnviarUflaCard(String Identificador)
        {
            uflaCardDados.EnviarUflaCard(Identificador);
        }

        public ArquivoEntidade RecuperarUflaCard(int Identificador)
        {
            return uflaCardDados.RecuperarUflaCard(Identificador);
        }

        public IList<ArquivoEntidade> RecuperarUflaCard()
        {
            return uflaCardDados.RecuperarUflaCard();
        }
    }
}