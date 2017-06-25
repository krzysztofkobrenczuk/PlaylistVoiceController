using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlDesktop
{
    public class YoutubeApiWrapper
    {
        private readonly YouTubeService _ytService;

        public YoutubeApiWrapper(string apiKey)
        {
            _ytService = new YouTubeService(new BaseClientService.Initializer
            {
                 ApiKey = apiKey,
                 ApplicationName = "videoplaylistplayer"
            });
        }
        public IEnumerable<YoutubeVideo> GetPlaylistVideos(string playlistId)
        {
            var request = _ytService.PlaylistItems.List("snippet");
            request.PlaylistId = playlistId;

            var videos = new List<YoutubeVideo>();
            string nextPage = "";

            while(nextPage != null)
            {
                request.PageToken = nextPage;

                var response = request.Execute();
                videos.AddRange(response.Items.Select(v => new YoutubeVideo(v.Snippet.ResourceId.VideoId, v.Snippet.Title)));
                nextPage = response.NextPageToken;
            }
            return videos;
        }

        public static string GetVideoEmbedHtml(string videoId)
        {
            return $"http://www.youtube.com/v/{videoId}?autoplay=1";
        }

    }
}
