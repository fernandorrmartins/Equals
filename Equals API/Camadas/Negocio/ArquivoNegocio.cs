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
    /// Classe responsável pelos métodos de negocio relacionados ao Arquivo
    /// </summary>
    public class ArquivoNegocio
    {
        private ArquivoDados arquivoDados;

        /// <summary>
        /// Método Construtor da Classe Negocio
        /// </summary>
        public ArquivoNegocio ()
        {
            arquivoDados = new ArquivoDados();
        }

        public ArquivoInclusaoRetornoProjecao IncluirArquivo(ArquivoEntidade arquivoEntidade)
        {
            ArquivoInclusaoRetornoProjecao arquivoRetorno = new ArquivoInclusaoRetornoProjecao();

            try
            {
                if (arquivoEntidade != null
                    && arquivoEntidade.LinhaArquivo.ToLower().Contains("uflacard")
                    && arquivoEntidade.LinhaArquivo.Length == 50)
                {
                    arquivoEntidade.TipoRegistro = arquivoEntidade.LinhaArquivo.Substring(0, 1);
                    arquivoEntidade.Estabelecimento = arquivoEntidade.LinhaArquivo.Substring(1, 10);
                    arquivoEntidade.DataProcessamento = arquivoEntidade.LinhaArquivo.Substring(11, 8);
                    arquivoEntidade.PeriodoInicial = arquivoEntidade.LinhaArquivo.Substring(19, 8);
                    arquivoEntidade.PeriodoFinal = arquivoEntidade.LinhaArquivo.Substring(27, 8);
                    arquivoEntidade.Sequencia = arquivoEntidade.LinhaArquivo.Substring(35, 7);
                    arquivoEntidade.EmpresaAdquirente = arquivoEntidade.LinhaArquivo.Substring(42, 8);

                    return arquivoDados.IncluirArquivo(arquivoEntidade);
                }
                else if (arquivoEntidade != null
                 && arquivoEntidade.LinhaArquivo.ToLower().Contains("fagammoncard")
                 && arquivoEntidade.LinhaArquivo.Length == 36)
                {
                    arquivoEntidade.TipoRegistro = arquivoEntidade.LinhaArquivo.Substring(0, 1);
                    arquivoEntidade.DataProcessamento = arquivoEntidade.LinhaArquivo.Substring(1, 8);
                    arquivoEntidade.Estabelecimento = arquivoEntidade.LinhaArquivo.Substring(9, 8);
                    arquivoEntidade.EmpresaAdquirente = arquivoEntidade.LinhaArquivo.Substring(17, 12);
                    arquivoEntidade.Sequencia = arquivoEntidade.LinhaArquivo.Substring(29, 7);

                    return arquivoDados.IncluirArquivo(arquivoEntidade);
                }
                else
                {
                    arquivoRetorno.codigo = "1";
                    arquivoRetorno.mensagem = "Formato de arquivo incorreto!";

                    return arquivoRetorno;
                }
            } catch(Exception e)
            {
                arquivoRetorno.codigo = "1";
                arquivoRetorno.codigo = "Ocorreu algum erro durante o processamento. Entre em contato com a equipe de suporte.";

                return arquivoRetorno;
            }
        }

        public ArquivoInclusaoRetornoProjecao EnviarArquivo(String Identificador)
        {
            return arquivoDados.EnviarArquivo(Identificador);
        }

        public ArquivoEntidade RecuperarArquivo(int Identificador)
        {
            return arquivoDados.RecuperarArquivo(Identificador);
        }

        public IList<ArquivoEntidade> RecuperarArquivo()
        {
            return arquivoDados.RecuperarArquivo();
        }
    }
}