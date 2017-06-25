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
        private int _actualVideoId;
        private readonly YoutubeApiWrapper _youtube = new YoutubeApiWrapper("youtube-api-key");

        private YoutubeVideo[] _videos;

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
            _actualVideoId = 0;

            try
            {
                Choices commands = new Choices();
                commands.Add(new string[] { "dalej", "poprzednia"});
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commands);
                Grammar grammar = new Grammar(gBuilder);

                recEngine.LoadGrammarAsync(grammar);
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.SpeechRecognized += recEngine_SpeechRecognized;

                recEngine.RecognizeAsync(RecognizeMode.Multiple);
                MicroBtn.Enabled = true;
            }
            catch (PlatformNotSupportedException e)
            {
                MessageBox.Show(this, e.Message, "Platform not supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MicroBtn.Text = "Speech recognition not available";
                MicroBtn.Enabled = false;
            }


        }

        private void OnBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string playListId = aPlaylistBox.Text;

            _videos = _youtube.GetPlaylistVideos(playListId).ToArray();

            webBrowser1.Navigate(YoutubeApiWrapper.GetVideoEmbedHtml(_videos[0].Id));
            listBox1.Items.AddRange(_videos.Select(v => v.Title).Cast<object>().ToArray());           
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            switch (e.Result.Text)
            {
                case "dalej":
                    PlayNextVideo();
                    break;
                case "poprzednia":
                    PlayPreviousVideo();
                    break;
            }
        }
        private void OffBtn_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            MicroBtn.Enabled = false;
        }


        private void PlayNextVideo()
        {
            webBrowser1.Navigate(YoutubeApiWrapper.GetVideoEmbedHtml(_videos[++_actualVideoId].Id));
        }
        private void PlayPreviousVideo()
        {
            webBrowser1.Navigate(YoutubeApiWrapper.GetVideoEmbedHtml(_videos[--_actualVideoId].Id));
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            PlayNextVideo();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            PlayPreviousVideo();
        }
    }
}
