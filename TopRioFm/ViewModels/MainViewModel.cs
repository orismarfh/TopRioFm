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
	//	public Command GoToPlay { get; }
      //  public Command GoToPause { get; }

		public MainViewModel ()
		{
			PauseCommand = new Command (ExecutePauseCommand);
			PlayCommand = new Command (ExecutePlayCommand);
			LinkFaceCommand = new Command (ExecuteLinkFaceCommand);
			LinkInstaCommand = new Command (ExecuteLinkInstaCommand);
        //    GoToPlay = new Command(GoToPlay);
          //  GoToPause = new Command(GoToPause);
        

       
                Task.Factory.StartNew(async() =>
                {
                    await CrossMediaManager.Current.Play("http://streaming32.hstbr.net:8334/live");
                });       
		}

        private bool _goToPause;
        public bool GoToPause
        {
            get { return _goToPause; }
            set{ SetProperty(ref _goToPause, value); }
        }
		private bool _goToPlay;
		public bool GoToPlay
		{
			get { return _goToPlay; }
            set { SetProperty(ref _goToPlay, value); }
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