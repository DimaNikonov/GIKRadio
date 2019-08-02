using Android.Media;
using System;
using System.Threading.Tasks;

namespace RadioGIK.Service
{
    public sealed class MediaPlayerService
    {
        private static readonly Lazy<MediaPlayerService> instanse = new Lazy<MediaPlayerService>(() => new MediaPlayerService());

        public static MediaPlayerService Instance => instanse.Value;

        private MediaPlayer player;

        private MediaPlayerService()
        {
            player = new MediaPlayer();
        }

        public bool IsPlaying => player.IsPlaying;

        //public bool IsPlaying() => player.IsPlaying;

        public async Task Play()
        {
            //player.Reset();
            await Task.Run(() =>
            {
                this.player.Reset();
                this.player.SetDataSource(Constants.Constants.streamRadio);
                this.player.Prepare();
                this.player.Start();
            });
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
