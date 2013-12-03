using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for OrderPreview.xaml
    /// </summary>
    public partial class BillPreview : Window
    {
        FlowDocument document = new FlowDocument();
        double payedSum;
        double paySum;
        double deal;
        bool isPermitted = false;

        public BillPreview()
        {
            InitializeComponent();
            paySum = CurrentOrder.price;
            paySumTB.Text = paySum.ToString();     
        }
             

        public void printOrder() 
        {
            try
            {
                Paragraph paragraph = new Paragraph();
                document.FontFamily = new FontFamily("Arial");
                Bold caption = new Bold(new Run("Чек на оплату туристических услуг"));
                caption.FontSize = 18;
                paragraph.Inlines.Add(caption);
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run(DateTime.Now.ToString()));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Путевка: " + AppSettings.currentTourName));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("№ туристического ваучера " + CurrentOrder.voucher_id));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("------------------------------------------"));
                paragraph.Inlines.Add(new LineBreak());

                paragraph.Inlines.Add(new Bold(new Run("Сумма к оплате: " + CurrentOrder.price + ",00 грн.")));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("------------------------------------------"));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Оплачено: " + payedSum + " грн."));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Сдача: " + deal + "грн."));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("-----------------------------------------"));

                document.Blocks.Add(paragraph);

                PrintDialog pd = new PrintDialog();
                document.PageHeight = pd.PrintableAreaHeight;
                document.PageWidth = pd.PrintableAreaWidth;
                document.PagePadding = new Thickness(50);
                document.ColumnGap = 0;
                document.ColumnWidth = pd.PrintableAreaWidth;

                IDocumentPaginatorSource dps = document;
                pd.PrintDocument(dps.DocumentPaginator, "Чек");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);                        
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(isPermitted) printOrder();
            else MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            MessageBox.Show("Документ успешно нaпечатан", "Печать", MessageBoxButton.OK, MessageBoxImage.Information); 
        }

        private void payedSumTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void payedSumTB_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    try
                    {
                        payedSum = Convert.ToInt32(payedSumTB.Text);
                        deal = payedSum - paySum;
                        dealTB.Text = deal.ToString();
                        if (deal < 0) throw new Exception();
                        isPermitted = true;
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        isPermitted = false;
                    }
                }
            }
        }

        private void payedSumTB_LostMouseCapture(object sender, MouseEventArgs e)
        {
          
        }
    }
}
