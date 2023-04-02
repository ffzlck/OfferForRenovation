using OfferForRenovation.Models;
using OfferForRenovation.ViewModels;
using System;
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
    /// Interaction logic for ComponentEditor.xaml
    /// </summary>
    public partial class ComponentEditor : Window
    {
        public ComponentEditor(Work work)
        {
            InitializeComponent();
            this.DataContext = new WorkEditorViewModel();
            (this.DataContext as WorkEditorViewModel).Setup(work);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
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
