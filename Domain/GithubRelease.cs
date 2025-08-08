using System;
using System.Collections.Generic;

namespace frp_desktop.Domain
{
        public class GithubRelease
        {
            public string tag_name { get; set; }
            public DateTime published_at { get; set; }
            public List<GithubAsset> assets { get; set; }
        }
    public class GithubAsset
    {
        public string name { get; set; }

        public int size { get; set; }
        public string browser_download_url { get; set; }
        public int download_count { get; set; }
    }
}
