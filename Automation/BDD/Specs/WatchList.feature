#language:pt-BR
Funcionalidade: 2 - Validacao_WatchList
	teste de criação de watch list no site IMDb

Contexto: 
	Dado Que acesso a homepage do IMDb
	E clico em Sign In
	E clico em Sign in with IMDb
	E realizo login inserindo credenciais giovannacaroline15@hotmail.com e teste123

Cenário: 2.1- Adicionar filme a minha Watch List
	E acesso pagina de Most Popular Movies através do menu
	E seleciono um filme que não esteja no meu watchlits
	Quando clico em Add to Watchlist
	E abro minha watchlist
	Então valido que o filme foi adicionado

Cenário: 2.2- Remover filme da minha Watch List
	E abro minha watchlist
	Quando clico no botão para remover o filme
	Então valido que o filme foi removido da minha watchlist