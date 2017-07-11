using System;
using System.Threading.Tasks;
using AudioForms.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;

namespace Furacao2000
{
	public class MainViewModel : BaseViewModel
	{
		private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

		public Command PauseCommand { get; }
		public Command PlayCommand { get; }
		public Command LinkFaceCommand { get; }
		public Command LinkInstaCommand { get; }

		public MainViewModel ()
		{
			PauseCommand = new Command (ExecutePauseCommand);
			PlayCommand = new Command (ExecutePlayCommand);
			LinkFaceCommand = new Command (ExecuteLinkFaceCommand);
			LinkInstaCommand = new Command (ExecuteLinkInstaCommand);
            System.Diagnostics.Debug.WriteLine("1");
            try
            {
                Task.Factory.StartNew(async() =>
                {
                    await CrossMediaManager.Current.Play("http://streaming32.hstbr.net:8334/live");
                });
            }
            catch(Exception e)
            {
                var a = e;
            }
			System.Diagnostics.Debug.WriteLine("2");
		}

		void ExecuteLinkInstaCommand (object obj)
		{
			Device.OpenUri (new Uri ("https://www.instagram.com/topriofm/"));
		}

		                  
		void ExecuteLinkFaceCommand (object obj)
		{
			Device.OpenUri (new Uri ("https://www.facebook.com/toprio971fm/"));
		}

		void ExecutePlayCommand (object obj)
		{
			PlaybackController.Play ();
		}

		void ExecutePauseCommand (object obj)
		{
			PlaybackController.Pause ();
		}


		
	}
}