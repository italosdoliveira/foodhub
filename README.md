# foodhub
Desafio técnico foodhub
-----------
Este repositorio foi criado para o desafio técnico Foodhub, escolhi utilizar clean architeture para este projeto com as camadas Domain, Application, Infra.Data e Infra.Ioc, além da camada WebApi.A clean architeture foi escolhida para tornar os testes mais fáceis de executar e mockar. Também foi utilizado o mediator para disparar Domain Events para alguns tipos de eventos relacionados ao pedido.\
Foi implemenado um middleware excpetion para pegar as exceções que passam via http e retornar elas formatadas.\
Para abstrações de banco de dados foi utilizado o padrão repository. Usando inversão de controle com uma interface e uma classe que implementa essa interface. Isso facilitou para mockar os repositories.\
As regras de negócio estão nas entidades, nos handlers e nos services e foram estes que foram testados.\
Nas rotas dos controllers são retornados um dto do pedido e não a entidade pedido em si.\
Para alterar o banco basta acessar o arquivo Program.cs e alterar a connection string do banco de dados mongo.\
Todas as rotas estão presentes e podem ser acessadas via swagger se em localhost na rota https://localhost:7272/swagger/index.html \
Para criar ou atualizar um pedido basta usar o json abaixo.
```
{
  "codigo": "PED-2026-000123",
  "dataHora": "2026-01-15T10:30:00",
  "clienteId": "CLI-98765",
  "clienteNome": "João da Silva",
  "restauranteId": "REST-12345",
  "restauranteNome": "Pizzaria Central",
  "itens": [
    {
      "produtoId": "PROD-001",
      "produtoDescricao": "Pizza Calabresa",
      "quantidade": 1,
      "precoUnitario": 45.90,
      "observacoes": "Sem cebola",
      "valorTotal": 40.90
    },
    {
      "produtoId": "PROD-002",
      "produtoDescricao": "Refrigerante 2L",
      "quantidade": 1,
      "precoUnitario": 12.00,
      "valorTotal": 12.00
    }
  ],
  "taxaEntrega": 5.00,
  "cupomDescontoAplicado": "PROMO10",
  "status": 1,
  "tipo": 0
}
```
