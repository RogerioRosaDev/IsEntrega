# IsEntrega
Teste Empresa

# Sigas os Passo para executar o Projeto

1.	Verificar as Dll de todos os projetos se não estão com amarelinhas com warning entre elas, caso esteja atualize as dlls pelo nuget.

2.	Na pasta infra (pasta 4)
       2.1	Pasta DataAccess => pasta Connection => SQL => class: ConnectionClass, no construtor da classe “base” metodo  StringConnection() => mudar a string de conexão do seu banco SQl.
       2.2	Após Mudar a string de conexão, abra o console do nuget “verificar se está apontando para o projeto: SIS_ISENTREGA.DataAccess”, executar os comandos
     •	Enable-Migrations
     •	Add-Migration Initial
     •	Update-Database –verbose –force

3.	Após esses passos é preciso configurar 2 Solutions para se inicializa:
     •	Solution SIS_ISENTREGA.UI
     •	Solution  SIS_ISENTREGA.Services
 
Solution SIS_ISENTREGA.UI: Front End
Solution SIS_ISENTREGA.Services: Web Api => serviço Rest Full

# Qualquer duvida estou a disposição            
