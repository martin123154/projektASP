using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teatr.Helpery
{
    public static class SwojeHelpery
    {
      

        public static string WstawTekst(string tekst)
        {
            return String.Format("Witamy użytkownika " + tekst + " na stronie projektu!");
        }
    }
}