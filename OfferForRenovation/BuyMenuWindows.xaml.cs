﻿using OfferForRenovation.Models;
using OfferForRenovation.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OfferForRenovation
{
    /// <summary>
    /// Interaction logic for BuyMenuWindows.xaml
    /// </summary>
    public partial class BuyMenuWindows : Window
    {
        public BuyMenuWindows(Work work)
        {
            InitializeComponent();
            this.DataContext = new BuyMenuViewModell();
            (this.DataContext as BuyMenuViewModell).Setup(work);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in buy_stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource(); 
                }
            }
            this.DialogResult = true;
        }
    }
}
