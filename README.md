# Equals

<h2>Projetos</h2>
<ol>
  <li>Webservice Asp.net</li>
  <li>Banco de Dados MySql</li>
  <li>Site Html + javascript</li>
</ol>

<h2>Requisitos para Teste:</h2>
<h3>Ps: Esses requisitos são para testar site e servidor no mesmo computador. Para testar remoto, é necessário liberar porta, e efetuar configurações devidas.</h3>
<ol>
  <li>Windows ou Windows Server pois o Webservice é Asp.net e é necessário o IIS instalado e ativo</li>
  <li>Banco de Dados MySql instalado na mesma máquina que o Webservice. Usuário padrão do MySql para acesso local.</br>
    -Usuário: 'root'</br>
    -Senha: ''</li>
  <li>Site Html pode ser hospedado no IIS ou em qualquer outro servidor(Apache por exemplo). Por ser apenas javascript, html, css é compatível com qualquer servidor.</li>
  <li>Webservice deve estar rodando na porta 82. Se quiser alterar a porta, deve alterar o link para Webservice, que se encontra na pasta:</br>
  Equals > Equals Site > js > equals.js</br>
  Link padrão da Api: http://localhost:82/api/Arquivo/</li>
  <li>Site pode estar rodando em qualquer porta.</li>
</ol>

<h2>Instruções</h2>
<ol>
  <li>Executar o script do Schema Físico do Banco de Dados no MySql.</br>
  <ul>
    <li>Caminho do Schema:</br>
    Equals > 07072019_Fisic_Scheme_BD_Equals.sql</br></li>
    <li>Abrir com qualquer editor de Sql ou Texto, e copiar seu conteúdo.</li>
    <li>Pelo phpmyadin, acessar a aba Sql, e colar o conteúdo do Schema.</li>
    <li>Executar a query.</br>
  </ul>
 </ol>
