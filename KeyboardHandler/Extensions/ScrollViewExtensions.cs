using System;
using Foundation;
using UIKit;

namespace KeyboardHandler
{
    /// <summary>
    /// Scroll View and UIView Extensions
    /// </summary>
    public static class ScrollViewExtensions
    {
        #region Private Fields

        private static readonly KeyboardManager kbHandler;
        private static NSObject keyboardUp;
        private static NSObject keyboardDown;

        #endregion

        #region Constructor

        static ScrollViewExtensions()
        {
            if (kbHandler == null)
                kbHandler = new KeyboardManager();
        }

        #endregion

        #region Subscribe  View Keyboard Handling

        /// <summary>
        /// Subscribes the keyboard manager.
        /// </summary>
        /// <param name="scrollView">Scroll view.</param>
        /// <param name="extraHeight">Extra height to make field just top of the keyboard, if UITextField is too high/hidden, Default is 70.</param>
        public static void SubscribeKeyboardManager(this UIScrollView scrollView, float extraHeight = 70)
        {
            kbHandler.View = scrollView;
            kbHandler.ExtraHeight = extraHeight;
            keyboardUp = NSNotificationCenter
                .DefaultCenter
                .AddObserver(UIKeyboard.DidShowNotification,
                    kbHandler.KeyboardUpNotification);
            keyboardDown = NSNotificationCenter
                .DefaultCenter
                .AddObserver(UIKeyboard.WillHideNotification,
                    kbHandler.KeyboardDownNotification);
        }

        #endregion

        #region Unsubscribe View Keyboard Handling

        public static void UnsubscribeKeyboardManager(this UIScrollView scrollView)
        {
            if (keyboardUp != null && keyboardDown != null)
            {
                NSNotificationCenter
                    .DefaultCenter
                    .RemoveObserver(keyboardUp);
                NSNotificationCenter
                    .DefaultCenter
                    .RemoveObserver(keyboardDown);
            }
        }

        #endregion
    }
}
