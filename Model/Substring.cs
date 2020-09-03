using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model
{
    public static class Substring
    {

        public static string GetSubstringNoIncluded(string text, string startText, string lastText)
        {
            try
            {
                text = text.Substring(text.IndexOf(startText) + startText.Length);
                text = text.Substring(0, text.LastIndexOf(lastText));
                return text;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                return string.Empty;
            }
        }
        public static string GetSubstringStartIncluded(string text, string startText, string lastText)
        {
            try
            {
                text = text.Substring(text.IndexOf(startText));
                text = text.Substring(0, text.LastIndexOf(lastText));
                return text;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                return string.Empty;
            }
        }
        public static string GetSubstringLastIncluded(string text, string startText, string lastText)
        {
            try
            {
                text = text.Substring(text.IndexOf(startText) + startText.Length);
                text = text.Substring(0, text.LastIndexOf(lastText) + lastText.Length);
                return text;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                return string.Empty;
            }
        }
        public static string GetSubstringIncluded(string text, string startText, string lastText)
        {
            try
            {
                text = text.Substring(text.IndexOf(startText));
                text = text.Substring(0, text.LastIndexOf(lastText) + lastText.Length);
                return text;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                return string.Empty;
            }
        }
    }
}
