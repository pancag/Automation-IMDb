using Automation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DSL
{
    public class DSLIMDb : BaseDSL
    {
        public void SendKeysToTextField(string fieldTitle, string value)
        {
            try
            {
                var inputFieldXPath = $"//div[contains(@class,'cl-row block')][not(contains(@class,'hidden'))][./div[@class='cl-fld-title']//descendant::span[translate(text(),'{upperLetters}','{lowerLetters}')='{fieldTitle.ToLower()}']]/descendant::div[@class='cl-fld-value']//input";

                SendKeys(inputFieldXPath, value);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao enviar valor {value} para campo de texto.\n{e.Message}");
            }
        }
    }
}
