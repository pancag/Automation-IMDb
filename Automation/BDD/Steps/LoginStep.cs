using Automation.Base;
using Automation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Automation.BDD.Steps
{
    class LoginStep : BaseTestBDD
    {
        [Given(@"Que acesso a homepage do IMDb")]
        public void DadoQueAcessoAHomepageDoIMDb()
        {
            var HomePage = Environment.GetEnvironmentVariable("IMDb_URL");
            dslIMDb.GoTo(HomePage);
        }

        [When(@"clico em (.*)")]
        [Given(@"clico em (.*)")]
        public void DadoClicoEm(string button)
        {
            dslIMDb.ClickOnButton(button);
        }

        [Given(@"realizo login inserindo credenciais (.*) e (.*)")]
        [When(@"realizo login inserindo credenciais (.*) e (.*)")]
        public void QuandoRealizoLogin(string email, string senha)
        {
            dslIMDb.SendKeys(LoginPages.CampoEmail, email);
            dslIMDb.SendKeys(LoginPages.CampoSenha, senha);

            dslIMDb.Click(LoginPages.btnSignIn);
        }

        [Then(@"valido mensagem (.*)")]
        public void EntaoValidoMensagemE(string mensagem)
        {
            if (mensagem == "usuario logado")
            {
                dslIMDb.AguardarElementoAparecer(LoginPages.UsuarioLogado);
                dslIMDb.ValidAssertIsTrue(LoginPages.UsuarioLogado);
            }
            else
            {
                string text = dslIMDb.GetElementText(LoginPages.MsgErro).Trim();
                dslIMDb.ValidAssertAreEqual(text,mensagem);
            }
        }
    }
}
