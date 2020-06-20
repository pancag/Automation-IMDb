#language:pt-BR
Funcionalidade:1 - Validacao_Login
	teste de login no site IMDb

Contexto: 
	Dado Que acesso a homepage do IMDb
	E clico em Sign In
	E clico em Sign in with IMDb

@IMDb @Login
Esquema do Cenário: 1.1_Efetuar Login (Validacoes)
	Quando informo email <email> e senha <senha>
	E clico em Sign-In
	Entao valido mensagem <mensagem>

	Exemplos: 
	| email                          | senha    | mensagem                                          |
	| giovannacaroline15@hotmail.com | teste123 | usuario logado                                    |
	| giovannacaroline15@hotmail.com |          | Enter your password                               |
	| testedagiovanna@hotmail.com    | teste12  | We cannot find an account with that email address |
	| giovannacaroline15@hotmail.com | teste12  | Your password is incorrect                        |