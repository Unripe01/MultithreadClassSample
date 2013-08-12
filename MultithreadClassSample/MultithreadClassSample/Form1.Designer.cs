namespace MultithreadClassSample
{
	partial class frm1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label lblTitle;
			this.lblTime = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnNormal = new System.Windows.Forms.Button();
			this.btnThread = new System.Windows.Forms.Button();
			this.btnTask = new System.Windows.Forms.Button();
			this.btnBkGround = new System.Windows.Forms.Button();
			this.btnMyThread = new System.Windows.Forms.Button();
			this.btnMyThreadClass = new System.Windows.Forms.Button();
			this.btnMyThreadClassFunc = new System.Windows.Forms.Button();
			lblTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			lblTitle.Location = new System.Drawing.Point(13, 13);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(483, 57);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "1秒間隔で動くタイマーは、ラベルに現在時間を表示しています。\r\nボタンクリックでThread.Sleep(3000)を行います。\r\n基本的にはUIスレッドが止まり" +
    "ます。";
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTime.Location = new System.Drawing.Point(502, 56);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(137, 35);
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "00:00:00";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnNormal
			// 
			this.btnNormal.Location = new System.Drawing.Point(17, 146);
			this.btnNormal.Name = "btnNormal";
			this.btnNormal.Size = new System.Drawing.Size(156, 23);
			this.btnNormal.TabIndex = 2;
			this.btnNormal.Text = "通常Sleep";
			this.btnNormal.UseVisualStyleBackColor = true;
			this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
			// 
			// btnThread
			// 
			this.btnThread.Location = new System.Drawing.Point(180, 146);
			this.btnThread.Name = "btnThread";
			this.btnThread.Size = new System.Drawing.Size(130, 23);
			this.btnThread.TabIndex = 3;
			this.btnThread.Text = "NEW スレッド";
			this.btnThread.UseVisualStyleBackColor = true;
			this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
			// 
			// btnTask
			// 
			this.btnTask.Location = new System.Drawing.Point(180, 235);
			this.btnTask.Name = "btnTask";
			this.btnTask.Size = new System.Drawing.Size(130, 23);
			this.btnTask.TabIndex = 4;
			this.btnTask.Text = "Task";
			this.btnTask.UseVisualStyleBackColor = true;
			this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
			// 
			// btnBkGround
			// 
			this.btnBkGround.Location = new System.Drawing.Point(180, 190);
			this.btnBkGround.Name = "btnBkGround";
			this.btnBkGround.Size = new System.Drawing.Size(130, 23);
			this.btnBkGround.TabIndex = 5;
			this.btnBkGround.Text = "BackgroundWorker";
			this.btnBkGround.UseVisualStyleBackColor = true;
			this.btnBkGround.Click += new System.EventHandler(this.btnBkGround_Click);
			// 
			// btnMyThread
			// 
			this.btnMyThread.Location = new System.Drawing.Point(328, 146);
			this.btnMyThread.Name = "btnMyThread";
			this.btnMyThread.Size = new System.Drawing.Size(146, 23);
			this.btnMyThread.TabIndex = 6;
			this.btnMyThread.Text = "btnMyThread";
			this.btnMyThread.UseVisualStyleBackColor = true;
			this.btnMyThread.Click += new System.EventHandler(this.btnMyThread_Click);
			// 
			// btnMyThreadClass
			// 
			this.btnMyThreadClass.Location = new System.Drawing.Point(328, 190);
			this.btnMyThreadClass.Name = "btnMyThreadClass";
			this.btnMyThreadClass.Size = new System.Drawing.Size(146, 23);
			this.btnMyThreadClass.TabIndex = 6;
			this.btnMyThreadClass.Text = "btnMyThreadClass";
			this.btnMyThreadClass.UseVisualStyleBackColor = true;
			this.btnMyThreadClass.Click += new System.EventHandler(this.btnMyThreadClass_Click);
			// 
			// btnMyThreadClassFunc
			// 
			this.btnMyThreadClassFunc.Location = new System.Drawing.Point(493, 190);
			this.btnMyThreadClassFunc.Name = "btnMyThreadClassFunc";
			this.btnMyThreadClassFunc.Size = new System.Drawing.Size(146, 23);
			this.btnMyThreadClassFunc.TabIndex = 6;
			this.btnMyThreadClassFunc.Text = "btnMyThreadClassFunc";
			this.btnMyThreadClassFunc.UseVisualStyleBackColor = true;
			this.btnMyThreadClassFunc.Click += new System.EventHandler(this.btnMyThreadClassFunc_Click);
			// 
			// frm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 332);
			this.Controls.Add(this.btnMyThreadClassFunc);
			this.Controls.Add(this.btnMyThreadClass);
			this.Controls.Add(this.btnMyThread);
			this.Controls.Add(this.btnBkGround);
			this.Controls.Add(this.btnTask);
			this.Controls.Add(this.btnThread);
			this.Controls.Add(this.btnNormal);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(lblTitle);
			this.Name = "frm1";
			this.Text = "MultithreaClassSample";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnNormal;
		private System.Windows.Forms.Button btnThread;
		private System.Windows.Forms.Button btnTask;
		private System.Windows.Forms.Button btnBkGround;
		private System.Windows.Forms.Button btnMyThread;
		private System.Windows.Forms.Button btnMyThreadClass;
		private System.Windows.Forms.Button btnMyThreadClassFunc;
	}
}

