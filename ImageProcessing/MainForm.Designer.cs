
namespace ImageProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPicReset = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.blurLvl = new System.Windows.Forms.NumericUpDown();
            this.btnSobel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurLvl)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BackColor = System.Drawing.SystemColors.Window;
            this.picOriginal.Location = new System.Drawing.Point(13, 13);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(349, 347);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.SystemColors.Window;
            this.picResult.Location = new System.Drawing.Point(655, 13);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(349, 347);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 1;
            this.picResult.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(422, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(171, 38);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPicReset
            // 
            this.btnPicReset.Location = new System.Drawing.Point(422, 69);
            this.btnPicReset.Name = "btnPicReset";
            this.btnPicReset.Size = new System.Drawing.Size(171, 38);
            this.btnPicReset.TabIndex = 3;
            this.btnPicReset.Text = "Оригинал";
            this.btnPicReset.UseVisualStyleBackColor = true;
            this.btnPicReset.Click += new System.EventHandler(this.btnPicReset_Click);
            // 
            // btnGray
            // 
            this.btnGray.Location = new System.Drawing.Point(422, 134);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(171, 38);
            this.btnGray.TabIndex = 4;
            this.btnGray.Text = "Серый";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(422, 203);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(114, 38);
            this.btnBlur.TabIndex = 5;
            this.btnBlur.Text = "Размытие";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // blurLvl
            // 
            this.blurLvl.Location = new System.Drawing.Point(542, 214);
            this.blurLvl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blurLvl.Name = "blurLvl";
            this.blurLvl.Size = new System.Drawing.Size(51, 20);
            this.blurLvl.TabIndex = 6;
            this.blurLvl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(422, 261);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(171, 38);
            this.btnSobel.TabIndex = 7;
            this.btnSobel.Text = "Собель";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(422, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 388);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSobel);
            this.Controls.Add(this.blurLvl);
            this.Controls.Add(this.btnBlur);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.btnPicReset);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.picOriginal);
            this.Name = "MainForm";
            this.Text = "Фильтры изображений";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurLvl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPicReset;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.NumericUpDown blurLvl;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.Button btnSave;
    }
}

