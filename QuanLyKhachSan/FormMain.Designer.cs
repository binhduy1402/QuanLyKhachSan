namespace QuanLyKhachSan
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lvDSPhong = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuĐăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchHoáĐơnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDSPhong
            // 
            this.lvDSPhong.BackColor = System.Drawing.Color.White;
            this.lvDSPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDSPhong.HideSelection = false;
            this.lvDSPhong.LargeImageList = this.imageList1;
            this.lvDSPhong.Location = new System.Drawing.Point(0, 28);
            this.lvDSPhong.Name = "lvDSPhong";
            this.lvDSPhong.Size = new System.Drawing.Size(1305, 592);
            this.lvDSPhong.TabIndex = 0;
            this.lvDSPhong.UseCompatibleStateImageBehavior = false;
            this.lvDSPhong.SelectedIndexChanged += new System.EventHandler(this.lvDSPhong_SelectedIndexChanged);
            this.lvDSPhong.Click += new System.EventHandler(this.lvDSPhong_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "trong.png");
            this.imageList1.Images.SetKeyName(1, "ban.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.thanhToánToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đóngToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chứcNăngToolStripMenuItem.Image")));
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức Năng";
            // 
            // đóngToolStripMenuItem
            // 
            this.đóngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đóngToolStripMenuItem.Image")));
            this.đóngToolStripMenuItem.Name = "đóngToolStripMenuItem";
            this.đóngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đóngToolStripMenuItem.Text = "Thoát";
            this.đóngToolStripMenuItem.Click += new System.EventHandler(this.đóngToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.phòngToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("danhMụcToolStripMenuItem.Image")));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.danhMụcToolStripMenuItem.Text = "Chức năng";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhânViênToolStripMenuItem.Image")));
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kháchHàngToolStripMenuItem.Image")));
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // phòngToolStripMenuItem
            // 
            this.phòngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("phòngToolStripMenuItem.Image")));
            this.phòngToolStripMenuItem.Name = "phòngToolStripMenuItem";
            this.phòngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phòngToolStripMenuItem.Text = "Phòng";
            this.phòngToolStripMenuItem.Click += new System.EventHandler(this.phòngToolStripMenuItem_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hoáĐơnToolStripMenuItem,
            this.phiếuĐăngKýToolStripMenuItem,
            this.danhSáchHoáĐơnToolStripMenuItem1});
            this.thanhToánToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thanhToánToolStripMenuItem.Image")));
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.thanhToánToolStripMenuItem.Text = "Thanh Toán";
            // 
            // hoáĐơnToolStripMenuItem
            // 
            this.hoáĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hoáĐơnToolStripMenuItem.Image")));
            this.hoáĐơnToolStripMenuItem.Name = "hoáĐơnToolStripMenuItem";
            this.hoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.hoáĐơnToolStripMenuItem.Text = "Hoá Đơn";
            this.hoáĐơnToolStripMenuItem.Click += new System.EventHandler(this.hoáĐơnToolStripMenuItem_Click);
            // 
            // phiếuĐăngKýToolStripMenuItem
            // 
            this.phiếuĐăngKýToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("phiếuĐăngKýToolStripMenuItem.Image")));
            this.phiếuĐăngKýToolStripMenuItem.Name = "phiếuĐăngKýToolStripMenuItem";
            this.phiếuĐăngKýToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.phiếuĐăngKýToolStripMenuItem.Text = "Phiếu Đăng Ký";
            this.phiếuĐăngKýToolStripMenuItem.Click += new System.EventHandler(this.phiếuĐăngKýToolStripMenuItem_Click);
            // 
            // danhSáchHoáĐơnToolStripMenuItem1
            // 
            this.danhSáchHoáĐơnToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("danhSáchHoáĐơnToolStripMenuItem1.Image")));
            this.danhSáchHoáĐơnToolStripMenuItem1.Name = "danhSáchHoáĐơnToolStripMenuItem1";
            this.danhSáchHoáĐơnToolStripMenuItem1.Size = new System.Drawing.Size(226, 26);
            this.danhSáchHoáĐơnToolStripMenuItem1.Text = "Danh Sách Hoá Đơn";
            this.danhSáchHoáĐơnToolStripMenuItem1.Click += new System.EventHandler(this.danhSáchHoáĐơnToolStripMenuItem1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1305, 620);
            this.Controls.Add(this.lvDSPhong);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "QUẢN LÝ KHÁCH SẠN";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvDSPhong;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuĐăngKýToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchHoáĐơnToolStripMenuItem1;
    }
}

