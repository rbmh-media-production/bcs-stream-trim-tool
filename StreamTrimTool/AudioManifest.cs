using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTrimTool
{
    class AudioManifest
    {
        public string IngestUrl { get; set; }
        public string PlaybackUrl { get; set; }
        public string[] HttpGetResult { get; set; }
        public List<Segment> SegmentList { get; set; }

        public Dictionary<string, string> RenditionSettings { get; set; }

        public static explicit operator AudioManifest(RenditionManifest v)
        {
            AudioManifest convAudioManifest = new AudioManifest();

            convAudioManifest.HttpGetResult = v.HttpGetResult;
            convAudioManifest.IngestUrl = v.IngestUrl;
            convAudioManifest.PlaybackUrl = v.PlaybackUrl;
            convAudioManifest.RenditionSettings = v.RenditionSettings;
            convAudioManifest.SegmentList = v.SegmentList;

            return convAudioManifest;
        }
    }
}
