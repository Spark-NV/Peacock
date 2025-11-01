using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace HitmanPatcher
{
    public partial class OptionsForm : Form
    {
        private string customDomain;
        private bool startInTray, minimizeToTray;
        private List<string> trayDomains;
        private string peacockServerBatPath;
        private string hitmanExePath;
        private bool autoLaunchServer, autoLaunchGame, autoKillServerOnGameClose;

        private void toggleTheme(bool darkModeEnabled)
        {
            BackColor = darkModeEnabled ? Color.FromArgb(24, 26, 27) : SystemColors.Control;

            groupBox1.BackColor = darkModeEnabled ? Color.FromArgb(24, 26, 27) : SystemColors.Control;
            groupBox1.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

            buttonSave.FlatStyle = darkModeEnabled ? FlatStyle.Flat : FlatStyle.Standard;
            buttonSave.BackColor = darkModeEnabled ? Color.FromArgb(19, 21, 22) : SystemColors.Control;
            buttonSave.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

            buttonCancel.FlatStyle = darkModeEnabled ? FlatStyle.Flat : FlatStyle.Standard;
            buttonCancel.BackColor = darkModeEnabled ? Color.FromArgb(19, 21, 22) : SystemColors.Control;
            buttonCancel.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

            buttonTrayOptions.FlatStyle = darkModeEnabled ? FlatStyle.Flat : FlatStyle.Standard;
            buttonTrayOptions.BackColor = darkModeEnabled ? Color.FromArgb(19, 21, 22) : SystemColors.Control;
            buttonTrayOptions.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

            if (groupBox2 != null)
            {
                groupBox2.BackColor = darkModeEnabled ? Color.FromArgb(24, 26, 27) : SystemColors.Control;
                groupBox2.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

                if (buttonSelectPeacock != null)
                {
                    buttonSelectPeacock.FlatStyle = darkModeEnabled ? FlatStyle.Flat : FlatStyle.Standard;
                    buttonSelectPeacock.BackColor = darkModeEnabled ? Color.FromArgb(19, 21, 22) : SystemColors.Control;
                    buttonSelectPeacock.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;
                }
                if (buttonSelectHitman != null)
                {
                    buttonSelectHitman.FlatStyle = darkModeEnabled ? FlatStyle.Flat : FlatStyle.Standard;
                    buttonSelectHitman.BackColor = darkModeEnabled ? Color.FromArgb(19, 21, 22) : SystemColors.Control;
                    buttonSelectHitman.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;
                }
            }

            if (groupBox3 != null)
            {
                groupBox3.BackColor = darkModeEnabled ? Color.FromArgb(24, 26, 27) : SystemColors.Control;
                groupBox3.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;

                if (checkBoxAutoLaunchServer != null)
                {
                    checkBoxAutoLaunchServer.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;
                }
                if (checkBoxAutoLaunchGame != null)
                {
                    checkBoxAutoLaunchGame.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;
                }
                if (checkBoxAutoKillServer != null)
                {
                    checkBoxAutoKillServer.ForeColor = darkModeEnabled ? Color.White : SystemColors.ControlText;
                }
            }
        }

        public OptionsForm(Settings currentSettings)
        {
            InitializeComponent();
            Settings = currentSettings;
            startInTray = Settings.startInTray;
            minimizeToTray = Settings.minimizeToTray;
            trayDomains = Settings.trayDomains;
            peacockServerBatPath = Settings.peacockServerBatPath ?? "";
            hitmanExePath = Settings.hitmanExePath ?? "";
            autoLaunchServer = Settings.autoLaunchServer;
            autoLaunchGame = Settings.autoLaunchGame;
            autoKillServerOnGameClose = Settings.autoKillServerOnGameClose;
            toggleTheme(Settings.darkModeEnabled);

            if (!string.IsNullOrWhiteSpace(peacockServerBatPath))
                buttonSelectPeacock.Text = "Peacock Server: Selected";
            if (!string.IsNullOrWhiteSpace(hitmanExePath))
                buttonSelectHitman.Text = "Hitman Exe: Selected";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public Settings Settings
        {
            get =>
                new Settings()
                {
                    patchOptions = new MemoryPatcher.Options()
                    {
                        CustomConfigDomain = customDomain,
                        UseHttp = checkBoxHttp.Checked,
                        EnableDynamicResources = true,
                        DisableForceOfflineOnFailedDynamicResources = dynResources.Checked,
                        DisableCertPinning = true,
                        SetCustomConfigDomain = true,
                        AlwaysSendAuthHeader = true
                    },
                    darkModeEnabled = darkModeBox.Checked,
                    startInTray = startInTray,
                    minimizeToTray = minimizeToTray,
                    trayDomains = trayDomains,
                    peacockServerBatPath = peacockServerBatPath ?? "",
                    hitmanExePath = hitmanExePath ?? "",
                    autoLaunchServer = checkBoxAutoLaunchServer != null ? checkBoxAutoLaunchServer.Checked : autoLaunchServer,
                    autoLaunchGame = checkBoxAutoLaunchGame != null ? checkBoxAutoLaunchGame.Checked : autoLaunchGame,
                    autoKillServerOnGameClose = checkBoxAutoKillServer != null ? checkBoxAutoKillServer.Checked : autoKillServerOnGameClose
                };
            private set
            {
                customDomain = value.patchOptions.CustomConfigDomain;
                checkBoxHttp.Checked = value.patchOptions.UseHttp;
                dynResources.Checked = value.patchOptions.DisableForceOfflineOnFailedDynamicResources;
                darkModeBox.Checked = value.darkModeEnabled;
                startInTray = value.startInTray;
                minimizeToTray = value.minimizeToTray;
                trayDomains = value.trayDomains;
                peacockServerBatPath = value.peacockServerBatPath ?? "";
                hitmanExePath = value.hitmanExePath ?? "";
                autoLaunchServer = value.autoLaunchServer;
                autoLaunchGame = value.autoLaunchGame;
                autoKillServerOnGameClose = value.autoKillServerOnGameClose;
                
                if (checkBoxAutoLaunchServer != null)
                    checkBoxAutoLaunchServer.Checked = value.autoLaunchServer;
                if (checkBoxAutoLaunchGame != null)
                    checkBoxAutoLaunchGame.Checked = value.autoLaunchGame;
                if (checkBoxAutoKillServer != null)
                    checkBoxAutoKillServer.Checked = value.autoKillServerOnGameClose;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonTrayOptions_Click(object sender, EventArgs e)
        {
            TrayOptionsForm trayOptionsForm = new TrayOptionsForm(startInTray, minimizeToTray, trayDomains, Settings.darkModeEnabled);
            DialogResult result = trayOptionsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                startInTray = trayOptionsForm.startInTray;
                minimizeToTray = trayOptionsForm.minimizeToTray;
                trayDomains = trayOptionsForm.trayDomains;
            }
        }

        private void buttonSelectPeacock_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Command files (*.cmd)|*.cmd|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    peacockServerBatPath = openFileDialog.FileName;
                    buttonSelectPeacock.Text = "Peacock Server: Selected";
                }
            }
        }

        private void buttonSelectHitman_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    hitmanExePath = openFileDialog.FileName;
                    buttonSelectHitman.Text = "Hitman Exe: Selected";
                }
            }
        }
    }
}
