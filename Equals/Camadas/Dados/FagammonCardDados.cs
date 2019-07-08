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
    /// Classe Factory responsável pelo FagammonCard
    /// </summary>
    public class FagammonCardDados : BaseDados
    {
        /// <summary>
        /// Método responsável por armazenar um novo CNAB FagammonCard
        /// </summary>
        /// <param name="fagammonCardEntidade"></param>
        /// <returns></returns>
        public FagammonCardInclusaoRetornoProjecao IncluirFagammonCard(FagammonCardEntidade fagammonCardEntidade)
        {
            FagammonCardInclusaoRetornoProjecao fagammonCardInclusaoRetornoProjecao = new FagammonCardInclusaoRetornoProjecao();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" INSERT ");
                query.Append(" FagammonCard(TipoRegistro, DataProcessamento, Estabelecimento, ");
                query.Append(" EmpresaAdquirente, Sequencia, NomeArquivo, LinhaArquivo, DataHoraInclusao) ");
                query.Append(" Values(@TipoRegistro, @Estabelecimento, @DataProcessamento, ");
                query.Append(" @EmpresaAdquirente, @Sequencia, @NomeArquivo, @LinhaArquivo, CURRENT_TIMESTAMP); ");
                #endregion

                command.CommandText = query.ToString();

                #region Parâmetros
                command.Parameters.AddWithValue("@TipoRegistro", fagammonCardEntidade.TipoRegistro);
                command.Parameters.AddWithValue("@Estabelecimento", fagammonCardEntidade.Estabelecimento);
                command.Parameters.AddWithValue("@DataProcessamento", fagammonCardEntidade.DataProcessamento);
                command.Parameters.AddWithValue("@EmpresaAdquirente", fagammonCardEntidade.EmpresaAdquirente);
                command.Parameters.AddWithValue("@Sequencia", fagammonCardEntidade.Sequencia);
                command.Parameters.AddWithValue("@NomeArquivo", fagammonCardEntidade.NomeArquivo);
                command.Parameters.AddWithValue("@LinhaArquivo", fagammonCardEntidade.LinhaArquivo);
                #endregion

                command.ExecuteNonQuery();

                fagammonCardInclusaoRetornoProjecao.codigo = "0";
                fagammonCardInclusaoRetornoProjecao.mensagem = "Registro armazenado com sucesso!";
            } catch(Exception e)
            {
                fagammonCardInclusaoRetornoProjecao.codigo = "1";
                fagammonCardInclusaoRetornoProjecao.mensagem = e.Message;
            } finally
            {
                desconectar();
            }

            return fagammonCardInclusaoRetornoProjecao;
        }

        public void EnviarFagammonCard(string Identificador)
        {
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" UPDATE FagammonCard ");
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

        public FagammonCardEntidade RecuperarFagammonCard(int Identificador)
        {
            FagammonCardEntidade fagammonCardEntidade = new FagammonCardEntidade();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");
                query.Append("      Identificador, TipoRegistro, Estabelecimento, DataProcessamento, ");
                query.Append("      EmpresaAdquirente, Sequencia, NomeArquivo, LinhaArquivo, DataHoraInclusao, Situacao ");
                query.Append(" FROM ");
                query.Append("      FagammonCard ");
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
                    fagammonCardEntidade.Identificador = reader.GetString("Identificador");
                    fagammonCardEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    fagammonCardEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    fagammonCardEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    fagammonCardEntidade.Sequencia = reader.GetString("Sequencia");
                    fagammonCardEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    fagammonCardEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    fagammonCardEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    fagammonCardEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    fagammonCardEntidade.Situacao = reader.GetString("Situacao");
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

            return fagammonCardEntidade;
        }

        public IList<FagammonCardEntidade> RecuperarFagammonCard()
        {
            IList<FagammonCardEntidade> lista = new List<FagammonCardEntidade>();
            try
            {
                conectar();

                // Criação do Comando
                command = connection.CreateCommand();
                #region Query
                StringBuilder query = new StringBuilder();
                query.Append(" SELECT ");
                query.Append("      Identificador, TipoRegistro, Estabelecimento, DataProcessamento, ");
                query.Append("      EmpresaAdquirente, Sequencia, NomeArquivo, LinhaArquivo, DataHoraInclusao, Situacao ");
                query.Append(" FROM ");
                query.Append("      FagammonCard; ");
                #endregion

                command.CommandText = query.ToString();

                MySqlDataReader reader = command.ExecuteReader();

                #region Preencher Objeto
                FagammonCardEntidade fagammonCardEntidade;
                while (reader.Read())
                {
                    fagammonCardEntidade = new FagammonCardEntidade();

                    fagammonCardEntidade.Identificador = reader.GetString("Identificador");
                    fagammonCardEntidade.TipoRegistro = reader.GetString("TipoRegistro");
                    fagammonCardEntidade.Estabelecimento = reader.GetString("Estabelecimento");
                    fagammonCardEntidade.DataProcessamento = reader.GetString("DataProcessamento");
                    fagammonCardEntidade.Sequencia = reader.GetString("Sequencia");
                    fagammonCardEntidade.EmpresaAdquirente = reader.GetString("EmpresaAdquirente");
                    fagammonCardEntidade.NomeArquivo = reader.GetString("NomeArquivo");
                    fagammonCardEntidade.LinhaArquivo = reader.GetString("LinhaArquivo");
                    fagammonCardEntidade.DataHoraInclusao = reader.GetString("DataHoraInclusao");
                    fagammonCardEntidade.Situacao = reader.GetString("Situacao");

                    lista.Add(fagammonCardEntidade);
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