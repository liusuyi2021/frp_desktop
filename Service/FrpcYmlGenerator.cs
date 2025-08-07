using frp_desktop.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace frp_desktop.Service
{
    public class FrpcYmlGenerator
    {
        public static void GenerateYml(string folderPath, string serverAddr, int serverPort, string authMethod, string authToken, string heartbeatInterval, string heartbeatTimeout, List<FrpProxy> proxies)
        {
            string folder = Path.Combine(Environment.CurrentDirectory, "frp");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var sb = new StringBuilder();

            sb.AppendLine($"serverAddr: \"{serverAddr}\"  # 你的 FRP 服务器地址");
            sb.AppendLine($"serverPort: {serverPort}       # FRP 服务器端口");
            sb.AppendLine();
            sb.AppendLine("auth:");
            sb.AppendLine($"  method: {authMethod}");
            sb.AppendLine($"  token: \"{authToken}\"  # 与服务器端一致的认证令牌");
            sb.AppendLine();

            // 添加 transport 配置
            sb.AppendLine("transport:");
            sb.AppendLine($"  heartbeatInterval: {heartbeatInterval}   # 心跳间隔，单位秒");
            sb.AppendLine($"  heartbeatTimeout: {heartbeatTimeout}   # 心跳超时，单位秒");

            sb.AppendLine();
            sb.AppendLine("proxies:");

            foreach (var p in proxies)
            {
                sb.AppendLine($"  - name: \"{p.Name}\"");
                sb.AppendLine($"    type: {p.Type}");
                sb.AppendLine($"    localIP: \"{p.LocalIp}\"");
                sb.AppendLine($"    localPort: {p.LocalPort}");
                sb.AppendLine($"    remotePort: {p.RemotePort}");
                sb.AppendLine();
            }

            string filePath = Path.Combine(folder, "frpc.yml");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

            Console.WriteLine($"YAML 文件已生成: {filePath}");
        }
    }
}
