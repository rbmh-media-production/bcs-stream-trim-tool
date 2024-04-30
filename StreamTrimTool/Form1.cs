using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;

using System.Net.Http;
using System.IO;

using System.Net;
using System.Threading;




namespace StreamTrimTool
{
    public partial class Form1 : Form
    {
        MasterManifest masterManifestList = new MasterManifest();

        string vlcPlaylistEntry;
        string initUrl;
        int selectedFirstSegmentIndex;
        int selectedLastSegmentIndex;

        public Form1()
        {
            InitializeComponent();

            selectedFirstSegmentIndex = -1;
            selectedLastSegmentIndex = -1;

            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.volume = 100;

            ShowStreamMessageBox();

            // WEB SERVER

            // Define the URL for your endpoint
            string url = "http://localhost:8080/";

            // Start the web server
            StartWebServer(url);
            Console.WriteLine("Server started. Listening for requests at: " + url);

        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                Console.WriteLine("Player stopped.");
            }
        }

        private void ButtonGetStream_Click(object sender, EventArgs e)
        {
            ClearStatusStrip();

            Task t = new Task(DownloadMasterList);
            t.Start();
        }

        async void DownloadMasterList()
        {

            ClearAll();

            try
            {
                //Get Master List Data
                string url = textBoxStreamInput.Text;
                string result;
                // ... Use textBoxStreamInput.
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(url))
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    result = await content.ReadAsStringAsync();
                    WriteToStatusStrip(url + ": " + response.ReasonPhrase);

                }

                string[] splittedPlaybackUrl = url.Split('/');
                string[] splittedResult = result.Split('\n');


                WriteMasterStream(splittedResult);


                //Process Master Manifest Data...

                MasterManifest newManifest = new MasterManifest();

                string baseUrl = "";

                if (url.Contains("akamaihd.net"))
                {
                    Console.WriteLine("MSL3.x");

                    for (int i = 0; i < splittedPlaybackUrl.Length - 1; i++)
                    {
                        baseUrl = baseUrl + splittedPlaybackUrl[i] + "/";
                    }

                    newManifest.BasePlaybackUrl = baseUrl;
                    newManifest.PlaybackUrl = url;
                    newManifest.StreamingConfig = splittedPlaybackUrl[2];
                    newManifest.CpCode = splittedPlaybackUrl[5];
                    newManifest.EventName = splittedPlaybackUrl[6];
                    newManifest.IngestUrl = splittedPlaybackUrl[0] + "//post." + newManifest.StreamingConfig + "/" + newManifest.CpCode + "/" + newManifest.EventName + "/" + splittedPlaybackUrl[splittedPlaybackUrl.Length - 1];
                    newManifest.BaseIngestUrl = splittedPlaybackUrl[0] + "//post." + newManifest.StreamingConfig + "/" + newManifest.CpCode + "/" + newManifest.EventName;
                    newManifest.HttpGetResult = splittedResult;

                }
                else
                {
                    Console.WriteLine("MSL4.x");

                    for (int i = 0; i < splittedPlaybackUrl.Length - 1; i++)
                    {
                        baseUrl = baseUrl + splittedPlaybackUrl[i] + "/";
                    }

                    newManifest.BasePlaybackUrl = baseUrl;
                    newManifest.PlaybackUrl = url;
                    newManifest.StreamingConfig = "";
                    newManifest.CpCode = splittedPlaybackUrl[5];
                    newManifest.EventName = splittedPlaybackUrl[6];
                    newManifest.IngestUrl = "p-ep" + newManifest.CpCode + ".i.akamaientrypoint.net/" + newManifest.CpCode + "/" + newManifest.EventName + "/" + splittedPlaybackUrl[splittedPlaybackUrl.Length - 1];
                    newManifest.BaseIngestUrl = "p-ep" + newManifest.CpCode + ".i.akamaientrypoint.net/" + newManifest.CpCode + "/" + newManifest.EventName;
                    newManifest.HttpGetResult = splittedResult;

                }

