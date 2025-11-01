namespace HitmanPatcher
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.darkModeBox = new System.Windows.Forms.CheckBox();
            this.dynResources = new System.Windows.Forms.CheckBox();
            this.checkBoxHttp = new System.Windows.Forms.CheckBox();
            this.buttonTrayOptions = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSelectPeacock = new System.Windows.Forms.Button();
            this.buttonSelectHitman = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoKillServer = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoLaunchGame = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoLaunchServer = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            //
            // buttonSave
            //
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(302, 193);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(166, 32);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            //
            // buttonCancel
            //
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(302, 229);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(166, 32);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.darkModeBox);
            this.groupBox1.Controls.Add(this.dynResources);
            this.groupBox1.Controls.Add(this.checkBoxHttp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(284, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patcher Options";
            //
            // darkModeBox
            //
            this.darkModeBox.AutoSize = true;
            this.darkModeBox.Location = new System.Drawing.Point(5, 73);
            this.darkModeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.darkModeBox.Name = "darkModeBox";
            this.darkModeBox.Size = new System.Drawing.Size(140, 20);
            this.darkModeBox.TabIndex = 2;
            this.darkModeBox.Text = "Enable dark mode";
            this.darkModeBox.UseVisualStyleBackColor = true;
            //
            // dynResources
            //
            this.dynResources.AutoSize = true;
            this.dynResources.Location = new System.Drawing.Point(5, 47);
            this.dynResources.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynResources.Name = "dynResources";
            this.dynResources.Size = new System.Drawing.Size(231, 20);
            this.dynResources.TabIndex = 1;
            this.dynResources.Text = "Make dynamic resources optional";
            this.dynResources.UseVisualStyleBackColor = true;
            //
            // checkBoxHttp
            //
            this.checkBoxHttp.AutoSize = true;
            this.checkBoxHttp.Location = new System.Drawing.Point(5, 21);
            this.checkBoxHttp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxHttp.Name = "checkBoxHttp";
            this.checkBoxHttp.Size = new System.Drawing.Size(170, 20);
            this.checkBoxHttp.TabIndex = 0;
            this.checkBoxHttp.Text = "Use http instead of https";
            this.checkBoxHttp.UseVisualStyleBackColor = true;
            //
            // buttonTrayOptions
            //
            this.buttonTrayOptions.AccessibleDescription = "A button that opens the tray options.";
            this.buttonTrayOptions.AccessibleName = "Tray Options";
            this.buttonTrayOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrayOptions.Location = new System.Drawing.Point(302, 18);
            this.buttonTrayOptions.Name = "buttonTrayOptions";
            this.buttonTrayOptions.Size = new System.Drawing.Size(166, 32);
            this.buttonTrayOptions.TabIndex = 3;
            this.buttonTrayOptions.Text = "Tray Options";
            this.buttonTrayOptions.UseVisualStyleBackColor = true;
            this.buttonTrayOptions.Click += new System.EventHandler(this.buttonTrayOptions_Click);
            //
            // groupBox2
            //
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.buttonSelectHitman);
            this.groupBox2.Controls.Add(this.buttonSelectPeacock);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(284, 80);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Launch Paths";
            //
            // buttonSelectPeacock
            //
            this.buttonSelectPeacock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectPeacock.Location = new System.Drawing.Point(7, 21);
            this.buttonSelectPeacock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectPeacock.Name = "buttonSelectPeacock";
            this.buttonSelectPeacock.Size = new System.Drawing.Size(271, 28);
            this.buttonSelectPeacock.TabIndex = 0;
            this.buttonSelectPeacock.Text = "Select Peacock Server Cmd";
            this.buttonSelectPeacock.UseVisualStyleBackColor = true;
            this.buttonSelectPeacock.Click += new System.EventHandler(this.buttonSelectPeacock_Click);
            //
            // buttonSelectHitman
            //
            this.buttonSelectHitman.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectHitman.Location = new System.Drawing.Point(7, 53);
            this.buttonSelectHitman.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelectHitman.Name = "buttonSelectHitman";
            this.buttonSelectHitman.Size = new System.Drawing.Size(271, 28);
            this.buttonSelectHitman.TabIndex = 1;
            this.buttonSelectHitman.Text = "Select Hitman Exe";
            this.buttonSelectHitman.UseVisualStyleBackColor = true;
            this.buttonSelectHitman.Click += new System.EventHandler(this.buttonSelectHitman_Click);
            //
            // groupBox3
            //
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.checkBoxAutoKillServer);
            this.groupBox3.Controls.Add(this.checkBoxAutoLaunchGame);
            this.groupBox3.Controls.Add(this.checkBoxAutoLaunchServer);
            this.groupBox3.Location = new System.Drawing.Point(12, 180);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(284, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Auto Launch Options";
            //
            // checkBoxAutoKillServer
            //
            this.checkBoxAutoKillServer.AutoSize = true;
            this.checkBoxAutoKillServer.Location = new System.Drawing.Point(7, 73);
            this.checkBoxAutoKillServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAutoKillServer.Name = "checkBoxAutoKillServer";
            this.checkBoxAutoKillServer.Size = new System.Drawing.Size(207, 20);
            this.checkBoxAutoKillServer.TabIndex = 2;
            this.checkBoxAutoKillServer.Text = "Auto kill server on game close";
            this.checkBoxAutoKillServer.UseVisualStyleBackColor = true;
            //
            // checkBoxAutoLaunchGame
            //
            this.checkBoxAutoLaunchGame.AutoSize = true;
            this.checkBoxAutoLaunchGame.Location = new System.Drawing.Point(7, 47);
            this.checkBoxAutoLaunchGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAutoLaunchGame.Name = "checkBoxAutoLaunchGame";
            this.checkBoxAutoLaunchGame.Size = new System.Drawing.Size(179, 20);
            this.checkBoxAutoLaunchGame.TabIndex = 1;
            this.checkBoxAutoLaunchGame.Text = "Auto launch game on start";
            this.checkBoxAutoLaunchGame.UseVisualStyleBackColor = true;
            //
            // checkBoxAutoLaunchServer
            //
            this.checkBoxAutoLaunchServer.AutoSize = true;
            this.checkBoxAutoLaunchServer.Location = new System.Drawing.Point(7, 21);
            this.checkBoxAutoLaunchServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAutoLaunchServer.Name = "checkBoxAutoLaunchServer";
            this.checkBoxAutoLaunchServer.Size = new System.Drawing.Size(194, 20);
            this.checkBoxAutoLaunchServer.TabIndex = 0;
            this.checkBoxAutoLaunchServer.Text = "Auto launch server on start";
            this.checkBoxAutoLaunchServer.UseVisualStyleBackColor = true;
            //
            // OptionsForm
            //
            this.AccessibleName = "Advanced options menu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 316);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonTrayOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Advanced Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonTrayOptions;

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHttp;
        private System.Windows.Forms.CheckBox dynResources;
		private System.Windows.Forms.CheckBox darkModeBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSelectPeacock;
        private System.Windows.Forms.Button buttonSelectHitman;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxAutoLaunchServer;
        private System.Windows.Forms.CheckBox checkBoxAutoLaunchGame;
        private System.Windows.Forms.CheckBox checkBoxAutoKillServer;
	}
}
