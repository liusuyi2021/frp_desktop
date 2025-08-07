using frp_desktop.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class ProxyData
{
    private static readonly string FolderPath = Path.Combine(System.Environment.CurrentDirectory, "frp");

    private static readonly string ProxyFilePath = Path.Combine(FolderPath, "frpsConfig.json");
    private static readonly string ServerFilePath = Path.Combine(FolderPath, "frpsServerConfig.json");

    #region 客户端代理配置管理（原有代码保持不变）

    public static void SaveData(List<FrpProxy> proxies)
    {
        if (!Directory.Exists(FolderPath))
            Directory.CreateDirectory(FolderPath);

        string json = JsonConvert.SerializeObject(proxies, Formatting.Indented);
        File.WriteAllText(ProxyFilePath, json);
    }

    public static List<FrpProxy> LoadData()
    {
        if (!File.Exists(ProxyFilePath))
            return new List<FrpProxy>();

        string json = File.ReadAllText(ProxyFilePath);
        return JsonConvert.DeserializeObject<List<FrpProxy>>(json);
    }

    public static bool AddData(FrpProxy proxy, out string errorMsg)
    {
        var list = LoadData();

        if (list.Exists(p => p.Name.Equals(proxy.Name, StringComparison.OrdinalIgnoreCase)))
        {
            errorMsg = "名称已存在，请更换其他名称！";
            return false;
        }
        if (list.Exists(p => p.LocalIp == proxy.LocalIp && p.LocalPort == proxy.LocalPort))
        {
            errorMsg = "本地服务地址和端口组合已存在，请检查！";
            return false;
        }
        proxy.Index = list.Count + 1;
        list.Add(proxy);
        SaveData(list);

        errorMsg = null;
        return true;
    }

    public static void DeleteDataByName(string name)
    {
        var list = LoadData();
        var itemToRemove = list.Find(p => p.Name == name);
        if (itemToRemove != null)
        {
            list.Remove(itemToRemove);
            SaveData(list);
        }
    }

    #endregion

    #region 服务端配置管理

    public static void SaveServerConfig(FrpServerConfig config)
    {
        if (!Directory.Exists(FolderPath))
            Directory.CreateDirectory(FolderPath);

        string json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(ServerFilePath, json);
    }

    public static FrpServerConfig LoadServerConfig()
    {
        if (!File.Exists(ServerFilePath))
            return new FrpServerConfig(); // 返回默认值

        string json = File.ReadAllText(ServerFilePath);
        return JsonConvert.DeserializeObject<FrpServerConfig>(json);
    }

    #endregion
}
