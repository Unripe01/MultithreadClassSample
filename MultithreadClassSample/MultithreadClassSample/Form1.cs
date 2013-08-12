using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultithreadClassSample
{
	public partial class frm1 : Form
	{
		public frm1()
		{
			InitializeComponent();
		}

		private void ThreadSleep()
		{
			System.Threading.Thread.Sleep( 3000 );
		}

		private void timer1_Tick( object sender, EventArgs e )
		{
			lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		/// <summary>
		/// ボタンのEnableの変更を行なう
		/// </summary>
		private void EnableChange( object button, bool enable )
		{
			((Button)button).Enabled = enable;
		}

		/// <summary>
		/// スレッドなし
		/// </summary>
		private void btnNormal_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );//ボタン非活性
			this.ThreadSleep();
			this.EnableChange( sender, true );//ボタン非活性もどす
		}

		/// <summary>
		/// スレッドプールを使わないThread処理
		/// </summary>
		private void btnThread_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );//ボタン非活性

			//コールバックの実装
			//別スレッドから呼ばれるのでInvokeを使ってUIスレッド上での処理にする。
			Action callBackAction = () => {
				( (Button)sender ).Invoke(
					new MethodInvoker(
						() =>
						{
							this.EnableChange( sender, true );//ボタン非活性もどす
						}
					) );
			};

			//スレッドを作成して、終わる頃にActionをコールバックする。
			System.Threading.Thread t = new System.Threading.Thread(
				new System.Threading.ThreadStart( 
					() => { 
						this.ThreadSleep();
						callBackAction();
					} 
				) );
			t.Start();
		}

		/// <summary>
		/// Taskクラスを使った実装
		/// スレッドプールを使う 4.0から
		/// </summary>
		private void btnTask_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );//ボタン非活性

			//今のスレッドを保持
			//TaskのスレッドはUIスレッドとは違うので、どこで実行するか？の指定が必要なため
			var uiThread = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();

			//タスクの作成
			System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(
				() => { 
					this.ThreadSleep(); 
				}
			)
			.ContinueWith(//終わったら戻しといて。
				( c ) => { 
					this.EnableChange( sender, true );
					/*ボタン非活性もどす*/
				}
			, uiThread );
		}

		/// <summary>
		/// BackgroundWorkerを使った実装
		/// イベント型
		/// </summary>
		private void btnBkGround_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );//ボタン非活性

			var bk = new BackgroundWorker();
			//実行イベントを定義
			bk.DoWork += new DoWorkEventHandler( ( obj, args ) => {
				this.ThreadSleep(); 
			} );

			//完了時のイベントを定義
			bk.RunWorkerCompleted += new RunWorkerCompletedEventHandler( ( obj, args ) =>
			{
				this.EnableChange( sender, true );
			} );

			bk.RunWorkerAsync();
			
		}

		static bool eventCompleted = false;
		private void btnMyThread_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );

			//タスクの作成
			eventCompleted = false;
			System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(
				() =>
				{
					//待てする
					this.ThreadSleep();
					eventCompleted = true;
				}
			);

			//ぐるぐる待つ。時々DoEventsしてUIスレッドが止まっていない風にみせかける
			while( true )
			{
				System.Threading.Thread.Sleep( 100 );
				Application.DoEvents();
				if( eventCompleted )
				{
					break;
				}
			}
			this.EnableChange( sender, true );
		}

		/// <summary>
		/// スレッド風クラスを使ったスレッド処理
		/// </summary>
		private void btnMyThreadClass_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );
			var tl = new ThreadLike();

			//Actionが終わるまでこの行で止まる
			tl.WaitBackgroundAction( 
				() =>{this.ThreadSleep();}
			);

			this.EnableChange( sender, true );
		}

		/// <summary>
		/// スレッド風処理を使ったスレッドクラス（戻り値版）
		/// </summary>
		private void btnMyThreadClassFunc_Click( object sender, EventArgs e )
		{
			this.EnableChange( sender, false );
			var tl = new ThreadLike();

			//Funcが終わるまでこの行で止まる
			var result = tl.WaitBackgroundAction<string>(
				() => {
					this.ThreadSleep();
					throw new ApplicationException( "エラーが！" );
					return "Hello"; 
				}
			);

			this.EnableChange( sender, true );

			MessageBox.Show( result );

			//スレッド内で例外があったか？
			if( tl.ExceptionOccurred != null )
			{
				MessageBox.Show( tl.ExceptionOccurred.Message );
			}

		}

	}
}
