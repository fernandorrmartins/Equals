var api = "http://localhost:82/api/Arquivo/";

$(document).ready(function(){
    var file = document.getElementById("file");
    var btnEnviar = document.getElementById("enviar");
    var corpoTabela = document.getElementById("corpoTabela");
    var arquivo;
    var registros;

    function request (metodo, url, data, sucesso, falha){
        $.ajax({
            url: url,
            type: metodo,
            async: true,
            dataType: "json",
            data: data,
            contentType: "application/json; charset=utf-8",
            success: sucesso,
            error: falha
            });
    }

    function recuperarRegistro(Identificador){
        var url = api+"Recuperar?"+(Identificador ? "Identificador="+Identificador : "");
        request("GET", url,
                null, function(data){registros = data; criarTabela();}, null);
    }
    
    recuperarRegistro();

    function criarTabela(){
        if(registros && registros.length > 0) {
            var linha = '';
            for (i = 0; i < registros.length; i++) {
                linha += "<tr>" +
                            "<td id='Identificador' class='m borda l'>" + registros[i]['Identificador'] + "</td>" +
                            "<td id='EmpresaAdquirente' class='borda l'>" + registros[i]['EmpresaAdquirente'] + "</td>" +
                            "<td id='NomeArquivo' class='borda l'>" + registros[i]['NomeArquivo'] + "</td>" +
                            "<td id='LinhaArquivo' class='borda l'>" + registros[i]['LinhaArquivo'] + "</td>" +
                            "<td id='Situacao' class='borda l'>" + (registros[i]['Situacao'] == 1 ? 'Não enviado' : (registros[i]['Situacao'] == 2 ? 'Enviado' : 'Erro')) + "</td>" +
                            "<td id='DataHoraInclusao' class='borda l'>" + registros[i]['DataHoraInclusao'] + "</td>" +
                            "<td class='borda c'>" +
                            '<button id="' + registros[i]['Identificador'] + '" ' 
                                + (registros[i]['Situacao'] == 1 ? '' : 'disabled')
                                +  ' class="btn btn-primary enviar">Enviar</button>' +
                            "</td>" +
                        "</tr>";
            }
            corpoTabela.innerHTML = linha;
        }
        var btnEnvUfla = document.getElementsByClassName("enviar");
        
        for (i = 0; i < btnEnvUfla.length; i++) {
            btnEnvUfla[i].onclick = function (e){
                request("GET",api+"Enviar?Identificador="+e.target.id,
                null, function(data){
                    alert(data.mensagem);
                    if(data.codigo == "0"){
                        e.target.parentElement.parentElement.cells[4].innerHTML = 'Enviado';
                        e.target.disabled = true;
                    }
                }, null);
            }
        }
    }

    var caixaEnviar = document.getElementById("caixaEnviar");
    caixaEnviar.hidden = true;
    document.getElementById("btnAcessarEnviarArquivo").onclick = function(){
        if(caixaEnviar.hidden)
            caixaEnviar.hidden = false;
        else
            caixaEnviar.hidden = true;
    }

    btnEnviar.onclick = function(){
        if(file.files[0] != null) {
            if (confirm('Você tem certeza que deseja enviar o arquivo @nome?'.replace('@nome', arquivo.NomeArquivo))) {
                var data = JSON.stringify(arquivo);
                request("POST", api+"Incluir", data,
                    function(data){
                        alert(data["mensagem"]);
                        if(data['codigo'] == '0')
                            recuperarRegistro();
                        if(!confirm('Deseja enviar outro arquivo?')){
                            caixaEnviar.hidden = true;
                        }
                    },
                    null);
            } else {
                alert("Envio cancelado pelo usuário!");
            }
            
        } else {
            alert("Selecione um arquivo!");
        }
    }

    if(window.FileReader){
        file.onchange = function () {
            if(file.files[0] != null) {
                var loader = new FileReader();
                loader.onload = function (changeEvent) {
                    
                    if (changeEvent.target.readyState != 2)
                    return;
                    if (changeEvent.target.error) {
                    alert("Error while reading file " + file.name + ": " + changeEvent.target.error);
                    return;
                    }

                    arquivo = new Object();
                    arquivo.NomeArquivo = file.files[0].name;
                    arquivo.LinhaArquivo = atob(changeEvent.target.result.split(',')[1]);

                    if(!arquivo.LinhaArquivo.toLowerCase().includes("uflacard")
                        && !arquivo.LinhaArquivo.toLowerCase().includes("fagammoncard")) {
                        alert("Arquivo com formato incorreto!");
                    }
                };
                loader.readAsDataURL(file.files[0]);
            } else {
                alert("Selecione um arquivo!");
            }
        }
    } else {
        alert("Navegador incompatível com o site! Por favor utilize outro navegador.");
    }
});