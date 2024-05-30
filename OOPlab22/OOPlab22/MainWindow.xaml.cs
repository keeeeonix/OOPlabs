using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPlab22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rtbeditor_Selectionchanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnbold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnitalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic)); temp =
            rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnunderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            cmbfontfamily.SelectedItem = temp;
            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            cmbfontsize.Text = temp.ToString();
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|all files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbeditor.Document.ContentStart, rtbeditor.Document.ContentEnd); range.Load(filestream, DataFormats.Rtf);
            }
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|all files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbeditor.Document.ContentStart, rtbeditor.Document.ContentEnd); range.Save(filestream, DataFormats.Rtf);
            }
        }
        private void cmbfontfamily_Selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbfontfamily.SelectedItem != null)
                rtbeditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbfontfamily.SelectedItem);
        }
        private void cmbfontsize_Textchanged(object sender, TextChangedEventArgs e)
        {
            rtbeditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbfontsize.Text);
        }

        private void btnunderline_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void insertImage_Click(object sender, RoutedEventArgs e)
        {
                OpenFileDialog ofdImage = new OpenFileDialog();
                Image insertImage;
                BlockUIContainer insertImageUIContainer;
            if (ofdImage.ShowDialog() == true)
            {
                insertImage = new Image() { Source = new BitmapImage(new Uri(ofdImage.FileName)), Stretch = Stretch.Uniform, Width = rtbeditor.ActualWidth - 50 };
                insertImageUIContainer = new BlockUIContainer(insertImage);
                rtbeditor.Document.Blocks.Add(insertImageUIContainer);
            }
        }
    }
}
