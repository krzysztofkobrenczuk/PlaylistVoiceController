using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.Speech.Recognition;


namespace VoiceControlDesktop
{
    public partial class Form1 : Form
    {        
        int i = 0;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void OnBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string playListId = aPlaylistBox.Text;
            YoutubeVideo[] videos = YoutubeApi.GetPlaylist(playListId);

            i = 0;
            string videoId = videos[i].id.ToString();
            webBrowser1.DocumentText = @"<object width='425' height='355'><param name='movie' value='http://www.youtube.com/v/" + videoId + "?version=3&amp;autoplay=1" + "'></param><param name='wmode' value='transparent'></param><embed src='http://www.youtube.com/v/" + videoId + "?version=3&amp;autoplay=1" + "' type='application/x-shockwave-flash' wmode='transparent' width='425' height='355'></embed></object>";

            foreach (var video in videos)
            {
                listBox1.Items.Add(video.id);
            }

            Choices commands = new Choices();
            commands.Add(new string[] { "start", "dalej", "poprzednia", "losuj" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            OffBtn.Enabled = true;
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string playListId = aPlaylistBox.Text;
            YoutubeVideo[] videos = YoutubeApi.GetPlaylist(playListId);

            switch (e.Result.Text)
            {
                case "dalej":
                    i++;
                    string videoIdNext = videos[i].id.ToString();
                    webBrowser1.DocumentText = @"<object width='425' height='355'><param name='movie' value='http://www.youtube.com/v/" + videoIdNext + "?version=3&amp;autoplay=1" + "'></param><param name='wmode' value='transparent'></param><embed src='http://www.youtube.com/v/" + videoIdNext + "?version=3&amp;autoplay=1" + "' type='application/x-shockwave-flash' wmode='transparent' width='425' height='355'></embed></object>";  
                    break;
                case "poprzednia":
                    i--;
                    string videoIdPrevious = videos[i].id.ToString();
                    webBrowser1.DocumentText = @"<object width='425' height='355'><param name='movie' value='http://www.youtube.com/v/" + videoIdPrevious + "?version=3&amp;autoplay=1" + "'></param><param name='wmode' value='transparent'></param><embed src='http://www.youtube.com/v/" + videoIdPrevious + "?version=3&amp;autoplay=1" + "' type='application/x-shockwave-flash' wmode='transparent' width='425' height='355'></embed></object>";
                    break;

                case "losuj":


                    break;
            }
        }
        private void OffBtn_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            OffBtn.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
