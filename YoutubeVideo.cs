using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceControlDesktop
{
    public class YoutubeVideo
    {
        public string id;
  
        public YoutubeVideo(string id)
        {
            this.id = id;
            YoutubeApi.GetVideoInfo(this);
        }
    }
}
