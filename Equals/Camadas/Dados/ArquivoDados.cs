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
    /// Classe Factory responsável pelo UflaCard
    /// </summary>
    public class ArquivoDados : BaseDados
    {
        /// <summary>
        /// Método responsável por armazenar um novo CNAB ArquivoEntidade
        /// </summary>
        /// <param name="ArquivoEntidade"></param>
        /// <returns></returns>
        public UflaCardInclusaoRetornoProjecao IncluirUflaCard(ArquivoEntidade uflaCardEntidade)
        {
            UflaCardInclusaoRetornoProjecao uflaRetorno = new UflaCardInclusaoRetornoProjecao();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" INSERT ");
                query.Append(" UflaCard(TipoRegistro, Estabelecimento, DataProcessamento, PeriodoInicial, ");
                query.Append(" PeriodoFinal, Sequencia, EmpresaAdquirente, NomeArquivo, LinhaArquivo, DataHoraInclusao) ");
                query.Append(" Values(@TipoRegistro, @Estabelecimento, @DataProcessamento, @PeriodoInicial, ");
                query.Append(" @PeriodoFinal, @Sequencia, @EmpresaAdquirente, @NomeArquivo, @LinhaArquivo, CURRENT_TIMESTAMP); ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@TipoRegistro", uflaCardEntidade.TipoRegistro);
                command.Parameters.AddWithValue("@Estabelecimento", uflaCardEntidade.Estabelecimento);
                command.Parameters.AddWithValue("@DataProcessamento", uflaCardEntidade.DataProcessamento);
                command.Parameters.AddWithValue("@PeriodoInicial", uflaCardEntidade.PeriodoInicial);
                command.Parameters.AddWithValue("@PeriodoFinal", uflaCardEntidade.PeriodoFinal);
                command.Parameters.AddWithValue("@Sequencia", uflaCardEntidade.Sequencia);
                command.Parameters.AddWithValue("@EmpresaAdquirente", uflaCardEntidade.EmpresaAdquirente);
                command.Parameters.AddWithValue("@NomeArquivo", uflaCardEntidade.NomeArquivo);
                command.Parameters.AddWithValue("@LinhaArquivo", uflaCardEntidade.LinhaArquivo);
                #endregion

                command.ExecuteNonQuery();

                uflaRetorno.codigo = "0";
                uflaRetorno.mensagem = "Registro armazenado com sucesso!";
            } catch(Exception e)
            {
                uflaRetorno.codigo = "1";
                uflaRetorno.mensagem = e.Message;
            } finally
            {
                desconectar();
            }

            return uflaRetorno;
        }

        public void EnviarUflaCard(string Identificador)
        {
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" UPDATE UflaCard ");
                query.Append(" SET Situacao = 2 ");
                query.Append(" WHERE ");
                query.Append("      Identificador = @Identificador; ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@Identificador", Identificador);
                #endregion

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public ArquivoEntidade RecuperarUflaCard(int Identificador)
        {
            ArquivoEntidade uflaCardEntidade = new ArquivoEntidade();
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
                query.Append("      UflaCard ");
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
                    uflaCardEntidade.Identificador = reader.GetString("Identificador");
                    uflaCardEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    uflaCardEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    uflaCardEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    uflaCardEntidade.PeriodoInicial = reader.GetString("PeriodoInicial");
                    uflaCardEntidade.PeriodoFinal = reader.GetString("PeriodoFinal");
                    uflaCardEntidade.Sequencia = reader.GetString("Sequencia");
                    uflaCardEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    uflaCardEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    uflaCardEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    uflaCardEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    uflaCardEntidade.Situacao = reader.GetString("Situacao");
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

            return uflaCardEntidade;
        }

        public IList<ArquivoEntidade> RecuperarUflaCard()
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
                query.Append("      UflaCard; ");
                #endregion

                command.CommandText = query.ToString();

                MySqlDataReader reader = command.ExecuteReader();

                #region Preencher Objeto
                ArquivoEntidade uflaCardEntidade;
                while (reader.Read())
                {
                    uflaCardEntidade = new ArquivoEntidade();

                    uflaCardEntidade.Identificador = reader.GetString("Identificador");
                    uflaCardEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    uflaCardEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    uflaCardEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    uflaCardEntidade.PeriodoInicial = reader.GetString("PeriodoInicial");
                    uflaCardEntidade.PeriodoFinal = reader.GetString("PeriodoFinal");
                    uflaCardEntidade.Sequencia = reader.GetString("Sequencia");
                    uflaCardEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    uflaCardEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    uflaCardEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    uflaCardEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    uflaCardEntidade.Situacao = reader.GetString("Situacao");

                    lista.Add(uflaCardEntidade);
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