#!/bin/bash
# Inicia o SQL Server
/opt/mssql/bin/sqlservr &

# espera o SQL Server iniciar antes de executar os comandos seguintes
sleep 30s

# Roda o resto do seu script de inicialização, migrações, etc
# (...)

# Inicia sua aplicação .NET
dotnet WebApi.dll