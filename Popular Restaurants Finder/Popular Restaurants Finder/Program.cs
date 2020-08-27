using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Http = RestSharp.Http;

namespace Popular_Restaurants_Finder
{
    class Program
    {
        public static string location;
        static void Main(string[] args)
        {
            //Console.WriteLine("_____________________________________________________");
            //Console.WriteLine("Hello! Welcome to Jinda's Popular Restaurant Finder!");
            //Console.WriteLine("_____________________________________________________");
            //Console.WriteLine("_____________________________________________________");
            //Console.WriteLine("                                                     ");

            //Console.Write("Enter the desired location: ");
            //location = Console.ReadLine();

            convertLocation("vancouver");

            Console.ReadLine();
        }

        static void FindRestaurants(float lat, float lang)
        {
            var client = new RestClient("https://appetitoso-best-food-dishes-v1.p.rapidapi.com/dish/suggestions/?radius=15&lang=it&lat=" + lat + "&lng=" + lang);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "appetitoso-best-food-dishes-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "2c55019311msha703d4f4d477ac6p1b0a95jsn20b3f6f65c02");
            IRestResponse response = client.Execute(request);
            //https://rapidapi.com/appetitoso/api/food-search-engine?endpoint=55cdb48ce4b0b74f06700640


        }

        static void convertLocation(string location) //AIzaSyDvpMap1ymxW9JFxPc_WT9JvJWbxG0fhP0 <- API key
        {
            var client = new RestClient("https://google-maps-geocoding.p.rapidapi.com/geocode/json?language=en&address=" + location);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "google-maps-geocoding.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "2c55019311msha703d4f4d477ac6p1b0a95jsn20b3f6f65c02");
            IRestResponse response = client.Execute(request);
            JObject jobject = JObject.Parse(response.Content);

            var lat = jobject["results"]
           
            
            //["bounds"]["northeast"]["lat"];

            Console.WriteLine(lat);

            //float lat = jobject.GetValue("results");

        }



    }
}
