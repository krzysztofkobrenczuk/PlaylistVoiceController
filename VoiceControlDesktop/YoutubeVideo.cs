using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlDesktop
{
    public class YoutubeVideo
    {
        public string Id { get; set; }
        public string Title { get; set; }
  
        public YoutubeVideo(string id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
