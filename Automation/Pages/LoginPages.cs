using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Pages
{
    public class LoginPages
    {
        public static By btnSignIn = By.XPath("//*[@id=\"signInSubmit\"]");
        public static By CampoEmail = By.Id("ap_email");
        public static By CampoSenha = By.Id("ap_password");
        public static By MsgErro = By.XPath("//span[@class='a-list-item']");
        public static By UsuarioLogado = By.XPath("//div[@class='ipc-button__text']");

    }
}
