using Automation.Base;
using Automation.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Automation.BDD.Steps
{
    class WatchListStep : BaseTestBDD
    {
        [Given(@"acesso pagina de (.*) através do menu")]
        public void DadoAcessoPaginaDeAtravesDoMenu(string itemMenu)
        {
            dslIMDb.ClickOnButton("Menu");

            dslIMDb.ClickOnButton(itemMenu);
        }

        [Given(@"seleciono um filme que não esteja no meu watchlits")]
        public void DadoSelecionoUmFilmeQueNaoEstejaNoMeuWatchlits()
        {
            dslIMDb.Click(WatchListPages.selectFilm);

            var textElement = dslIMDb.GetElementText(WatchListPages.titleFilmeXPath);
            WatchListPages.titleFilm = textElement.Substring(0, textElement.Length-7);
        }

        [When(@"abro minha watchlist")]
        [Given(@"abro minha watchlist")]
        public void QuandoAbroMinhaWatchlist()
        {
            dslIMDb.ClickOnButton("Watchlist");
        }

        [Then(@"valido que o filme foi adicionado")]
        public void EntaoValidoQueOFilmeFoiAdicionado()
        {
            dslIMDb.ValidAssertIsTrue
                (WatchListPages.GetTitleFilmWatchlist(WatchListPages.titleFilm)); 
        }

        [When(@"clico no botão para remover o filme")]
        public void QuandoClicoNoBotaoParaRemoverOFilme()
        {
            WatchListPages.titleFilm = dslIMDb.GetElementProperty(WatchListPages.wacthlistTitle, "alt");
            dslIMDb.Click(WatchListPages.removeFilm);
        }

        [Then(@"valido que o filme foi removido da minha watchlist")]
        public void EntaoValidoQueOFilmeFoiRemovidoDaMinhaWatchlist()
        {
            dslIMDb.RefreshPage();

            dslIMDb.ValidAssertIsFalse
                (WatchListPages.GetTitleFilmWatchlist(WatchListPages.titleFilm));
        }

    }
}
