using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace KeyboardHandler
{
    /// <summary>
    /// Keyboard Manager
    /// </summary>
    public class KeyboardManager
    {
        #region Private Fields

        private CGSize _keyboardFrame;

        #endregion

        #region Public Properties

        public UIScrollView View { get; set; } // The UIView for the keyboard handler
        public float ExtraHeight { get; set; }

        #endregion

        #region Keyboard Up Notification

        public void KeyboardUpNotification(NSNotification notification)
        {
            //Get the keyboard size UIKeyboardFrameEndUserInfoKey
            var val = notification.UserInfo.ValueForKey(UIKeyboard.FrameEndUserInfoKey) as NSValue;
            _keyboardFrame = val.RectangleFValue.Size;
            SetViewUp(true);
        }

        #endregion

        #region Keyboard Down Notification

        public void KeyboardDownNotification(NSNotification notification)
        {
            SetViewUp();
        }

        #endregion

        #region Set View Up/Down

        /// <summary>
        /// Sets the view up.
        /// </summary>
        /// <param name="isUp">If set to <c>true</c> is up.</param>
        internal void SetViewUp(bool isUp = false)
        {
            try
            {
                if (this.View == null)
                    return;
                UIEdgeInsets edgInset = isUp ? new UIEdgeInsets(0.0f, 0.0f, _keyboardFrame.Height + ExtraHeight, 0.0f) : UIEdgeInsets.Zero;
                this.View.ContentInset = edgInset;
                this.View.ScrollIndicatorInsets = edgInset;
            }
            catch (Exception ex)
            {
                //Eating Exception Here
            }
        }

        #endregion
    }
}
