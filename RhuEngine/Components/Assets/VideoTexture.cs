﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using LibVLCSharp.Shared;

using RhuEngine.VLC;
using RhuEngine.WorldObjects;
using RhuEngine.WorldObjects.ECS;

using StereoKit;


namespace RhuEngine.Components
{
	[Category(new string[] { "Assets" })]
	public class VideoTexture : AssetProvider<Tex>
	{
		public VlcVideoSourceProvider vlcVideoSourceProvider = null;
		public AudioOutput audioOutput;

		LibVLC _libVLC;
		MediaPlayer _mediaPlayer;

		private async Task LoadVideo() {
			try {
				if (vlcVideoSourceProvider != null) {
					Log.Info("Reloading Loading Video Player");
					Load(null);
					vlcVideoSourceProvider.Dispose();
					vlcVideoSourceProvider = null;
					_libVLC = null;
					_mediaPlayer = null;
				}
				else {
					Log.Info("Loading Video Player");
				}
				vlcVideoSourceProvider = new VlcVideoSourceProvider();
				Load(vlcVideoSourceProvider.VideoSource);

				Core.Initialize();
				_libVLC = new LibVLC(enableDebugLogs: true);
				_mediaPlayer = new MediaPlayer(_libVLC);
				vlcVideoSourceProvider.LoadPlayer(_mediaPlayer);
				vlcVideoSourceProvider.RelaodTex += VlcVideoSourceProvider_RelaodTex;
				vlcVideoSourceProvider.LoadAudio += audioOutput.WriteAudio;

				//var media = new Media(_libVLC, "C:\\Users\\Faolan\\Pictures\\Trains.mp4",FromType.FromPath);
				var uri = new Uri("https://rhubarbvr.net/Trains.mp4");
				var media = new Media(_libVLC, uri);
				if (VideoImporter.IsVideoStreaming(uri)) {
					await media.Parse(MediaParseOptions.ParseNetwork);
				}
				while (media.State == VLCState.Buffering) {
							Thread.Sleep(10);
				}
				_mediaPlayer.Play(media);
				//_mediaPlayer.Play(media.SubItems[0]);
			}
			catch (Exception ex) 
			{
				Log.Err($"Failed to start Video Player Error:{ex}");
			}
		}

		private void VlcVideoSourceProvider_RelaodTex() {
			Load(null);
			Load(vlcVideoSourceProvider.VideoSource);
		}

		public override void OnLoaded() {
			base.OnLoaded();
			LoadVideo().ConfigureAwait(false);
		}
	}
}