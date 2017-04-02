# KeyboardHandler
Handle UITextView scroll up while Keyboard up. 

Download Nuget 
## PM> Install-Package Keyboard.Handler ##

*Note: Your controls must be in scrollview already.*

## How to use: ##

    using KeyboardHandler;
    
    
    public override void ViewWillAppear(bool animated)
  	{
      base.ViewWillAppear(animated);
      this.yourScrollView.SubscribeKeyboardManaqger();
  	}
    
    public override void ViewWillDisappear(bool animated)
  	{
      base.ViewWillDisappear(animated);
      this.yourScrollView.UnsubscribeKeyboardManaqger();
  	}
    
![](https://media.giphy.com/media/oo96jTyYns7EA/giphy.gif)
