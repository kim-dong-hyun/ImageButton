// --------------------------------
// <copyright file="ToggleImageButton.cs" company="SyntaxStudio">
//     Copyright 2012, www.syntaxstudio.co.uk
// </copyright>
// <author>Ryan Haworth</author>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace SyntaxStudio.ToggleImageButton
{
    /// <summary>
    /// The is is a custom control class for the toggle button.  This toggle button will
    /// accept two images.  As the button is toggled between an inactive state to an
    /// active state the button will change its image.
    /// </summary>
    public class ImageButton : ButtonBase
    {
        private static readonly DependencyProperty CurrentImageProperty = DependencyProperty.Register("CurrentImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty UnCheckedImageProperty = DependencyProperty.Register("UnCheckedImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty UnCheckedHoverImageProperty = DependencyProperty.Register("UnCheckedHoverImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty CheckedImageProperty = DependencyProperty.Register("CheckedImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty CheckedHoverImageProperty = DependencyProperty.Register("CheckedHoverImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty PressedImageProperty = DependencyProperty.Register("PressedImage", typeof(ImageSource), typeof(ImageButton));
        private static readonly DependencyProperty DisabledImageProperty = DependencyProperty.Register("DisabledImage", typeof(ImageSource), typeof(ImageButton));

        private bool isHovering = false;

        private bool isChecked = false;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (value == false)
                {
                    if (isHovering == false)
                        CurrentImage = UnCheckedImage;
                    else
                        CurrentImage = UnCheckedHoverImage;
                }
                else
                {
                    if (isHovering == false)
                        CurrentImage = CheckedImage;
                    else
                        CurrentImage = CheckedHoverImage;
                }
                isChecked = value;
            }
        }

        private bool isDisabled = false;
        public bool IsDisabled
        {
            get { return isDisabled; }
            set
            {
                if (value == false)
                {
                    CurrentImage = UnCheckedImage;
                }
                else
                {
                    CurrentImage = DisabledImage;
                }
            }
        }

        public ImageSource CurrentImage
        {
            get { return (ImageSource)GetValue(CurrentImageProperty); }
            set { SetValue(CurrentImageProperty, value); }
        }

        public ImageSource UnCheckedImage
        {
            get { return (ImageSource)GetValue(UnCheckedImageProperty); }
            set { SetValue(UnCheckedImageProperty, value); }
        }

        public ImageSource UnCheckedHoverImage
        {
            get { return (ImageSource)GetValue(UnCheckedHoverImageProperty); }
            set { SetValue(UnCheckedHoverImageProperty, value); }
        }

        public ImageSource CheckedImage
        {
            get { return (ImageSource)GetValue(CheckedImageProperty); }
            set { SetValue(CheckedImageProperty, value); }
        }

        public ImageSource CheckedHoverImage
        {
            get { return (ImageSource)GetValue(CheckedHoverImageProperty); }
            set { SetValue(CheckedHoverImageProperty, value); }
        }

        public ImageSource PressedImage
        {
            get { return (ImageSource)GetValue(PressedImageProperty); }
            set { SetValue(PressedImageProperty, value); }
        }

        public ImageSource DisabledImage
        {
            get { return (ImageSource)GetValue(DisabledImageProperty); }
            set { SetValue(DisabledImageProperty, value); }
        }

        public ImageButton()
        {
            CurrentImage = UnCheckedImage;
        }

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            isHovering = true;

            if (IsChecked == false)
            {
                if (UnCheckedHoverImage != null)
                    CurrentImage = UnCheckedHoverImage;
            }
            else
            {
                if (CheckedHoverImage != null)
                    CurrentImage = CheckedHoverImage;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            isHovering = false;

            if (IsChecked == false)
            {
                if (UnCheckedImage != null)
                    CurrentImage = UnCheckedImage;
            }
            else
            {
                if (CheckedImage != null)
                    CurrentImage = CheckedImage;
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (PressedImage != null)
                CurrentImage = PressedImage;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (PressedImage != null)
            {
                if (IsChecked == true)
                    CurrentImage = CheckedImage;
                else
                    CurrentImage = UnCheckedImage;
            }
        }
    }
}
