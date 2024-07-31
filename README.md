# Fornecedores.API

## Processo para executar o sistema

1. Necessário ter programa SQL Server Management Studio para poder olhar o banco de dados.
2. Baixar arquivo `.zip` -> Extrair -> Abrir solução.
3. Executar no terminal `dotnet build` para atualizar todas as dependências.
4. Navegar até a pasta `Fornecedores.Infrastructure`.
5. Executar `Update-Database` para criar o banco e tabelas.
6. Executar sistema utilizando profile de `Fornecedores`.
