using Camadas.Dados;
using Camadas.Entidade;
using Camadas.Projecao;
using System;
using System.Collections.Generic;

namespace Camadas.Negocio
{
    /// <summary>
    /// Classe responsável pelos métodos de negocio relacionados ao Arquivo
    /// </summary>
    public class ArquivoNegocio
    {
        /// <summary>
        /// Variável responsável por chamar todos os métodos da camada de dados
        /// </summary>
        private ArquivoDados arquivoDados;

        /// <summary>
        /// Método Construtor da Classe Negocio
        /// Instancia a Variável do Tipo ArquivoDados da Classe
        /// </summary>
        public ArquivoNegocio ()
        {
            arquivoDados = new ArquivoDados();
        }

        /// <summary>
        /// Método da Camada de Negocios responsável por destrinchar o Arquivo
        /// e preencher os atributos o ArquivoEntidade, para repassar a camada de dados
        /// para que possa ser incluida no banco de dados
        /// </summary>
        /// <param name="arquivoEntidade"></param>
        /// <returns></returns>
        public ArquivoInclusaoRetornoProjecao IncluirArquivo(ArquivoEntidade arquivoEntidade)
        {
            ArquivoInclusaoRetornoProjecao arquivoRetorno = new ArquivoInclusaoRetornoProjecao();

            try
            {
                #region Tratamento do Arquivo Enviado pelo Usuário
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
                #endregion
            }
            catch (Exception e)
            {
                arquivoRetorno.codigo = "1";
                arquivoRetorno.codigo = "Ocorreu algum erro durante o processamento. Entre em contato com a equipe de suporte.";

                return arquivoRetorno;
            }
        }

        /// <summary>
        /// Método da camada de negocios responsável por atualizar o registro, pelo Identificador
        /// repassado, para definir a Situação do Arquivo como 'Enviado'
        /// </summary>
        /// <param name="Identificador"></param>
        /// <returns></returns>
        public ArquivoInclusaoRetornoProjecao EnviarArquivo(String Identificador)
        {
            return arquivoDados.EnviarArquivo(Identificador);
        }

        /// <summary>
        /// Método da camada de negocios responsável por chamar a classe dados para recuperar
        /// um registro pelo Identificador do Arquivo
        /// </summary>
        /// <param name="Identificador"></param>
        /// <returns></returns>
        public ArquivoEntidade RecuperarArquivo(int Identificador)
        {
            return arquivoDados.RecuperarArquivo(Identificador);
        }

        /// <summary>
        /// Método da camada de negocios responsável por chamar a classe dados para recuperar
        /// todos os registros de Arquivos do Banco de Dados e devolver ao cliente
        /// </summary>
        /// <returns></returns>
        public IList<ArquivoEntidade> RecuperarArquivo()
        {
            return arquivoDados.RecuperarArquivo();
        }
    }
}