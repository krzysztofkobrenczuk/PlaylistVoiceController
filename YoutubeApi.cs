using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;

namespace VoiceControlDesktop
{
    public class YoutubeApi
    {
        private static YouTubeService ytService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential creds;
            using (var stream = new FileStream("youtube_client_secret.json", FileMode.Open, FileAccess.Read))
            {
                creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("YoutubeApi")
                    ).Result;
            }
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "YoutubeApi"
            });
            return service;
        }


        internal static YoutubeVideo[] GetPlaylist(string playlistId)
        {
            var request = ytService.PlaylistItems.List("contentDetails");
            request.PlaylistId = playlistId;


            LinkedList<YoutubeVideo> videos = new LinkedList<YoutubeVideo>();

            string nextPage = "";

            while (nextPage != null)
            {
                request.PageToken = nextPage;

                var response = request.Execute();

                int i = 0;
                foreach (var item in response.Items)
                {
                    videos.AddLast(new YoutubeVideo(item.ContentDetails.VideoId));
                }
                nextPage = response.NextPageToken;
            }

            return videos.ToArray<YoutubeVideo>();
        }

        public static void GetVideoInfo(YoutubeVideo video)
        {
            var videoRequest = ytService.Videos.List("snippet");
            videoRequest.Id = video.id;

            var response = videoRequest.Execute();
        }
    }
}