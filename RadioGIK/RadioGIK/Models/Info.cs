using System;
using System.Collections.Generic;
using System.Text;

namespace RadioGIK.Models
{
    public class Info
    {
        private string artist;

        public string Picture { get; set; }
        public string Artist
        {
            get => this.artist;
            set
            {
                this.artist = value.ToUpper();
            }
        }
        public string Title { get; set; }
        public string Time { get; set; }
    }
}
