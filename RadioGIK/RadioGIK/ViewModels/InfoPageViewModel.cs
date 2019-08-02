using Newtonsoft.Json;
using RadioGIK.Models;
using RadioGIK.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace RadioGIK.ViewModels
{
    public class InfoPageViewModel : BindableBase
    {
        private ObservableCollection<Info> infoCollection;
        private string title;
        private DataProvider dataProvider;

        public InfoPageViewModel(ContextPage contextPage)
        {
            this.dataProvider = new DataProvider();

            this.ContextPage = contextPage;
            this.InfoCollection = new ObservableCollection<Info>();
            this.CloseButton = (FileImageSource)ImageSource.FromFile(Constants.Constants.closeButton);
            this.BackCommand = new Command(BackExecute);
            this.GetInfo(this.ContextPage);
        }

        public ContextPage ContextPage { get; set; }

        public string Title
        {
            get => this.title;
            set
            {
                if (this.title != value)
                    this.title = value;
                OnPropertyChanged(nameof(this.Title));

            }
        }

        public FileImageSource CloseButton { get; set; }

        public ICommand BackCommand { get; set; }

        public ObservableCollection<Info> InfoCollection
        {
            get => this.infoCollection;
            set
            {
                if (this.infoCollection != value)
                {
                    this.infoCollection = value;
                    OnPropertyChanged(nameof(this.InfoCollection));
                }
            }
        }

        public string Path { get; private set; }

        private async void BackExecute()
        {
            await Application.Current.MainPage.Navigation.PopAsync(false);
        }

        private async void GetInfo(ContextPage contextPage)
        {
            SetPath(contextPage);
            this.InfoCollection = await this.dataProvider.GetInfoAsync(this.Path);
        }

        private void SetPath(ContextPage contextPage)
        {
            switch (contextPage)
            {
                case ContextPage.HistoryPage:
                    this.Path = Constants.Constants.historyInfo;
                    this.Title = Constants.Constants.historyTitle;
                    break;
                case ContextPage.NextPage:
                    this.Path = Constants.Constants.nextInfo;
                    this.Title = Constants.Constants.nextTitle;
                    break;
                case ContextPage.SchedulePage:
                    this.Path = Constants.Constants.scheduleInfo;
                    this.Title = Constants.Constants.scheduleTitle;
                    break;
            }
        }
    }
}
