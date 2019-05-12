using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Foundation;
using LeBonAngle.Interfaces;
using LeBonAngle.iOS.Implementation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizeiOS))]
namespace LeBonAngle.iOS.Implementation
{
    public class LocalizeiOS : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "fr";
            var prefLanguageOnly = "fr";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                Console.WriteLine("preferred language:" + netLanguage);
            }
            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                ci = new CultureInfo(prefLanguageOnly);
            }
            return ci;
        }
    }
}