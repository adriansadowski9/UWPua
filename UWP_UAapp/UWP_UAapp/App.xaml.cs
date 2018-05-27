using System;
using Xamarin.Forms;
using UWP_UAapp.Views;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;
using UWP_UAapp.Models;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace UWP_UAapp
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();
            MainPage = new MainMenu();
		}
        protected override async void OnStart()
        {
            IFolder root = FileSystem.Current.LocalStorage;
            IFolder folder = await root.CreateFolderAsync("UAappStorage", CreationCollisionOption.OpenIfExists);
            string fileName = "places.txt";
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            try
            {
                string content = await file.ReadAllTextAsync();
                if (content.Length == 0)
                {
                    MessagingCenter.Send(this, "LoadItems", new List<Item>{
                new Item { Id = Guid.NewGuid().ToString(), Name = "Pałac Kultury i Nauki", Description="PKiN – najwyższy budynek w Polsce, znajdujący się w Śródmieściu Warszawy na placu Defilad 1. Właścicielem gmachu jest miasto stołeczne Warszawa.", Street = "plac Defilad 1", Zip_Code = "00-901", City = "Warszawa", GMaps_Link = "https://www.google.pl/maps/place/Pa%C5%82ac+Kultury+i+Nauki/@52.231838,21.005995,15z/data=!4m2!3m1!1s0x0:0xc2e97ae5311f2dc2?sa=X&ved=0ahUKEwjm9onuxaXbAhWFFJoKHVUVD4UQ_BIIvwEwEQ" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Zamek Królewski na Wawelu", Description="Zamek obronno-rezydencyjny w Krakowie, na Wawelu, o powierzchni 7040 m² z 71 salami wystawowymi.", Street = "Wawel 5", Zip_Code = "31-001", City = "Kraków", GMaps_Link = "https://www.google.pl/maps/place/Zamek+Kr%C3%B3lewski+na+Wawelu/@50.0540495,19.9354123,15z/data=!4m2!3m1!1s0x0:0xacb9dfc4d67fa598?sa=X&ved=0ahUKEwjN1JqZxqXbAhUkyqYKHYYXBbIQ_BII0wEwDg" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański", Description="Polska szkoła wyższa z siedzibą w Gdańsku, utworzona 20 marca 1970.", Street = "Jana Bażyńskiego 8", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Bazylika archikatedralna w Gdańsku-Oliwie", Description="Archikatedra gdańska – kościół pw. Trójcy Świętej, NMP i św. Bernarda w Gdańsku, w dzielnicy Oliwa.", Street = "Biskupa Edmunda Nowickiego 5", Zip_Code = "80-330", City = "Gdańsk", GMaps_Link = "https://www.google.pl/maps/place/Archikatedra+Oliwska/@54.4109142,18.5580336,15z/data=!4m2!3m1!1s0x0:0x68acf09e5e8fa73d?sa=X&ved=0ahUKEwjaoLLqxqXbAhWoQJoKHXP2AdAQ_BIImgEwEg" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Stadion Narodowy w Warszawie", Description="Stadion Narodowy w Warszawie, od lipca 2015 pod nazwą PGE Narodowy – wielofunkcyjny stadion sportowy im. Kazimierza Górskiego.", Street = "aleja Poniatowskiego 1", Zip_Code = "03-901", City = "Warszawa", GMaps_Link = "https://www.google.pl/maps/place/PGE+Narodowy/@52.2394957,21.0457909,15z/data=!4m2!3m1!1s0x0:0x6243befa18b5188b?sa=X&ved=0ahUKEwjp-qqZx6XbAhXjNJoKHWsxArAQ_BIIzgEwEA" }
            });
                }
                else
                {
                    MessagingCenter.Send(this, "LoadItems", JsonConvert.DeserializeObject<List<Item>>(content));
                }
            }
            catch (System.NullReferenceException e)
            {
                Debug.WriteLine(e);
            }
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
