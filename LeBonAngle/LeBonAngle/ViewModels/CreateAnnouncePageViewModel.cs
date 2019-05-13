using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ListingOgGang.Models;
using ListingOgGang.Views;
using ListingOgGang.Ressources;
using ListingOgGang.Utils;
using ListingOgGang.Services;

namespace ListingOgGang.ViewModels
{
    public class CreateAnnouncePageViewModel : BaseViewModel
    {
        public CreateAnnouncePageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = "Poster une annonce";
            SubmitCommand = new Command(async () => await ExecuteSubmitCommand());

        }

        private string titre;
        public string Titre
        {
            get { return titre; }
            set { SetProperty(ref titre, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private string prix;
        public string Prix
        {
            get { return prix; }
            set { SetProperty(ref prix, value); }
        }


        private string errorMessage = String.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Command SubmitCommand { get; set; }
        private async Task ExecuteSubmitCommand()
        {
            IsBusy = true;

            try
            {
                double price = 0;
                if (!String.IsNullOrWhiteSpace(Titre)
                    && !String.IsNullOrWhiteSpace(Description)
                    && !String.IsNullOrWhiteSpace(Prix)
                    && Double.TryParse(Prix, out price))
                {
                    Post product = new Post();
                    product.Title = Titre;
                    product.Description = Description;
                    product.Price = price;
                    product.Category_ID = "1";

                    ListingWebServices client = new ListingWebServices();
                    //TODO Changer l'API quand dispo...
                    var result = await client.APIV2_PostAnnounce(product);
                    if (result)
                    {
                        //Post OK, on revient à l'écran précédent
                        ErrorMessage = "";
                        await NavigationService.PopAsync();
                    }
                    else
                    {
                        ErrorMessage = "Erreur, veuillez ressayer !";
                    }
                }
                else
                {
                    ErrorMessage = "Les renseignement ne sont pas corrects, veuillez vérifier votre saisie.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}