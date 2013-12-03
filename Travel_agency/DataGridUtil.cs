using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;
using System.Collections;

class DataGridUtil
{
    public static string[,] ReadOnlyDataGridToArray(DataGrid dg)
    {
        string[,] array = new string[dg.Items.Count, dg.Columns.Count];
        for (int j = 0; j < dg.Columns.Count; j++)
        {
            for (int i = 0; i < dg.Items.Count ; i++)
            {
                array[i, j] = (dg.Items[i] as DataRowView).Row.ItemArray[j].ToString();
            }
        }
        return array;
    }

    public static string[,] DataGridToArray(DataGrid dg)
    {
        string[,] array = new string[dg.Items.Count, dg.Columns.Count];
        for (int j = 0; j < dg.Columns.Count; j++)
        {
            for (int i = 0; i < dg.Items.Count-1; i++)
            {
                array[i, j] = (dg.Items[i] as DataRowView).Row.ItemArray[j].ToString();
            }
        }
        return array;
    }
}