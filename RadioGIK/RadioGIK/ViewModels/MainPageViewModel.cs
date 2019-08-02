using Newtonsoft.Json;
using RadioGIK.Models;
using RadioGIK.Service;
using RadioGIK.Views;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RadioGIK.Constants;
using RadioGIK.Providers;

namespace RadioGIK.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
       // private bool isPlaying;
        private SongInfo songInfo;
        private string startStopButton;
        private DataProvider dataProvider;
        private string cover;

        public MainPageViewModel()
        {
            dataProvider = new DataProvider();
            this.SongInfo = new SongInfo();
            this.StartStopCommand = new Command(StartStopExecute);
            this.HistoryCommand = new Command(NavigationToHystoryExecute);
            this.NextCommand = new Command(NavigationToNextPageExecute);
            this.ScheduleCommand = new Command(NavigationToSchedulePageExecute);
            this.SettingsCmmand = new Command(NavigationToSettingsPageExecute);

            if (!MediaPlayerService.Instance.IsPlaying)

            {
                this.StartStopButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.playButton);
            }
            else
            {
                this.StartStopButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.stopButton);
            }
            this.HistoryButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.historyButton);
            this.SchedullerButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.schedullerButton);
            this.NextButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.nextButton);
            this.SettingsButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.settingsButton);
        }

        public FileImageSource SchedullerButton { get; set; }

        public FileImageSource HistoryButton { get; set; }

        public FileImageSource NextButton { get; set; }

        public FileImageSource SettingsButton { get; set; }

        public FileImageSource StartStopButton
        {
            get => this.startStopButton;
            set
            {
                if (this.startStopButton != value)
                {
                    this.startStopButton = value;
                    OnPropertyChanged(nameof(this.StartStopButton));
                }
            }
        }

        public SongInfo SongInfo
        {
            get => songInfo;
            set
            {
                if (this.songInfo != value)
                {
                    this.songInfo = value;
                    this.Cover = string.Format($"{this.songInfo.Cover}");
                    OnPropertyChanged(nameof(this.SongInfo));
                }
            }
        }

        public string Cover
        {
            get => string.Format($"{this.cover}");
            set
            {
                if (this.cover != value)
                {
                    this.cover = value;
                    OnPropertyChanged(nameof(this.Cover));
                }
            }
        }

        public ICommand StartStopCommand { get; set; }

        public ICommand NextCommand { get; set; }

        public ICommand HistoryCommand { get; set; }

        public ICommand ScheduleCommand { get; set; }

        public ICommand SettingsCmmand { get; set; }

        private async void NavigationToNextPageExecute() =>
            await Application.Current.MainPage.Navigation.PushAsync(new RootPage(ContextPage.NextPage), false);

        private async void NavigationToHystoryExecute() =>
            await Application.Current.MainPage.Navigation.PushAsync(new RootPage(ContextPage.HistoryPage), false);

        private async void NavigationToSchedulePageExecute() =>
            await Application.Current.MainPage.Navigation.PushAsync(new RootPage(ContextPage.SchedulePage), false);

        private async void NavigationToSettingsPageExecute() =>
            await Application.Current.MainPage.Navigation.PushAsync(new SettingsPage(), false);

        private async void StartStopExecute()
        {
            if (!MediaPlayerService.Instance.IsPlaying)
            {
                this.StartStopButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.stopButton);
                this.SongInfo = await dataProvider.GetSongInfoAsync(Constants.Constants.pathToDate);
                await MediaPlayerService.Instance.Play();

                this.TimerStart();

            }
            else
            {
                this.StartStopButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.playButton);

                MediaPlayerService.Instance.Stop();

            }           
        }

        private async void TimerStart()
        {
            int timer = 0;
            while (true)
            {
                int temp = int.Parse(SongInfo.Timer) * 1000;
                if (temp >= 0)
                {
                    if (timer != temp)
                    {
                        //this.SongInfo = await GetSongInfoAsync();
                        timer = temp;
                        await Task.Delay(timer);
                    }
                }
                else
                {
                    await Task.Delay(15000);
                }
                this.SongInfo = await dataProvider.GetSongInfoAsync(Constants.Constants.pathToDate);
            }
        }
    }
}
