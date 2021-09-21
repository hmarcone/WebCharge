# Web Charge - Telefones Pessoais
 Web Charge

Este é um projeto de CRUD simples de uma lista de contatos.

## Technologies

Este projeto foi desenvolvido utilizando as seguintes tecnologias:

- Angular 6.1
- [Microsoft.AspNetCore.App 2.2.0](https://www.nuget.org/packages/Microsoft.AspNetCore.App/2.2.0)
- [Entity Framework](https://docs.microsoft.com/pt-br/dotnet/framework/data/adonet/ef/)

## Como rodar

Clone o projeto e acesse sua pasta.

```bash
$ git clone git@github.com:hmarcone/WebCharge.git
$ cd webChargeApp
```
### Backend

A solução tem um projeto docker-compose pronto e configurado para executar o aplicativo, incluindo o provisionamento de uma instância do MS SQL para ele. O projeto depende de migração e, portanto, todos os dados e estruturas serão criados durante a inicialização. Se você tiver dificuldades para executar o projeto com o Docker, ignore-o e execute o projeto “Examples.Charge.API”, alterando apenas a string de conexão e apontando para uma instância de banco de dados válida.

### Frontend

Para iniciar o projeto, siga as etapas abaixo:

```bash
# Instalar as dependências
$ npm install

# Start o projeto
$ npm start
```
O aplicativo estará disponível em seu navegador na url: http://localhost:4200/.
