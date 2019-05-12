using LeBonAngle.Models;
using LeBonAngle.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeBonAngle.Services
{
    public class BonAngleWebServices
    {
        ////Exemples API1 (sans authentification)
        //const string url = @"https://tranquil-harbor-23814.herokuapp.com/api/v1/listings";
        //public async Task<List<Announce>> APIV1_GetAnnounces()
        //{
        //    HttpClient client = new HttpClient();
        //    var brutdata = await client.GetStringAsync(url);
        //    return JsonConvert.DeserializeObject<List<Announce>>(brutdata);
        //}


        //Exemple API2 (avec authentification)

        public async Task<bool> APIV2_AuthenticateUser()
        {
            try
            {
                HttpClient clientTest = new HttpClient();
                Dictionary<string, string> keys = new Dictionary<string, string>();
                keys.Add("email", Settings.Login);
                keys.Add("password", Settings.Pwd);
                FormUrlEncodedContent content = new FormUrlEncodedContent(keys);
                var response = await clientTest.PostAsync(@"https://best-team-listing.herokuapp.com/api/v1/auth", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //TODO On récupère le token retourné, et on l'enregistre
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Authenticate>(responsedata);
                    Settings.TokenAPI = responseformatted.Token;
                    return true;
                }
                else
                {
                    Settings.TokenAPI = String.Empty;
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Settings.TokenAPI = String.Empty;
                return false;
            }
        }

        public async Task<bool> APIV2_PostAnnounce(Product product)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var contentstring = "{\"product\":" + JsonConvert.SerializeObject(product)  + "}";
                StringContent content = new StringContent(contentstring, Encoding.UTF8, "application/json");
                //content.Headers.Add("token", Settings.TokenAPI);
                var response = await client.PostAsync(@"https://best-team-listing.herokuapp.com/api/v1/product", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //TODO on vérifie le product ?
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    if (responseformatted.Success == "true" 
                        && responseformatted.Products != null 
                        && responseformatted.Products.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //API_Response_Category
        public async Task<List<Category>> APIV2_GetCategories()
        {
            List<Category> resultats = new List<Category>();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://best-team-listing.herokuapp.com/api/v1/category");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Category>(responsedata);
                    return responseformatted.Categories;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetCategories();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }

        public async Task<List<Product>> APIV2_GetAnnounces()
        {
            List<Product> resultats = new List<Product>();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://best-team-listing.herokuapp.com/api/v1/product");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    return responseformatted.Products;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetAnnounces();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultats;
        }

        public async Task<Product> APIV2_GetAnnounce(string id)
        {
            Product resultat = new Product();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://best-team-listing.herokuapp.com/api/v1/product/"+id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_Products>(responsedata);
                    if (responseformatted.Products.Count > 0)
                    return responseformatted.Products[0];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetAnnounce(id);
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }

        public async Task<User> APIV2_GetMyAccount()
        {
            User resultat = new User();
            if (String.IsNullOrWhiteSpace(Settings.TokenAPI))
            {
                await APIV2_AuthenticateUser();
            }

            try
            {
                HttpClient clientTest = new HttpClient();
                clientTest.DefaultRequestHeaders.Add("token", Settings.TokenAPI);
                var response = await clientTest.GetAsync(@"https://best-team-listing.herokuapp.com/api/v1/account");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //OK, on désérialise et retourne le résultat
                    var responsedata = await response.Content.ReadAsStringAsync();
                    var responseformatted = JsonConvert.DeserializeObject<API_Response_User>(responsedata);
                    return responseformatted.User;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //RéAuthentifie
                    if (await APIV2_AuthenticateUser())
                    {
                        //On rejoue la requête après authentification correcte
                        return await APIV2_GetMyAccount();
                    }
                    else
                    {
                        //Réauthentification NOK... dialog ?
                    }
                }
                //else
                //{
                //    //autre erreur
                //}

            }
            catch (Exception ex)
            {

            }
            return resultat;
        }
    }
}
