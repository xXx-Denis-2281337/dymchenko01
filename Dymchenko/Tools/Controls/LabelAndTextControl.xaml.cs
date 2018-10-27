﻿using System.Windows;
using System.Windows.Controls;

namespace Dymchenko.Tools.Controls
{
    /// <summary>
    /// Логика взаимодействия для LabelAndTextControl.xaml
    /// </summary>
    public partial class LabelAndTextControl
    {
        public LabelAndTextControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            "Text",
            typeof(string),
            typeof(LabelAndTextControl),
            new PropertyMetadata(null)
        );
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register
        (
            "Caption",
            typeof(string),
            typeof(LabelAndTextControl),
            new PropertyMetadata(null)
        );

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
    }
}
