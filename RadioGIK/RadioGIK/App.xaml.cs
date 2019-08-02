using RadioGIK.Providers;
using RadioGIK.Service;
using RadioGIK.ViewModels;
using RadioGIK.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Xamarin.Forms;

namespace RadioGIK
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            var wc = new WebClient();
            var s = await wc.DownloadStringTaskAsync(@"https://stream.gikradio.com/pls/app.pls");
            var w = s.Split(new char[] { '\n' });
             Debug.WriteLine(nameof(this.OnStart));
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            //Debug.WriteLine(nameof(this.OnSleep));
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            //if (MediaPlayerService.Instance.IsPlaying())
            //{
            //    MediaPlayerService.Instance.Stop();
            //    await MediaPlayerService.Instance.Play();
            //}
           // Debug.WriteLine(nameof(this.OnResume));
            //MainPageViewModel mainPageViewModel = new MainPageViewModel();
            //DataProvider dataProvider = new DataProvider();
            //mainPageViewModel.SongInfo = await dataProvider.GetSongInfoAsync(Constants.Constants.pathToDate);
        }
    }
}
