# API Web - Gerenciamento de Clientes, Contatos e Endereços
Este projeto consiste em uma API Web desenvolvida para manipulação de dados relacionados a Clientes, Contatos e Endereços. A aplicação foi construída com boas práticas de arquitetura e desenvolvimento, utilizando os seguintes recursos: </br>

* Middleware personalizado para tratamento global de exceções, garantindo uma resposta padronizada e mais segura em casos de erro. </br>

* Data Annotations personalizados, aplicadas aos DTOs, melhorando a integridade dos dados recebidos pela API. </br>

* Banco de dados criado seguindo a abordagem Code First, com Migrations. </br>

* Integração com a [Via CEP API](https://viacep.com.br/)

## 🚀 Começando

* No arquivo appsettings.json, substituir a DefaultConnection pela sua string do banco de dados:
 ````json
"ConnectionStrings": {
    "DefaultConnection": ""
 },
````
* Criar o banco de dados. Os comandos para gerar a Migration são: 
 ````powershell
Add-Migration CriacaoBase -Context BancoContext
Update-Database -Context BancoContext
````

## 🛠️ Construído com

* ASP.NET C# WEB Api, SQL Server, Postman, ViaCEP API
