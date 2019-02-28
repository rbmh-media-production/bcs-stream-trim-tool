using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTrimTool
{
    class Segment
    {
        public string SegmentDuration { get; set; }
        public string SegmentRelativePath { get; set; }
        public string SegmentAbsolutePath { get; set; }
        public string SegmentTimestamp { get; set; }
    }
}
