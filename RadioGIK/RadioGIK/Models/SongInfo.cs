using System;
using System.Collections.Generic;
using System.Text;

namespace RadioGIK.Models
{
    public class SongInfo : BindableBase
    {
        private string artist;
        private string title;
        private string combine;
        private string album;
        private string cover;
        private string duration;
        private string songId;
        private string timer;

        public string Artist
        {
            get => artist;
            set
            {
                if (artist != value)
                {
                    artist = value.ToUpper();
                    OnPropertyChanged(nameof(this.Artist));
                }
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(this.Title));
                }
            }
        }

        public string Combine
        {
            get => combine;
            set
            {
                if (combine != value)
                {
                    combine = value;
                    OnPropertyChanged(nameof(this.Combine));

                }
            }
        }

        public string Album
        {
            get => album;
            set
            {
                if (album != value)
                {
                    album = value;
                    OnPropertyChanged(nameof(this.Album));
                }
            }
        }

        public string Cover
        {
            get => cover;
            set
            {
                if (cover != value)
                {
                    cover = value;
                    OnPropertyChanged(nameof(this.Cover));
                }
            }
        }

        public string Duration
        {
            get => duration;
            set
            {
                if (duration != value)
                {
                    duration = value;
                    OnPropertyChanged(nameof(this.Duration));
                }
            }
        }

        public string Songid
        {
            get => songId;
            set
            {
                if (songId != value)
                {
                    songId = value;
                    OnPropertyChanged(nameof(this.Songid));
                }
            }
        }

        public string Timer
        {
            get => timer;
            set
            {
                if (timer != value)
                {
                    timer = value;
                    OnPropertyChanged(nameof(this.Timer));
                }
            }
        }

    }
}
