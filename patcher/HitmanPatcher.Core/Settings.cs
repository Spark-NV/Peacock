using System;
using System.Collections.Generic;
using System.IO;

namespace HitmanPatcher
{
    public class Settings
    {
        public MemoryPatcher.Options patchOptions;
        public bool startInTray;
        public bool minimizeToTray;
        public bool darkModeEnabled;
        public List<string> trayDomains;
        public string peacockServerBatPath;
        public string hitmanExePath;
        public bool autoLaunchServer;
        public bool autoLaunchGame;
        public bool autoKillServerOnGameClose;

        public Settings()
        {
            patchOptions = new MemoryPatcher.Options
            {
                CustomConfigDomain = "127.0.0.1",
                UseHttp = true,
                DisableCertPinning = true,
                AlwaysSendAuthHeader = true,
                SetCustomConfigDomain = true,
                EnableDynamicResources = true,
                DisableForceOfflineOnFailedDynamicResources = true,
            };
            darkModeEnabled = false;
            startInTray = false;
            minimizeToTray = false;
            trayDomains = new List<string>();
            peacockServerBatPath = "";
            hitmanExePath = "";
            autoLaunchServer = true;
            autoLaunchGame = true;
            autoKillServerOnGameClose = true;
        }

        private static string GetSavePath()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PeacockProject"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PeacockProject");
            }

            string appData = Environment.GetFolderPath(Environment
                .SpecialFolder
                .ApplicationData);

            string folder = $@"{appData}\PeacockProject\";
            string config1 = folder + "peacock_patcher.conf";
            string config2 = folder + "peacock_patcher2.conf";

            if (File.Exists(config1))
            {
                File.Delete(config1);
            }

            return config2;
        }

        public void SaveToFile()
        {
            List<string> lines = new List<string>();
            lines.Add(string.Format("CustomConfigDomain={0}", patchOptions.CustomConfigDomain));
            lines.Add(string.Format("UseHttp={0}", patchOptions.UseHttp));
            lines.Add(string.Format("DisableForceDynamicResources={0}", patchOptions.DisableForceOfflineOnFailedDynamicResources));
			lines.Add(string.Format("DarkModeEnabled={0}", darkModeEnabled));
            lines.Add(string.Format("startInTray={0}", startInTray));
            lines.Add(string.Format("minToTray={0}", minimizeToTray));
            lines.Add(string.Format("PeacockServerBatPath={0}", peacockServerBatPath ?? ""));
            lines.Add(string.Format("HitmanExePath={0}", hitmanExePath ?? ""));
            lines.Add(string.Format("AutoLaunchServer={0}", autoLaunchServer));
            lines.Add(string.Format("AutoLaunchGame={0}", autoLaunchGame));
            lines.Add(string.Format("AutoKillServerOnGameClose={0}", autoKillServerOnGameClose));

            foreach (string domain in trayDomains)
            {
                lines.Add(string.Format("trayDomain={0}", domain));
            }

            File.WriteAllLines(GetSavePath(), lines);
        }

        public static Settings GetFromFile()
        {
            Settings result = new Settings();
            if (File.Exists(GetSavePath()))
            {
                string[] lines = File.ReadAllLines(GetSavePath());
                if (lines.Length == 1)
                {
                    result.patchOptions.CustomConfigDomain = lines[0];
                }
                else
                {
                    foreach (string line in lines)
                    {
                        if (line == "")
                            continue;

                        string[] linecontents = line.Split(new char[] { '=' }, 2);
                        if (linecontents.Length < 2)
                            continue;
                            
                        try
                        {
                            switch (linecontents[0])
                            {
                                case "CustomConfigDomain":
                                    result.patchOptions.CustomConfigDomain = linecontents[1];
                                    break;
                                case "UseHttp":
                                    result.patchOptions.UseHttp = bool.Parse(linecontents[1]);
                                    break;
                                case "DisableForceDynamicResources":
                                    result.patchOptions.DisableForceOfflineOnFailedDynamicResources = bool.Parse(linecontents[1]);
                                    break;
                                case "DarkModeEnabled":
                                    result.darkModeEnabled = bool.Parse(linecontents[1]);
                                    break;
                                case "startInTray":
                                    result.startInTray = bool.Parse(linecontents[1]);
                                    break;
                                case "minToTray":
                                    result.minimizeToTray = bool.Parse(linecontents[1]);
                                    break;
                                case "trayDomain":
                                    result.trayDomains.Add(linecontents[1]);
                                    break;
                                case "PeacockServerBatPath":
                                    result.peacockServerBatPath = linecontents[1];
                                    break;
                                case "HitmanExePath":
                                    result.hitmanExePath = linecontents[1];
                                    break;
                                case "AutoLaunchServer":
                                    result.autoLaunchServer = bool.Parse(linecontents[1]);
                                    break;
                                case "AutoLaunchGame":
                                    result.autoLaunchGame = bool.Parse(linecontents[1]);
                                    break;
                                case "AutoKillServerOnGameClose":
                                    result.autoKillServerOnGameClose = bool.Parse(linecontents[1]);
                                    break;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
    }
}
