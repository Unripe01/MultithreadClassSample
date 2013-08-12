using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultithreadClassSample
{
	/// <summary>
	/// 擬似スレッド風クラスです。
	/// UI処理をブロックしないメソッド実行のメンバを提供します。
	/// スレッドセーフではないので、1インスタンス1メソッドの実行を行なって下さい。
	/// またこのクラスをスレッド呼び出しする検証は行っていません。
	/// </summary>
	class ThreadLike
	{
		/// <summary>
		/// 例外の存在有無
		/// </summary>
		public bool IsError;

		/// <summary>指定されたActionの完了確認</summary>
		private bool EventCompleted;

		/// <summary>
		/// スレッドプールで実行したActionが発生した例外
		/// </summary>
		public Exception OccurredException { get; private set; }

		/// <summary>
		/// 初期化
		/// </summary>
		private void Init()
		{
			IsError = false;
			EventCompleted = false;
		}

		public ThreadLike()
		{
			Init();
		}

		/// <summary>
		/// 指定したActionをスレッドプールを利用して実行します。
		/// Actionが完了するまでステートメントをブロックしますがUIコンテキストが止まることはありません。
		/// ActionにはUIスレッドを操作するロジックは実装しないでください。
		/// </summary>
		public void WaitBackgroundAction( Action action )
		{
			System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(
			() =>
			{
				try { action(); }
				catch( Exception exception )
				{
					this.IsError  = true;
					this.OccurredException = exception;
				}
				finally
				{
					EventCompleted = true;
				}
			} );

			//Actionが終わるまでぐるぐる待つ。時々たまったメッセージを処理してUIが止まって風に見せる
			while( true )
			{
				System.Threading.Thread.Sleep( 100 );
				System.Windows.Forms.Application.DoEvents();
				if( EventCompleted )
				{
					break;
				}
			}
		}

		/// <summary>
		/// 指定したFuncをスレッドプールを利用して実行します。
		/// Funcが完了するまでステートメントをブロックしますがUIコンテキストが止まることはありません。
		/// FuncにはUIスレッドを操作するロジックは実装しないでください。
		/// </summary>
		public T WaitBackgroundAction<T>( Func<T> function ) 
		{
			T temp = default(T);
			System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(
			() =>
			{
				try{temp = function();}
				catch( Exception exception )
				{
					this.IsError  = true;
					this.OccurredException = exception;
				}
				finally
				{
					EventCompleted = true;
				}
			} );

			//Funcが終わるまでぐるぐる待つ。時々たまったメッセージを処理してUIが止まって風に見せる
			while( true )
			{
				System.Threading.Thread.Sleep( 100 );
				System.Windows.Forms.Application.DoEvents();
				if( EventCompleted )
				{
					break;
				}
			}
			return temp;
		}

	}
}