                //Get Rendition List Data...
                DownloadRenditionList(newManifest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                WriteToStatusStrip(textBoxStreamInput.Text + ": " + ex.Message);
                MessageBox.Show(ex.ToString());
            }


        }

        async void DownloadRenditionList(MasterManifest masterManifest)
        {
            List<RenditionManifest> renditionManifests = new List<RenditionManifest>();
            List<AudioManifest> audioManifests = new List<AudioManifest>();


            try
            {
                foreach (string renditionListLine in masterManifest.HttpGetResult)
                {
                    RenditionManifest newRenditionManifest = new RenditionManifest();


                    if (renditionListLine.Contains(".m3u8") && renditionListLine.Contains("akamaihd.net"))
                    {
                        newRenditionManifest.SegmentList = new List<Segment>();

                        if (renditionListLine.Contains("https://"))
                        {
                            newRenditionManifest.PlaybackUrl = renditionListLine;
                        }
                        else
                        {
                            newRenditionManifest.PlaybackUrl = masterManifest.BasePlaybackUrl + renditionListLine;
                        }

                        string[] splittedPlaybackUrl = newRenditionManifest.PlaybackUrl.Split('/');

                        newRenditionManifest.IngestUrl = splittedPlaybackUrl[0] + "//post." + masterManifest.StreamingConfig + "/" + masterManifest.CpCode + "/" + masterManifest.EventName + "/" + splittedPlaybackUrl[splittedPlaybackUrl.Length - 1];

                        string result;
                        // ... Use textBoxStreamInput.
                        using (HttpClient client = new HttpClient())
                        using (HttpResponseMessage response = await client.GetAsync(newRenditionManifest.PlaybackUrl))
                        using (HttpContent content = response.Content)
                        {
                            // ... Read the string.
                            result = await content.ReadAsStringAsync();

                        }

                        string[] splittedResult = result.Split('\n');

                        newRenditionManifest.HttpGetResult = splittedResult;

                        string segmentDuartion = "";
                        string segmentTimeStamp = "";

                        Dictionary<string, string> newRenditionSettings = new Dictionary<string, string>();

                        foreach (string segmentUrl in splittedResult)
                        {
                            if ((segmentUrl.Contains("#EXT-X-") || segmentUrl.Contains("#EXTM3U")) && !segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME") && !segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                string key = "";
                                string value = "";

                                try
                                {
                                    key = segmentUrl.Split(':')[0];
                                    value = segmentUrl.Split(':')[1];
                                }
                                catch
                                {
                                    Console.WriteLine("no value availale");
                                    value = segmentUrl.Split(':')[0];
                                }

                                newRenditionSettings.Add(key, value);
                            }
                            else if (segmentUrl.Contains("#EXTINF"))
                            {
                                segmentDuartion = segmentUrl;
                            }
                            else if (segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME"))
                            {
                                segmentTimeStamp = segmentUrl;
                            }
                            else if (segmentUrl.Contains(".ts") || segmentUrl.Contains(".mp4"))
                            {
                                Segment segmentToAdd = new Segment
                                {
                                    SegmentDuration = segmentDuartion,
                                    SegmentTimestamp = segmentTimeStamp
                                };

                                if (segmentUrl.Contains("https://"))
                                {
                                    segmentToAdd.SegmentAbsolutePath = segmentUrl;

                                    string[] splittedSegmentUrl = segmentUrl.Split('/');
                                    segmentToAdd.SegmentRelativePath = splittedSegmentUrl[splittedSegmentUrl.Length - 1];

                                }
                                else
                                {
                                    segmentToAdd.SegmentAbsolutePath = masterManifest.BasePlaybackUrl + segmentUrl;
                                    segmentToAdd.SegmentRelativePath = segmentUrl;
                                }


                                newRenditionManifest.SegmentList.Add(segmentToAdd);
                            }
                            else if (segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                MessageBox.Show("Stream contains DISCONTINUITY tags. \nThey will be excluded from trimmed stream.", "Stream Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        newRenditionManifest.RenditionSettings = newRenditionSettings;

                        renditionManifests.Add(newRenditionManifest);

                        AddItemToComboBoxRenditionLists(newRenditionManifest.PlaybackUrl);

                    }
                    else if (renditionListLine.Contains(".m3u8") && renditionListLine.Contains("TYPE=AUDIO"))
                    {
                        AudioManifest newAudioManifest = new AudioManifest
                        {
                            SegmentList = new List<Segment>()
                        };

                        //break;
                        string[] splittedAudioGroupLine = renditionListLine.Split(',');
                        string[] splittedUriPath = splittedAudioGroupLine[splittedAudioGroupLine.Length - 1].Split('=');
                        string audioRenditionPath = splittedUriPath[splittedUriPath.Length - 1].Replace("\"", "");

                        newAudioManifest.PlaybackUrl = audioRenditionPath;

                        string[] splittedPlaybackUrl = newAudioManifest.PlaybackUrl.Split('/');

                        newAudioManifest.IngestUrl = "p-ep" + masterManifest.CpCode + ".i.akamaientrypoint.net/" + masterManifest.CpCode + "/" + masterManifest.EventName + "/" + splittedPlaybackUrl[splittedPlaybackUrl.Length - 1];



                        string result;
                        // ... Use textBoxStreamInput.
                        using (HttpClient client = new HttpClient())
                        using (HttpResponseMessage response = await client.GetAsync(newAudioManifest.PlaybackUrl))
                        using (HttpContent content = response.Content)
                        {
                            // ... Read the string.
                            result = await content.ReadAsStringAsync();

                        }

                        string[] splittedResult = result.Split('\n');

                        newAudioManifest.HttpGetResult = splittedResult;

                        string segmentDuartion = "";
                        string segmentTimeStamp = "";

                        Dictionary<string, string> newRenditionSettings = new Dictionary<string, string>();

                        foreach (string segmentUrl in splittedResult)
                        {
                          
                            if ((segmentUrl.Contains("#EXT-X-") || segmentUrl.Contains("#EXTM3U")) && !segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME") && !segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                string key = "";
                                string value = "";

                                try
                                {
                                    key = segmentUrl.Split(':')[0];
                                    value = segmentUrl.Split(':')[1];
                                }
                                catch
                                {
                                    Console.WriteLine("no value availale");
                                    value = segmentUrl.Split(':')[0];
                                }

                                newRenditionSettings.Add(key, value);
                            }
                            else if (segmentUrl.Contains("#EXTINF"))
                            {
                                segmentDuartion = segmentUrl;
                            }
                            else if (segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME"))
                            {
                                segmentTimeStamp = segmentUrl;
                            }
                            else if (segmentUrl.Contains(".aac"))
                            {
                                Segment segmentToAdd = new Segment
                                {
                                    SegmentDuration = segmentDuartion,
                                    SegmentTimestamp = segmentTimeStamp
                                };

                                if (segmentUrl.Contains("https://"))
                                {
                                    segmentToAdd.SegmentAbsolutePath = segmentUrl;

                                    string[] splittedSegmentUrl = segmentUrl.Split('/');
                                    segmentToAdd.SegmentRelativePath = splittedSegmentUrl[splittedSegmentUrl.Length - 1];
                                }
                                else
                                {
                                    segmentToAdd.SegmentAbsolutePath = masterManifest.BasePlaybackUrl + segmentUrl;
                                    segmentToAdd.SegmentRelativePath = segmentUrl;
                                }

                                newAudioManifest.SegmentList.Add(segmentToAdd);
                            }
                            else if (segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                MessageBox.Show("Stream contains DISCONTINUITY tags. \nThey will be excluded from trimmed stream.", "Stream Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }



                        newAudioManifest.RenditionSettings = newRenditionSettings;

                        audioManifests.Add(newAudioManifest);

                        AddItemToComboBoxRenditionLists(newAudioManifest.PlaybackUrl);

                    }
                    else if (renditionListLine.Contains(".m3u8"))
                    {
                        newRenditionManifest.SegmentList = new List<Segment>();

                        if (renditionListLine.Contains("https://"))
                        {
                            newRenditionManifest.PlaybackUrl = renditionListLine;
                        }
                        else
                        {
                            newRenditionManifest.PlaybackUrl = masterManifest.BasePlaybackUrl + renditionListLine;
                        }

                        string[] splittedPlaybackUrl = newRenditionManifest.PlaybackUrl.Split('/');

                        newRenditionManifest.IngestUrl = "p-ep" + masterManifest.CpCode + ".i.akamaientrypoint.net/" + masterManifest.CpCode + "/" + masterManifest.EventName + "/" + splittedPlaybackUrl[splittedPlaybackUrl.Length - 1];

                        string result;
                        // ... Use textBoxStreamInput.
                        using (HttpClient client = new HttpClient())
                        using (HttpResponseMessage response = await client.GetAsync(newRenditionManifest.PlaybackUrl))
                        using (HttpContent content = response.Content)
                        {
                            // ... Read the string.
                            result = await content.ReadAsStringAsync();

                        }

                        string[] splittedResult = result.Split('\n');

                        newRenditionManifest.HttpGetResult = splittedResult;

                        string segmentDuartion = "";
                        string segmentTimeStamp = "";

                        Dictionary<string, string> newRenditionSettings = new Dictionary<string, string>();

                        foreach (string segmentUrl in splittedResult)
                        {
                            if ((segmentUrl.Contains("#EXT-X-") || segmentUrl.Contains("#EXTM3U")) && !segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME") && !segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                string key = "";
                                string value = "";

                                try
                                {
                                    key = segmentUrl.Split(':')[0];
                                    value = segmentUrl.Split(':')[1];
                                }
                                catch
                                {
                                    Console.WriteLine("no value availale");
                                    value = segmentUrl.Split(':')[0];
                                }

                                newRenditionSettings.Add(key, value);
                            }
                            else if (segmentUrl.Contains("#EXTINF"))
                            {
                                segmentDuartion = segmentUrl;
                            }
                            else if (segmentUrl.Contains("#EXT-X-PROGRAM-DATE-TIME"))
                            {
                                segmentTimeStamp = segmentUrl;
                            }
                            else if (segmentUrl.Contains(".ts") || segmentUrl.Contains(".mp4"))
                            {
                                Segment segmentToAdd = new Segment
                                {
                                    SegmentDuration = segmentDuartion,
                                    SegmentTimestamp = segmentTimeStamp
                                };

                                if (segmentUrl.Contains("https://"))
                                {
                                    segmentToAdd.SegmentAbsolutePath = segmentUrl;

                                    string[] splittedSegmentUrl = segmentUrl.Split('/');
                                    segmentToAdd.SegmentRelativePath = splittedSegmentUrl[splittedSegmentUrl.Length - 1];
                                }
                                else
                                {
                                    segmentToAdd.SegmentAbsolutePath = masterManifest.BasePlaybackUrl + segmentUrl;
                                    segmentToAdd.SegmentRelativePath = segmentUrl;
                                }

                                newRenditionManifest.SegmentList.Add(segmentToAdd);
                            }
                            else if (segmentUrl.Contains("#EXT-X-DISCONTINUITY"))
                            {
                                MessageBox.Show("Stream contains DISCONTINUITY tags. \nThey will be excluded from trimmed stream.", "Stream Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        newRenditionManifest.RenditionSettings = newRenditionSettings;

                        renditionManifests.Add(newRenditionManifest);

                        AddItemToComboBoxRenditionLists(newRenditionManifest.PlaybackUrl);

                    }
                }

                masterManifest.RenditionManifests = renditionManifests;
                masterManifest.AudioManifests = audioManifests;
                masterManifestList = masterManifest;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ComboBoxRenditionLists_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (RenditionManifest rendition in masterManifestList.RenditionManifests)
                {
                    if (rendition.PlaybackUrl == comboBoxRenditionLists.Text)
                    {

                        WriteRenditionStream(rendition.HttpGetResult);

                        this.Invoke((MethodInvoker)delegate
                        {
                            comboBoxSegmentList.Items.Clear();
                        }
                        );

                        foreach (Segment item in rendition.SegmentList)
                        {
                            AddItemToComboBoxSegmentLists(item.SegmentAbsolutePath);
                        }

                    }
                }

                foreach (AudioManifest audioRendition in masterManifestList.AudioManifests)
                {
                    if (audioRendition.PlaybackUrl == comboBoxRenditionLists.Text)
                    {

                        WriteRenditionStream(audioRendition.HttpGetResult);

                        this.Invoke((MethodInvoker)delegate
                        {
                            comboBoxSegmentList.Items.Clear();
                        }
                        );

                        foreach (Segment item in audioRendition.SegmentList)
                        {
                            AddItemToComboBoxSegmentLists(item.SegmentAbsolutePath);
                        }

                    }
                }

                vlcPlaylistEntry = comboBoxRenditionLists.Text;

            }
            catch
            {
                Console.WriteLine("no corresponding result found.");
            }

        }

        private void ComboBoxSegmentList_TextChanged(object sender, EventArgs e)
        {
            vlcPlaylistEntry = comboBoxSegmentList.Text;
        }

        private void ClearAll()
        {
            this.Invoke((MethodInvoker)delegate
            {
                comboBoxRenditionLists.Items.Clear();
                comboBoxSegmentList.Items.Clear();

                comboBoxRenditionLists.Text = "";
                comboBoxSegmentList.Text = "";

                textBoxMasterStream.Lines = null;
                textBoxRenditionStream.Lines = null;

                textBoxFirstSegment.Text = "";
                textBoxLastSegment.Text = "";

                selectedFirstSegmentIndex = -1;
                selectedLastSegmentIndex = -1;

                MasterManifest emptyManifest = new MasterManifest();
                masterManifestList = emptyManifest;

                statusStrip1.Items.Clear();
            }
            );
        }

        private void WriteMasterStream(string[] lines)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxMasterStream.Lines = lines;
            }
            );
        }

        private void WriteRenditionStream(string[] lines)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxRenditionStream.Lines = lines;
            }
            );
        }

        private void AddItemToComboBoxRenditionLists(string item)
        {
            this.Invoke((MethodInvoker)delegate
            {
                comboBoxRenditionLists.Items.Add(item);
            }
            );
        }

        private void AddItemToComboBoxSegmentLists(string item)
        {
            this.Invoke((MethodInvoker)delegate
            {
                comboBoxSegmentList.Items.Add(item);
            }
            );
        }

        private void ButtonVlcPlay_Click(object sender, EventArgs e)
        {

            try
            {
                if (vlcPlaylistEntry != null)
                {
                    if (vlcPlaylistEntry.Contains(".m3u8"))
                    {
                        ShowStreamMessageBox();
                    }

                    if (vlcPlaylistEntry.Contains(".mp4"))
                    {
                        // EXTRACT INIT CHUNK URL
                        string[] segmentUrlSplit = vlcPlaylistEntry.Split('/');
                        Console.WriteLine(segmentUrlSplit[0]);
                        initUrl = segmentUrlSplit[0] + "/" +
                                            segmentUrlSplit[1] + "/" +
                                            segmentUrlSplit[2] + "/" +
                                            segmentUrlSplit[3] + "/" +
                                            segmentUrlSplit[4] + "/" +
                                            segmentUrlSplit[5] + "/" +
                                            segmentUrlSplit[6] + "/" +
                                            segmentUrlSplit[8] + "init.mp4";
                        Console.WriteLine("Playing Source: " + vlcPlaylistEntry);
                        axWindowsMediaPlayer1.URL = "http://localhost:8080/"; 
                        //axWindowsMediaPlayer1.URL = "http://localhost:5050/segment/40";
                        axWindowsMediaPlayer1.Ctlcontrols.play();


                    } else {
                        Console.WriteLine("Playing Source: " + vlcPlaylistEntry);
                        axWindowsMediaPlayer1.URL = vlcPlaylistEntry;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                }
                else
                {
                    MessageBox.Show("Nothing set to play! ;)  ", "Stream Preview", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonVlcStop_Click(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonSetAsFirst_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRenditionIndex = comboBoxRenditionLists.SelectedIndex;
                selectedFirstSegmentIndex = comboBoxSegmentList.SelectedIndex;

                List<AudioManifest> audioAndVideoManifests = new List<AudioManifest>();



                foreach (var item2 in masterManifestList.AudioManifests)
                {
                    audioAndVideoManifests.Add(item2);
                }

                foreach (RenditionManifest item in masterManifestList.RenditionManifests)
                {
                    audioAndVideoManifests.Add((AudioManifest)item);

                }

                TextBoxFirstSegmentTextChange(audioAndVideoManifests[selectedRenditionIndex].SegmentList[selectedFirstSegmentIndex].SegmentRelativePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ButtonSetAsLast_Click(object sender, EventArgs e)
        {
            try
            {
               int selectedRenditionIndex = comboBoxRenditionLists.SelectedIndex;
               selectedLastSegmentIndex = comboBoxSegmentList.SelectedIndex;

                List<AudioManifest> audioAndVideoManifests = new List<AudioManifest>();



                foreach (var item2 in masterManifestList.AudioManifests)
                {
                    audioAndVideoManifests.Add(item2);
                }

                foreach (RenditionManifest item in masterManifestList.RenditionManifests)
                {
                    audioAndVideoManifests.Add((AudioManifest)item);

                }


                TextBoxLastSegmentTextChange(audioAndVideoManifests[selectedRenditionIndex].SegmentList[selectedLastSegmentIndex].SegmentRelativePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TextBoxFirstSegmentTextChange(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxFirstSegment.Text = text;
            }
            );
        }

        private void TextBoxLastSegmentTextChange(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBoxLastSegment.Text = text;
            }
            );
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        async void UploadList(string uri, string data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {



                    //client.DefaultRequestHeaders.Add("Content-Type", "application/x-mpegURL");
                    Uri theUri = new Uri(uri);

                    StringContent newContent = new StringContent(data);

                    using (HttpResponseMessage response = await client.PostAsync(theUri, newContent))
                    {
                        Console.WriteLine(response.StatusCode);
                        WriteToStatusStrip(uri + ": " + response.StatusCode);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                WriteToStatusStrip(uri + ": " + ex.Message);
            }
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedFirstSegmentIndex != -1 && selectedFirstSegmentIndex != -1 && selectedFirstSegmentIndex < selectedLastSegmentIndex)
                {
                    string uploadUrl = "";
                    string payload = "";

                    foreach (RenditionManifest renditionList in masterManifestList.RenditionManifests)
                    {
                        payload = renditionList.RenditionSettings["#EXTM3U"] + "\n";
                        payload += "#EXT-X-ALLOW-CACHE:" + renditionList.RenditionSettings["#EXT-X-ALLOW-CACHE"] + "\n";
                        payload += "#EXT-X-VERSION:" + renditionList.RenditionSettings["#EXT-X-VERSION"] + "\n";
                        payload += "#EXT-X-TARGETDURATION:" + renditionList.RenditionSettings["#EXT-X-TARGETDURATION"] + "\n";
                        payload += "#EXT-X-MEDIA-SEQUENCE:";

                        int mediaSequence = Convert.ToInt32(renditionList.RenditionSettings["#EXT-X-MEDIA-SEQUENCE"]);
                        mediaSequence += mediaSequence + selectedFirstSegmentIndex;

                        payload += mediaSequence.ToString() + "\n";
                        payload += "#EXT-X-PLAYLIST-TYPE:VOD" + "\n";

                        for (int i = selectedFirstSegmentIndex; i <= selectedLastSegmentIndex; i++)
                        {

                            if (renditionList.SegmentList[i].SegmentTimestamp != "")
                            {
                                payload += renditionList.SegmentList[i].SegmentTimestamp + "\n";
                            }

                            payload += renditionList.SegmentList[i].SegmentDuration + "\n";
                            payload += renditionList.SegmentList[i].SegmentAbsolutePath + "\n";
                        }

                        payload += "#EXT-X-ENDLIST";

                        if (renditionList.IngestUrl.Contains("http"))
                        {
                            renditionList.IngestUrl = renditionList.IngestUrl.Replace("https", "http");
                            uploadUrl = renditionList.IngestUrl;
                        }
                        else
                        {
                            uploadUrl = "https://" + renditionList.IngestUrl;
                        }


                        UploadList(uploadUrl, payload);
                    }


                    foreach (AudioManifest audioRenditionList in masterManifestList.AudioManifests)
                    {
                        payload = audioRenditionList.RenditionSettings["#EXTM3U"] + "\n";
                        payload += "#EXT-X-ALLOW-CACHE:" + audioRenditionList.RenditionSettings["#EXT-X-ALLOW-CACHE"] + "\n";
                        payload += "#EXT-X-VERSION:" + audioRenditionList.RenditionSettings["#EXT-X-VERSION"] + "\n";
                        payload += "#EXT-X-TARGETDURATION:" + audioRenditionList.RenditionSettings["#EXT-X-TARGETDURATION"] + "\n";
                        payload += "#EXT-X-MEDIA-SEQUENCE:";

                        int mediaSequence = Convert.ToInt32(audioRenditionList.RenditionSettings["#EXT-X-MEDIA-SEQUENCE"]);
                        mediaSequence += selectedFirstSegmentIndex;

                        payload += mediaSequence.ToString() + "\n";
                        payload += "#EXT-X-PLAYLIST-TYPE:VOD" + "\n";

                        for (int i = selectedFirstSegmentIndex; i <= selectedLastSegmentIndex; i++)
                        {

                            if (audioRenditionList.SegmentList[i].SegmentTimestamp != "")
                            {
                                payload += audioRenditionList.SegmentList[i].SegmentTimestamp + "\n";
                            }

                            payload += audioRenditionList.SegmentList[i].SegmentDuration + "\n";
                            payload += audioRenditionList.SegmentList[i].SegmentAbsolutePath + "\n";
                        }

                        payload += "#EXT-X-ENDLIST";

                        if (audioRenditionList.IngestUrl.Contains("http"))
                        {
                            audioRenditionList.IngestUrl = audioRenditionList.IngestUrl.Replace("https", "http");
                            uploadUrl = audioRenditionList.IngestUrl;
                        }
                        else
                        {
                            uploadUrl = "https://" + audioRenditionList.IngestUrl;
                        }


                        UploadList(uploadUrl, payload);
                    }
                }
                else
                {
                    MessageBox.Show("Indexes are not correct");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteToStatusStrip(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ToolStripStatusLabel newLabel = new ToolStripStatusLabel
                {
                    Text = text
                };
                statusStrip1.Items.Add(newLabel);
            }
            );
        }

        private void ClearStatusStrip()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusStrip1.Items.Clear();
            }
            );
        }

        private void StatusStrip1_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Items.Count > 0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    statusStrip1.Items.RemoveAt(0);
                }
                );
            }
        }

        private void ShowStreamMessageBox()
        {
            MessageBox.Show("Use Player just for Segment Preview. \nIf you play a .m3u8 the stream will be displayed choppy.", "Stream Preview", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void StartWebServer(string url)
        {
            // Create a new HttpListener instance
            HttpListener listener = new HttpListener();

            // Add the URL(s) you want to listen to
            listener.Prefixes.Add(url);

            // Start listening for incoming requests
            listener.Start();

            // Handle incoming requests asynchronously
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (listener.IsListening)
                {
                    // Wait for an incoming request
                    HttpListenerContext context = listener.GetContext();

                    // Handle the request in a separate thread
                    ThreadPool.QueueUserWorkItem((c) =>
                    {
                        try
                        {
                            // Get the response object
                            HttpListenerResponse response = context.Response;
                            response.ContentType = "video/mp4";

                            // Create a memory stream to store the response content
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                // Loop through each content URL
                                string[] contentUrls = { initUrl, vlcPlaylistEntry };

                                foreach (string contentUrl in contentUrls)
                                {
                                    // Create a WebRequest to fetch content from the current URL
                                    WebRequest webRequest = WebRequest.Create(contentUrl);

                                    // Get the response from the WebRequest
                                    using (WebResponse webResponse = webRequest.GetResponse())
                                    using (Stream contentStream = webResponse.GetResponseStream())
                                    {
                                        // Copy the content from the web response stream to the memory stream
                                        contentStream.CopyTo(memoryStream);
                                    }
                                }

                                response.ContentLength64 = memoryStream.Length;
                                // Write the content from the memory stream to the response output stream
                                memoryStream.Position = 0;
                                memoryStream.CopyTo(response.OutputStream);
                            }

                            // Close the output stream
                            response.OutputStream.Close();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            Console.WriteLine("Error handling request: " + ex.Message);
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                        finally
                        {
                            // Close the response
                            context.Response.Close();
                        }
                    }, null);
                }
            });
        }

        /*private void StartWebServer(string url)
        {
            // Create a new HttpListener instance
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();

            // Handle incoming requests asynchronously
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (listener.IsListening)
                {
                    // Wait for an incoming request
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem((c) =>
                    {
                       

                        try
                        {
                            // Get the response object
                            HttpListenerResponse response = context.Response;

                            // Loop through each content URL
                            string[] contentUrls = { initUrl, vlcPlaylistEntry };
                            foreach (string contentUrl in contentUrls)
                            {
                                // Create a WebRequest to fetch content from the current URL
                                WebRequest webRequest = WebRequest.Create(contentUrl);

                                // Get the response from the WebRequest
                                using (WebResponse webResponse = webRequest.GetResponse())
                                using (Stream contentStream = webResponse.GetResponseStream())
                                {
                                    // Copy the content from the web response stream to the response output stream
                                    contentStream.CopyTo(response.OutputStream);
                                }
                            }

                            // Close the output stream
                            response.OutputStream.Close();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            Console.WriteLine("Error handling request: " + ex.Message);
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                        finally
                        {
                            // Close the response
                            context.Response.Close();
                        }

                    }, null);
                }
            });
        } */

    }

}

