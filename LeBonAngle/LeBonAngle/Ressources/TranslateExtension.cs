using LeBonAngle.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonAngle.Ressources
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "LeBonAngle.Ressources.MyAppRessources";

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                if (Text == null)
                    return "";

                ResourceManager resmgr = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

                string translation = resmgr.GetString(Text, ci);

                if (String.IsNullOrWhiteSpace(translation))
                {
                    Console.WriteLine($"Key {Text} not found in resources {ResourceId} for culture {ci.Name}");

                    translation = Text;
                }
                return translation;
            }
            catch (Exception ex)
            {
                return Text;
            }
        }
    }
}
