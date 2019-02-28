using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTrimTool
{
    class RenditionManifest
    {
        public string IngestUrl { get; set; }
        public string PlaybackUrl { get; set; }
        public string[] HttpGetResult { get; set; }
        public List<Segment> SegmentList { get; set; }

        public Dictionary<string, string> RenditionSettings { get; set; }
    }
}
