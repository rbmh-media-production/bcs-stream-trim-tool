using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTrimTool
{
    class MasterManifest
    {
        public string IngestUrl { get; set; }
        public string BaseIngestUrl { get; set; }
        public string PlaybackUrl { get; set; }
        public string BasePlaybackUrl { get; set; }
        public string StreamingConfig { get; set; }
        public string CpCode { get; set; }
        public string EventName { get; set; }
        public string[] HttpGetResult { get; set; }
        public List<RenditionManifest> RenditionManifests { get; set; }
        public List<AudioManifest> AudioManifests { get; set; }

    }
}
