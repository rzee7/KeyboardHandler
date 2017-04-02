using System;

using UIKit;
using KeyboardHandler;

namespace KeyboardHandler.Demo
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			scrollView.ContentSize = new CoreGraphics.CGSize(this.View.Frame.Width, this.View.Frame.Height);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			scrollView.SubscribeKeyboardManager();
		}
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			scrollView.UnsubscribeKeyboardManager();
		}
	}
}
