namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btRotate90 = new System.Windows.Forms.Button();
            this.btRotate180 = new System.Windows.Forms.Button();
            this.btRec = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.CutPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CutPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen.Location = new System.Drawing.Point(747, 29);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 1;
            this.btOpen.Text = "打开图片";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(747, 86);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 2;
            this.btNext.Text = "下一张";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btRotate90
            // 
            this.btRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotate90.Location = new System.Drawing.Point(657, 29);
            this.btRotate90.Name = "btRotate90";
            this.btRotate90.Size = new System.Drawing.Size(75, 23);
            this.btRotate90.TabIndex = 3;
            this.btRotate90.Text = "旋转90";
            this.btRotate90.UseVisualStyleBackColor = true;
            this.btRotate90.Click += new System.EventHandler(this.btRotate90_Click);
            // 
            // btRotate180
            // 
            this.btRotate180.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRotate180.Location = new System.Drawing.Point(657, 86);
            this.btRotate180.Name = "btRotate180";
            this.btRotate180.Size = new System.Drawing.Size(75, 23);
            this.btRotate180.TabIndex = 4;
            this.btRotate180.Text = "旋转180";
            this.btRotate180.UseVisualStyleBackColor = true;
            this.btRotate180.Click += new System.EventHandler(this.btRotate180_Click);
            // 
            // btRec
            // 
            this.btRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRec.Location = new System.Drawing.Point(657, 151);
            this.btRec.Name = "btRec";
            this.btRec.Size = new System.Drawing.Size(75, 23);
            this.btRec.TabIndex = 5;
            this.btRec.Text = "人脸识别";
            this.btRec.UseVisualStyleBackColor = true;
            this.btRec.Click += new System.EventHandler(this.btRec_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(747, 151);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // CutPicture
            // 
            this.CutPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CutPicture.Location = new System.Drawing.Point(657, 214);
            this.CutPicture.Name = "CutPicture";
            this.CutPicture.Size = new System.Drawing.Size(165, 156);
            this.CutPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CutPicture.TabIndex = 7;
            this.CutPicture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 483);
            this.Controls.Add(this.CutPicture);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btRec);
            this.Controls.Add(this.btRotate180);
            this.Controls.Add(this.btRotate90);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "图片查看器";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CutPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btRotate90;
        private System.Windows.Forms.Button btRotate180;
        private System.Windows.Forms.Button btRec;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.PictureBox CutPicture;
    }
}

