using Camadas.Entidade;
using Camadas.Projecao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace Camadas.Dados
{
    /// <summary>
    /// Classe Factory responsável pelo Arquivo
    /// </summary>
    public class ArquivoDados : BaseDados
    {
        /// <summary>
        /// Método responsável por armazenar um novo CNAB ArquivoEntidade
        /// </summary>
        /// <param name="ArquivoEntidade"></param>
        /// <returns></returns>
        public ArquivoInclusaoRetornoProjecao IncluirArquivo(ArquivoEntidade arquivoEntidade)
        {
            ArquivoInclusaoRetornoProjecao arquivoRetorno = new ArquivoInclusaoRetornoProjecao();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" INSERT ");
                query.Append(" Arquivo(TipoRegistro, Estabelecimento, DataProcessamento, ");
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoInicial)) query.Append(" PeriodoInicial,");
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoFinal)) query.Append(" PeriodoFinal,");
                query.Append(" Sequencia, EmpresaAdquirente, NomeArquivo, LinhaArquivo, DataHoraInclusao) ");
                query.Append(" Values(@TipoRegistro, @Estabelecimento, @DataProcessamento, ");
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoInicial)) query.Append(" @PeriodoInicial,");
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoFinal)) query.Append(" @PeriodoFinal,");
                query.Append(" @Sequencia, @EmpresaAdquirente, @NomeArquivo, @LinhaArquivo, CURRENT_TIMESTAMP); ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@TipoRegistro", arquivoEntidade.TipoRegistro);
                command.Parameters.AddWithValue("@Estabelecimento", arquivoEntidade.Estabelecimento);
                command.Parameters.AddWithValue("@DataProcessamento", arquivoEntidade.DataProcessamento);
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoInicial)) command.Parameters.AddWithValue("@PeriodoInicial", arquivoEntidade.PeriodoInicial);
                if (!String.IsNullOrEmpty(arquivoEntidade.PeriodoFinal)) command.Parameters.AddWithValue("@PeriodoFinal", arquivoEntidade.PeriodoFinal);
                command.Parameters.AddWithValue("@Sequencia", arquivoEntidade.Sequencia);
                command.Parameters.AddWithValue("@EmpresaAdquirente", arquivoEntidade.EmpresaAdquirente);
                command.Parameters.AddWithValue("@NomeArquivo", arquivoEntidade.NomeArquivo);
                command.Parameters.AddWithValue("@LinhaArquivo", arquivoEntidade.LinhaArquivo);
                #endregion

                command.ExecuteNonQuery();

                arquivoRetorno.codigo = "0";
                arquivoRetorno.mensagem = "Registro armazenado com sucesso!";
            } catch(Exception e)
            {
                arquivoRetorno.codigo = "1";
                arquivoRetorno.mensagem = e.Message;
            } finally
            {
                desconectar();
            }

            return arquivoRetorno;
        }

        public ArquivoInclusaoRetornoProjecao EnviarArquivo(string Identificador)
        {
            ArquivoInclusaoRetornoProjecao arquivoRetorno = new ArquivoInclusaoRetornoProjecao();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" UPDATE Arquivo ");
                query.Append(" SET Situacao = 2 ");
                query.Append(" WHERE ");
                query.Append("      Identificador = @Identificador; ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@Identificador", Identificador);
                #endregion

                command.ExecuteNonQuery();

                arquivoRetorno.codigo = "0";
                arquivoRetorno.mensagem = "Arquivo enviado com exito!";
            }
            catch (Exception e)
            {
                arquivoRetorno.codigo = "'";
                arquivoRetorno.mensagem = "Ocorreu um erro: " + e.Message;
            }
            finally
            {
                desconectar();
            }

            return arquivoRetorno;
        }

        public ArquivoEntidade RecuperarArquivo(int Identificador)
        {
            ArquivoEntidade arquivoEntidade = new ArquivoEntidade();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");
                query.Append("      Identificador, TipoRegistro, Estabelecimento, DataProcessamento, PeriodoInicial, ");
                query.Append("      PeriodoFinal, Sequencia, EmpresaAdquirente, NomeArquivo, LinhaArquivo, DataHoraInclusao, Situacao ");
                query.Append(" FROM ");
                query.Append("      Arquivo ");
                query.Append(" WHERE ");
                query.Append("      Identificador = @Identificador; ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@Identificador", Identificador);
                #endregion

                MySqlDataReader reader = command.ExecuteReader();

                #region Preencher Objeto
                while (reader.Read())
                {
                    arquivoEntidade.Identificador = reader.GetString("Identificador");
                    arquivoEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    arquivoEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    arquivoEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    arquivoEntidade.PeriodoInicial = (reader["PeriodoInicial"] != DBNull.Value ? reader.GetString("PeriodoInicial") : null);
                    arquivoEntidade.PeriodoFinal = (reader["PeriodoFinal"] != DBNull.Value ? reader.GetString("PeriodoFinal") : null);
                    arquivoEntidade.Sequencia = reader.GetString("Sequencia");
                    arquivoEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    arquivoEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    arquivoEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    arquivoEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    arquivoEntidade.Situacao = reader.GetString("Situacao");
                }
                #endregion

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                desconectar();
            }

            return arquivoEntidade;
        }

        public IList<ArquivoEntidade> RecuperarArquivo()
        {
            IList<ArquivoEntidade> lista = new List<ArquivoEntidade>();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");
                query.Append("      Identificador, TipoRegistro, Estabelecimento, DataProcessamento, PeriodoInicial, ");
                query.Append("      PeriodoFinal, Sequencia, EmpresaAdquirente, NomeArquivo, LinhaArquivo, DataHoraInclusao, Situacao ");
                query.Append(" FROM ");
                query.Append("      Arquivo; ");
                #endregion

                command.CommandText = query.ToString();

                MySqlDataReader reader = command.ExecuteReader();

                #region Preencher Objeto
                ArquivoEntidade arquivoEntidade;
                while (reader.Read())
                {
                    arquivoEntidade = new ArquivoEntidade();

                    arquivoEntidade.Identificador = reader.GetString("Identificador");
                    arquivoEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    arquivoEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    arquivoEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    arquivoEntidade.PeriodoInicial = (reader["PeriodoInicial"] != DBNull.Value ? reader.GetString("PeriodoInicial") : null);
                    arquivoEntidade.PeriodoFinal = (reader["PeriodoFinal"] != DBNull.Value ? reader.GetString("PeriodoFinal") : null);
                    arquivoEntidade.Sequencia = reader.GetString("Sequencia");
                    arquivoEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    arquivoEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    arquivoEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    arquivoEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    arquivoEntidade.Situacao = reader.GetString("Situacao");

                    lista.Add(arquivoEntidade);
                }
                #endregion

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                desconectar();
            }

            return lista;
        }
    }
}