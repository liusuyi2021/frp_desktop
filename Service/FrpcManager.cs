using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace frp_desktop
{
    public static class FrpcManager
    {
        private static Process _frpcProcess;

        public static bool IsRunning => _frpcProcess != null && !_frpcProcess.HasExited;

        public static event Action<string> OnOutput;

        public static bool StartFrpc(string configPath)
        {
            try
            {
                // 先杀掉所有旧的 frpc.exe 进程
                foreach (var proc in Process.GetProcessesByName("frpc"))
                {
                    try
                    {
                        if (!proc.HasExited)
                            proc.Kill();
                    }
                    catch
                    {
                        // 忽略无法杀死的进程异常
                    }
                }

                // 如果之前自己管理的进程还没退出，也杀掉
                if (_frpcProcess != null && !_frpcProcess.HasExited)
                {
                    _frpcProcess.Kill();
                    _frpcProcess.Dispose();
                    _frpcProcess = null;
                }

                // 下面再启动新进程
                string frpcPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frp", "frpc.exe");

                var startInfo = new ProcessStartInfo
                {
                    FileName = frpcPath,
                    Arguments = $"-c \"{configPath}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = Path.GetDirectoryName(frpcPath)
                };

                _frpcProcess = new Process { StartInfo = startInfo, EnableRaisingEvents = true };

                _frpcProcess.OutputDataReceived += (s, e) =>
                {
                    if (e.Data != null)
                        OnOutput?.Invoke("[INFO] " + e.Data);
                };
                _frpcProcess.ErrorDataReceived += (s, e) =>
                {
                    if (e.Data != null)
                        OnOutput?.Invoke("[ERR] " + e.Data);
                };

                _frpcProcess.Start();
                _frpcProcess.BeginOutputReadLine();
                _frpcProcess.BeginErrorReadLine();

                return true;
            }
            catch (Exception ex)
            {
                OnOutput?.Invoke("[EXCEPTION] " + ex.Message);
                return false;
            }
        }


        public static void StopFrpc()
            {
                try
                {
                    if (_frpcProcess != null && !_frpcProcess.HasExited)
                    {
                        _frpcProcess.Kill();
                        _frpcProcess.Dispose();
                        _frpcProcess = null;
                        OnOutput?.Invoke("[SYSTEM] frpc stopped.");
                    }
                }
                catch (Exception ex)
                {
                    OnOutput?.Invoke("[EXCEPTION] " + ex.Message);
                }
            }
    }
}
