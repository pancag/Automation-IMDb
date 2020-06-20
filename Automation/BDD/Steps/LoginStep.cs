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
            dlsIMDb.GoTo(HomePage);
        }

        [Given(@"clico em (.*)")]
        public void DadoClicoEm(string button)
        {
            dlsIMDb.ClickOnButton(button);
        }

        [When(@"informo email (.*) e senha (.*)")]
        public void QuandoInformoEmailESenha(string email, string senha)
        {
            dlsIMDb.SendKeys(LoginPages.CampoEmail, email);
            dlsIMDb.SendKeys(LoginPages.CampoSenha, senha);
        }

        [When(@"clico em Sign-In")]
        public void QuandoClicoEmSign_In()
        {
            dlsIMDb.Click(LoginPages.btnSignIn);
        }


        [Then(@"valido mensagem (.*)")]
        public void EntaoValidoMensagemE(string mensagem)
        {
            if (mensagem == "usuario logado")
            {
                dlsIMDb.AguardarElementoAparecer(LoginPages.UsuarioLogado);
                dlsIMDb.ValidAssertIsTrue(LoginPages.UsuarioLogado);
            }
            else
            {
                string text = dlsIMDb.GetElementText(LoginPages.MsgErro).Trim();
                dlsIMDb.ValidAssertAreEqual(text,mensagem);
            }
        }
    }
}
