# foodhub
Desafio técnico foodhub
-----------
Este repositorio foi criado para o desafio técnico Foodhub, escolhi utilizar clean architeture para este projeto.
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
