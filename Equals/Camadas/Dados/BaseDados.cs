using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Camadas.Dados
{
    /// <summary>
    /// Classe responsável pelos atributos base de qualquer classe Dados
    /// </summary>
    public class BaseDados
    {
        #region Atributos da Classe
        /// <summary>
        /// Conexão com o banco de dados MySql
        /// Há duas conexões. A local, caso queira executar localmente, ou com um servidor cloud configurado para os testes
        /// Comentar a que não deseja utilizar, e deixar não comentada a que deseja. Por padrão fica selecionada a local
        /// </summary>
        String connString = "Server=localhost;Database=equals;Uid=root;Pwd=";
        /// <summary>
        /// Atributo que MySqlConnection que será utilizado para gerenciar a conexão de todas as
        /// classes Dados
        /// </summary>
        public MySqlConnection connection;
        /// <summary>
        /// Atributo que MySqlCommand que será utilizado para gerenciar os comandos que serão
        /// executados em todas as classes Dados
        /// </summary>
        public MySqlCommand command;
        #endregion

        /// <summary>
        /// Função utilizada para abrir conexão com o banco de dados antes de executar qualquer
        /// comando
        /// </summary>
        public void conectar()
        {
            connection = new MySqlConnection(connString);
            command = connection.CreateCommand();
            connection.Open();
        }

        /// <summary>
        /// Função utilizada para fechar conexão com o banco de dados antes de executar qualquer
        /// comando
        /// </summary>
        public void desconectar()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}