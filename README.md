# Desafio

## Backend
A aplicação possui o Swagger configurado para uso e teste da API.
Ao subir o projeto "Desafio.WebApi", a aplicação vai criar automaticamente o banco SQLlite em "C:\Desafio" no caso de uso do SO Windows.
Em caso de uso de outro SO, alterar o caminho no arquivo de configuração "appsettings.json", na propriedade "ConnectionStrings:SQLDatabase".
Automaticamente é aplicado o migrations na base ao subir o serviço.

### Libs e framework
- .NET Core 7
- EntityFramework
- EntityFramework.SQLLite
- Autofac
- Mediator
- Automapper
