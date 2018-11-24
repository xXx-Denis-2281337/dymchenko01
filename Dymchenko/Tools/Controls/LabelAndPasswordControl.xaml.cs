﻿using System.Windows;

namespace Dymchenko.Tools.Controls
{
    public partial class LabelAndPasswordControl
    {
        public LabelAndPasswordControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register
        (
            "Password",
            typeof(string),
            typeof(LabelAndPasswordControl),
            new PropertyMetadata(null)
        );
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register
        (
            "Caption",
            typeof(string),
            typeof(LabelAndPasswordControl),
            new PropertyMetadata(string.Empty)
        );

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
    }
}
