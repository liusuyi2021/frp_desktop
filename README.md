# FRP 控制面板（WinForms + AntdUI）

本项目是一个基于 **WinForms** 和 **AntdUI** 的图形化 FRP 控制面板，支持配置、启动、日志查看、代理列表管理等功能，适用于 Windows 平台的局域网穿透场景。

---

## ✨ 功能特性

- ✅ 支持 FRPC 客户端启动、关闭、输出日志实时查看
- ✅ 图形化配置代理列表：新增、编辑、删除
- ✅ 多个代理通道同时管理
- ✅ 日志自动清洗 ANSI 转义字符
- ✅ 自动重载配置与界面同步
- ✅ 启动时间计时器显示程序运行时长

---

## 📁 项目目录结构

```plaintext
frp_desktop/                # 主程序代码
├── Domain/              # 实体对象
├── frp/                      
│   └── frpc.exe           # FRP 客户端程序
├── Resources/           # 资源目录
├── Service/                # 核心逻辑类
│   ├── FrpcManager.cs          # FRP 客户端启动程序
│   ├── FrpcYmlGenerator.cs  # yml生成器
│   └── ProxyData.cs         # 代理数据处理
└── MainWindows.cs        # 程序入口窗口
```


---

## 🚀 快速开始

### 1. 编译环境

- Windows 10+
- [.NET Framework 4](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net4)
- Visual Studio 2019/2022
- [AntdUI.WinForm](https://github.com/kwwwvagaa/AntdUI) NuGet 包

### 2. 安装依赖

在解决方案中还需安装：

Install-Package AntdUI.WinForm

### 3. 配置 `frpc`

确保将你的 `frpc.exe`  放置于程序所在目录的frp文件夹下，或根据需要修改路径。

### 4. 启动程序

点击运行 `frp_desktop.exe`。

---

## 🛠️ 使用说明

###  1.启动/关闭 FRP

- 断开按钮可终止正在运行的 `frpc` 实例。

###  2.添加代理

点击“新增代理”填写以下内容：

- 名称
- 本地 IP 与端口
- 远程端口
- 类型（如 tcp）

点击“保存”后配置自动写入 `frpc.toml` 并刷新代理表格。

### 3.删除代理

在表格中点击“删除”按钮，将弹出确认框，确认后立即从配置中移除并刷新。

---

# 📸 界面截图
以下为部分界面展示

✅ 连接页面
<img width="861" height="524" alt="image" src="https://github.com/user-attachments/assets/01a58a34-9241-4fb0-bd94-4beffb45303c" />


✅ 服务配置
<img width="861" height="520" alt="image" src="https://github.com/user-attachments/assets/a4376091-f629-40e0-a269-919ba2db1b2f" />


✅ 代理管理
<img width="863" height="523" alt="image" src="https://github.com/user-attachments/assets/945a2e26-d367-4dcf-8e1a-018414c0b68a" />


✅ 控制台日志
<img width="862" height="522" alt="image" src="https://github.com/user-attachments/assets/9ee757e7-de0c-4986-8bf8-2b88084f50c2" />


📄 License
本项目采用 MIT License。

🙋‍♂️ 联系方式
如有问题欢迎提 Issue 或联系作者：

作者：刘苏义

邮箱：1951119284@qq.com
