namespace StreamTrimTool
{

    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxStreamInput = new System.Windows.Forms.TextBox();
            this.buttonGetStream = new System.Windows.Forms.Button();
            this.comboBoxRenditionLists = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxRenditionStream = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonVlcPlay = new System.Windows.Forms.Button();
            this.buttonVlcStop = new System.Windows.Forms.Button();
            this.tableLayoutPanelPlayer = new System.Windows.Forms.TableLayoutPanel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFirstSegment = new System.Windows.Forms.TextBox();
            this.textBoxLastSegment = new System.Windows.Forms.TextBox();
            this.buttonSetAsFirst = new System.Windows.Forms.Button();
            this.buttonSetAsLast = new System.Windows.Forms.Button();
            this.textBoxCustomClipName = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMasterStream = new System.Windows.Forms.TextBox();
            this.comboBoxSegmentList = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxStreamInput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonGetStream, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxRenditionLists, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMasterStream, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSegmentList, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 811);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxStreamInput
            // 
            this.textBoxStreamInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStreamInput.Location = new System.Drawing.Point(5, 18);
            this.textBoxStreamInput.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxStreamInput.Name = "textBoxStreamInput";
            this.textBoxStreamInput.Size = new System.Drawing.Size(1564, 20);
            this.textBoxStreamInput.TabIndex = 0;
            this.textBoxStreamInput.Text = "Insert playback url here...";
            this.textBoxStreamInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetStream
            // 
            this.buttonGetStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGetStream.Location = new System.Drawing.Point(5, 45);
            this.buttonGetStream.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonGetStream.Name = "buttonGetStream";
            this.buttonGetStream.Size = new System.Drawing.Size(1564, 24);
            this.buttonGetStream.TabIndex = 1;
            this.buttonGetStream.Text = "Get Stream!";
            this.buttonGetStream.UseVisualStyleBackColor = true;
            this.buttonGetStream.Click += new System.EventHandler(this.ButtonGetStream_Click);
            // 
            // comboBoxRenditionLists
            // 
            this.comboBoxRenditionLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxRenditionLists.FormattingEnabled = true;
            this.comboBoxRenditionLists.Location = new System.Drawing.Point(5, 294);
            this.comboBoxRenditionLists.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comboBoxRenditionLists.Name = "comboBoxRenditionLists";
            this.comboBoxRenditionLists.Size = new System.Drawing.Size(1564, 21);
            this.comboBoxRenditionLists.TabIndex = 3;
            this.comboBoxRenditionLists.TextChanged += new System.EventHandler(this.ComboBoxRenditionLists_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxRenditionStream, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 346);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1572, 436);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // textBoxRenditionStream
            // 
            this.textBoxRenditionStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRenditionStream.Location = new System.Drawing.Point(3, 3);
            this.textBoxRenditionStream.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.textBoxRenditionStream.Multiline = true;
            this.textBoxRenditionStream.Name = "textBoxRenditionStream";
            this.textBoxRenditionStream.ReadOnly = true;
            this.textBoxRenditionStream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRenditionStream.Size = new System.Drawing.Size(939, 430);
            this.textBoxRenditionStream.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxPreview, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxSettings, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(944, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(628, 435);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPreview.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(622, 189);
            this.groupBoxPreview.TabIndex = 1;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanelPlayer, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(616, 170);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.buttonVlcPlay, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonVlcStop, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(432, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(184, 169);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // buttonVlcPlay
            // 
            this.buttonVlcPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVlcPlay.Location = new System.Drawing.Point(3, 0);
            this.buttonVlcPlay.Margin = new System.Windows.Forms.Padding(3, 0, 2, 3);
            this.buttonVlcPlay.Name = "buttonVlcPlay";
            this.buttonVlcPlay.Size = new System.Drawing.Size(179, 27);
            this.buttonVlcPlay.TabIndex = 0;
            this.buttonVlcPlay.Text = "Play";
            this.buttonVlcPlay.UseVisualStyleBackColor = true;
            this.buttonVlcPlay.Click += new System.EventHandler(this.ButtonVlcPlay_Click);
            // 
            // buttonVlcStop
            // 
            this.buttonVlcStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVlcStop.Location = new System.Drawing.Point(3, 33);
            this.buttonVlcStop.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.buttonVlcStop.Name = "buttonVlcStop";
            this.buttonVlcStop.Size = new System.Drawing.Size(179, 24);
            this.buttonVlcStop.TabIndex = 1;
            this.buttonVlcStop.Text = "Stop";
            this.buttonVlcStop.UseVisualStyleBackColor = true;
            this.buttonVlcStop.Click += new System.EventHandler(this.ButtonVlcStop_Click);
            // 
            // tableLayoutPanelPlayer
            // 
            this.tableLayoutPanelPlayer.ColumnCount = 1;
            this.tableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPlayer.Controls.Add(this.axWindowsMediaPlayer1, 0, 0);
            this.tableLayoutPanelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPlayer.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelPlayer.Name = "tableLayoutPanelPlayer";
            this.tableLayoutPanelPlayer.RowCount = 1;
            this.tableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanelPlayer.Size = new System.Drawing.Size(425, 164);
            this.tableLayoutPanelPlayer.TabIndex = 2;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(419, 158);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.tableLayoutPanel6);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 198);
            this.groupBoxSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(622, 236);
            this.groupBoxSettings.TabIndex = 2;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.textBoxFirstSegment, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBoxLastSegment, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.buttonSetAsFirst, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonSetAsLast, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBoxCustomClipName, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.buttonReset, 2, 6);
            this.tableLayoutPanel6.Controls.Add(this.buttonUpload, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 7;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.71429F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(616, 217);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // textBoxFirstSegment
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.textBoxFirstSegment, 2);
            this.textBoxFirstSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFirstSegment.Location = new System.Drawing.Point(3, 3);
            this.textBoxFirstSegment.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.textBoxFirstSegment.Name = "textBoxFirstSegment";
            this.textBoxFirstSegment.ReadOnly = true;
            this.textBoxFirstSegment.Size = new System.Drawing.Size(424, 20);
            this.textBoxFirstSegment.TabIndex = 0;
            this.textBoxFirstSegment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLastSegment
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.textBoxLastSegment, 2);
            this.textBoxLastSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLastSegment.Location = new System.Drawing.Point(3, 28);
            this.textBoxLastSegment.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.textBoxLastSegment.Name = "textBoxLastSegment";
            this.textBoxLastSegment.ReadOnly = true;
            this.textBoxLastSegment.Size = new System.Drawing.Size(424, 20);
            this.textBoxLastSegment.TabIndex = 1;
            this.textBoxLastSegment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetAsFirst
            // 
            this.buttonSetAsFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetAsFirst.Location = new System.Drawing.Point(433, 0);
            this.buttonSetAsFirst.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.buttonSetAsFirst.Name = "buttonSetAsFirst";
            this.buttonSetAsFirst.Size = new System.Drawing.Size(180, 23);
            this.buttonSetAsFirst.TabIndex = 2;
            this.buttonSetAsFirst.Text = "SET FIRST SEGMENT";
            this.buttonSetAsFirst.UseVisualStyleBackColor = true;
            this.buttonSetAsFirst.Click += new System.EventHandler(this.ButtonSetAsFirst_Click);
            // 
            // buttonSetAsLast
            // 
            this.buttonSetAsLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetAsLast.Location = new System.Drawing.Point(433, 25);
            this.buttonSetAsLast.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.buttonSetAsLast.Name = "buttonSetAsLast";
            this.buttonSetAsLast.Size = new System.Drawing.Size(180, 23);
            this.buttonSetAsLast.TabIndex = 3;
            this.buttonSetAsLast.Text = "SET LAST SEGMENT";
            this.buttonSetAsLast.UseVisualStyleBackColor = true;
            this.buttonSetAsLast.Click += new System.EventHandler(this.ButtonSetAsLast_Click);
            // 
            // textBoxCustomClipName
            // 
            this.textBoxCustomClipName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel6.SetColumnSpan(this.textBoxCustomClipName, 2);
            this.textBoxCustomClipName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCustomClipName.Location = new System.Drawing.Point(3, 105);
            this.textBoxCustomClipName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.textBoxCustomClipName.Name = "textBoxCustomClipName";
            this.textBoxCustomClipName.Size = new System.Drawing.Size(424, 20);
            this.textBoxCustomClipName.TabIndex = 7;
            this.textBoxCustomClipName.TextChanged += new System.EventHandler(this.textBoxCustomClipName_TextChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.IndianRed;
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Location = new System.Drawing.Point(433, 141);
            this.buttonReset.Name = "buttonReset";
            this.tableLayoutPanel6.SetRowSpan(this.buttonReset, 2);
            this.buttonReset.Size = new System.Drawing.Size(180, 73);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.Color.SteelBlue;
            this.tableLayoutPanel6.SetColumnSpan(this.buttonUpload, 2);
            this.buttonUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpload.Location = new System.Drawing.Point(3, 141);
            this.buttonUpload.Name = "buttonUpload";
            this.tableLayoutPanel6.SetRowSpan(this.buttonUpload, 2);
            this.buttonUpload.Size = new System.Drawing.Size(424, 73);
            this.buttonUpload.TabIndex = 5;
            this.buttonUpload.Text = "Upload to Akamai";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CLIP-OUT: set custom name ( leave empty to trim master playlist )";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBoxMasterStream
            // 
            this.textBoxMasterStream.AcceptsReturn = true;
            this.textBoxMasterStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMasterStream.Location = new System.Drawing.Point(5, 77);
            this.textBoxMasterStream.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxMasterStream.Multiline = true;
            this.textBoxMasterStream.Name = "textBoxMasterStream";
            this.textBoxMasterStream.ReadOnly = true;
            this.textBoxMasterStream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMasterStream.Size = new System.Drawing.Size(1564, 211);
            this.textBoxMasterStream.TabIndex = 6;
            // 
            // comboBoxSegmentList
            // 
            this.comboBoxSegmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSegmentList.FormattingEnabled = true;
            this.comboBoxSegmentList.Location = new System.Drawing.Point(5, 321);
            this.comboBoxSegmentList.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.comboBoxSegmentList.Name = "comboBoxSegmentList";
            this.comboBoxSegmentList.Size = new System.Drawing.Size(1564, 21);
            this.comboBoxSegmentList.TabIndex = 7;
            this.comboBoxSegmentList.TextChanged += new System.EventHandler(this.ComboBoxSegmentList_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Location = new System.Drawing.Point(0, 789);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1574, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Click += new System.EventHandler(this.StatusStrip1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 811);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1595, 1085);
            this.MinimumSize = new System.Drawing.Size(1287, 850);
            this.Name = "Form1";
            this.Text = "Stream Trim Tool - 1.1.0";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBoxPreview.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanelPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxStreamInput;
        private System.Windows.Forms.Button buttonGetStream;
        private System.Windows.Forms.ComboBox comboBoxRenditionLists;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxMasterStream;
        private System.Windows.Forms.TextBox textBoxRenditionStream;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonVlcPlay;
        private System.Windows.Forms.Button buttonVlcStop;
        private System.Windows.Forms.ComboBox comboBoxSegmentList;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox textBoxFirstSegment;
        private System.Windows.Forms.TextBox textBoxLastSegment;
        private System.Windows.Forms.Button buttonSetAsFirst;
        private System.Windows.Forms.Button buttonSetAsLast;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPlayer;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TextBox textBoxCustomClipName;
        private System.Windows.Forms.Label label1;
    }
}

