//**************************************************************************
//  The code in this class is same as found in the XLabs on GitHub.
//  (The link is: https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/Samples/XLabs.Sample/ViewModel/CameraViewModel.cs)
//
//  The exceptions are:
//    1) The scope of the following 3 methods have been
//         changed from 'private' to 'public', so that they can be called directly
//         from another method / event in which using BindingContext to this class
//         is not possible:
//           1. TakePicture ()
//           2. SelectPicture ()
//           3. SelectVideo ()
//
//   2) ViewType declaration is commented.
//
//   3) In SelectPicture () method, setting VideoInfo to the MediaFile.Path
//
//  Dated: Feb. 26, 2015
//
//**************************************************************************
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace XPA_PickMedia_XLabs_XFP
{
	//[ViewType(typeof(CameraPage))]

	public class CameraViewModel : ViewModel
	{
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
		private IMediaPicker _Mediapicker;
		private ImageSource _ImageSource;
		private Command _TakePictureCommand;
		private Command _SelectPictureCommand;
		private string _Status;

		public CameraViewModel ()
		{
			Setup ();
		}

		public ImageSource ImageSource
		{
			get { return _ImageSource; }
			set { SetProperty (ref _ImageSource, value); }
		}

		public Command TakePictureCommand
		{
			get {
				return _TakePictureCommand ?? (_TakePictureCommand =
					new Command (async () => await TakePicture (), () => true));
			}
		}

		public Command SelectPictureCommand
		{
			get {
				return _SelectPictureCommand ?? (_SelectPictureCommand =
					new Command (async () => await SelectPicture (), () => true));
			}
		}

		public string Status
		{
			get { return _Status; }
			set { SetProperty (ref _Status, value); }
		}

		private void Setup()
		{
			if (_Mediapicker == null) {
                var device = Resolver.Resolve<IDevice>();
                _Mediapicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
			}
		}

		public async Task<MediaFile> TakePicture()
		{
			Setup ();

			ImageSource = null;

            if (_Mediapicker.IsCameraAvailable)
            {
                return await _Mediapicker.TakePhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Rear,
                    MaxPixelDimension = 400,
                    SaveMediaOnCapture = true
                }).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Status = t.Exception.InnerException.ToString();
                    }
                    else if (t.IsCanceled)
                    {
                        Status = "Canceled";
                    }
                    else
                    {
                        var mediaFile = t.Result;
                        ImageSource = ImageSource.FromStream(() => mediaFile.Source);

                        return mediaFile;
                    }

                    return null;
                }, _scheduler);
            }
            else
            {
                return null;
            }
		}

		public async Task SelectPicture()
		{
			Setup ();

			ImageSource = null;

			try
			{
				var mediaFile = await _Mediapicker.SelectPhotoAsync(new CameraMediaStorageOptions
					{
						DefaultCamera = CameraDevice.Rear,
						MaxPixelDimension = 400
					});
				ImageSource = ImageSource.FromStream(() => mediaFile.Source);
			}
			catch (System.Exception ex)
			{
				Status = ex.Message;
			}
		}

		private static double ConvertBytesToMegabytes(long bytes)
		{
			double rtn_value = (bytes / 1024f) / 1024f;

			return rtn_value;
		}
	}
}

