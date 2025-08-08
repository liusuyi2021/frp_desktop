using frp_desktop.Domain;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
namespace frp_desktop.Service
{
    public class FrpDownload
    {
        private static readonly string BasePath = Path.Combine(System.Environment.CurrentDirectory, "frp");
        private static readonly string CacheFile = Path.Combine(BasePath, "cache_releases.json");
        private string DownloadrPath = Path.Combine(BasePath, "download");
        private readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(10);
        public FrpDownload()
        {
            // 强制使用 TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        }
        public List<FrpVersionInfo> GetReleasesWithCache()
        {
            if (File.Exists(CacheFile))
            {
                var lastWrite = File.GetLastWriteTime(CacheFile);
                if ((DateTime.Now - lastWrite) < CacheDuration)
                {
                    // 读取缓存文件
                    string cachedJson = File.ReadAllText(CacheFile);
                    return JsonConvert.DeserializeObject<List<FrpVersionInfo>>(cachedJson);
                }
            }

            // 缓存不存在或过期，重新请求
            var releases = GetWindowsReleases();

            // 写入缓存文件
            File.WriteAllText(CacheFile, JsonConvert.SerializeObject(releases));

            return releases;
        }
        /// <summary>
        /// 获取所有 Windows 版本（只包含 windows_amd64.zip）
        /// </summary>
        public List<FrpVersionInfo> GetWindowsReleases()
        {
            var url = "https://api.github.com/repos/fatedier/frp/releases";
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0");
                var json = client.DownloadString(url);
                var releases = JsonConvert.DeserializeObject<List<GithubRelease>>(json);

                var result = new List<FrpVersionInfo>();
                foreach (var release in releases)
                {
                    foreach (var asset in release.assets)
                    {
                        if (!string.IsNullOrEmpty(asset.name) &&
                            asset.name.IndexOf("windows_amd64.zip", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            result.Add(new FrpVersionInfo
                            {
                                Version = release.tag_name,
                                PublishDate = release.published_at,
                                FileName = asset.name,
                                Size = asset.size,
                                DownloadUrl = asset.browser_download_url,
                                DownloadCountl = asset.download_count
                            });
                        }
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 下载 frp zip 
        /// </summary>
        public void DownloadFrp(string downloadUrl, string outputPath)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0");
                client.DownloadFile(downloadUrl, outputPath);
            }
        }
        /// <summary>
        /// 解压出 frpc.exe
        /// </summary>
        public string ExtractFrpc(string version)
        {
            string frpZipPath = DownloadrPath + "\\frp_" + version + "_windows_amd64.zip";
            // 解压 zip
            using (var zipStream = new ZipInputStream(File.OpenRead(frpZipPath)))
            {
                ZipEntry entry;
                while ((entry = zipStream.GetNextEntry()) != null)
                {
                    if (entry.FileName.EndsWith("frpc.exe", StringComparison.OrdinalIgnoreCase))
                    {
                        string frpcPath = BasePath + "\\frpc.exe";
                        using (var fs = File.Create(frpcPath))
                        {
                            byte[] buffer = new byte[4096];
                            int size;
                            while ((size = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fs.Write(buffer, 0, size);
                            }
                        }
                        return frpcPath;
                    }
                }
            }
            throw new FileNotFoundException("zip 中未找到 frpc.exe");
        }
        /// <summary>
        ///  是否已下载
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public bool IsVersionDownloaded(string fileName)
        {
            string ZIPPath = Path.Combine(DownloadrPath, fileName);
            return File.Exists(ZIPPath);
        }

        /// <summary>
        /// 获取已下载的 frp 版本列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetDownloadedFrpVersions()
        {

            if (!Directory.Exists(DownloadrPath))
                return new List<string>();

            var files = Directory.GetFiles(DownloadrPath, "frp_*.zip");

            var versions = new List<string>();
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file); // e.g. frp_0.63.0_windows_amd64.zip
                var parts = fileName.Split('_');          // ["frp", "0.63.0", "windows", "amd64.zip"]

                if (parts.Length >= 2)
                {
                    versions.Add(parts[1]);  // 取第二部分作为版本号
                }
            }
            return versions.OrderByDescending(v => v).ToList(); ;
        }
    }

    public class FrpVersionInfo
    {
        public string Version { get; set; }
        public DateTime PublishDate { get; set; }
        public string FileName { get; set; }

        public int Size { get; set; }

        public string DownloadUrl { get; set; }

        public int DownloadCountl { get; set; }
    }
}
