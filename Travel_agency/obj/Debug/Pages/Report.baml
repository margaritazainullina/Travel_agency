   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5       Travel_agency    Travel_agency.Pages.Report   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Atoolkit-http://schemas.microsoft.com/wpf/2008/toolkit     5      �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5      -   5          N� Title$  
Отчет��5	       N� 
Background 5      �� 5   
    �� ImageSource$- '/Travel_agency;component/Images/bgn.png��6   .��5      � .+�5   
   � $
��Left=�6   $	��900��6*   $	��700��66   $��0,0,0,0q�6C   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridRoutes��5       �� DisplayMemberPath$  ��5         
IsReadOnly . }�. $��322,57,13,423q�6F   ��5      �� *orders+5   F   �� 5      $G��A/Travel_agency;component/Images/side panel images/sideReports.jpg��6   $��-43,0,578,0q�6_   �� 5      $��280,0,600,-10q�6    J� RenderTransformOrigin$ 0.5,0.5&�6/   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      � 	 � Color$	 	#33FFFFFF��6'   
 � Offset$
 0Q�69   � 5      $	 White��6'   $
 1Q�65   5      5      �� 5       -   5        $��Center=�5!      $��Center=�5"      $��50��6)   $	��138��65   $��749,299,13,351q�6A   .��5#      ��  �� Orientation$ 
Horizontal=�6   $	��128��66   .+�5$      �� $3��-/Travel_agency;component/Icons/hp_printer.ico��6   �� 5%      $��Center=�6    $��Center=�6=   �� 6Y   $�  Печать��6]   $��SegoeUI Light)�6m   $��Light"�6�   $��14(�6�   6�   5&      5'      >   8System.Windows.Controls.DataVisualization.Charting.Chart  5+         LegendTitle$, &Объем продаж путевок��6   $��322,359,13,10q�6@   ��5,      �� 5-      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5.      � $	 	#33FFFFFF��6'   $
 0Q�69   � 5/      $	 	#7FFFFFFF��6'   $
 1Q�69   50         Series. 52      B   <System.Windows.Controls.DataVisualization.Charting.PieSeries  -   5          Name$ PieChart��52   %   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   ItemsSource 53      ��    IndependentValueBinding 54      �� *Путевка+   DependentValueBinding 55      �� *(&Объем продаж путевки+��56      �� 57      $ 0.5,1&�6.   $ 0.5,0&�6?   .��58      � $	 Black��6+   $
 0Q�69   � 59      $	 	#FF131313��6+   $
 1Q�6=   5:      5<      5=      5?      �� 5A   
      
LabelStyle#��[  6   $��Период:��64   $
��Left=�6F   $��322,284,0,0q�6a   $	��Top=�6v   $��35��6�   $��93��6�   �� 5B   
   #��[  6   $
��от��64   $
��Left=�6A   $��322,319,0,0q�6\   $	��Top=�6q   $��35��6�   $��37��6�   �� 5C   
   -   5         ��Name$ tb_begin_date��5C      $
��Left=�6)   $��25��6D   $��346,324,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $��82��6�   �� 5D   
   #��[  6   $
��до��64   $
��Left=�6A   $��433,319,0,0q�6\   $	��Top=�6q   $��35��6�   $��32��6�   �� 5F   
   -   5        $ tb_end_date��5F      $
��Left=�6'   $��25��6B   $��455,324,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $��82��6�   �� 5G   
   -   5         ��Name$ create_rep_btn��5G      $
��Left=�5H      $��Center=�5I      $��50��6#   $��558,299,0,351q�6/   $	��184��6F   .��5J      �� $ 
Horizontal=�6   $	��184��62   .+�5K      �� $:��4/Travel_agency;component/Icons/kontact_date_4272.ico��6   �� 5L      $��Center=�6   $��Center=�69   �� 6U   $)�#  Формировать отчет��6Y   $��SegoeUI Light)�6t   $��Light"�6�   $��14(�6�   6�   5M      5N      �� 5O   
   #��[  6   $��36(�64   $#��Продажи путевок��6B   $
��Left=�6\   $��	322,0,0,0q�6w   $	��Top=�6�   $��78��6�   $	��420��6�   �� 5P   
   $��	0,0,621,0q�6   $ 0.5,0.5&�6'   ���	#7FFFFFFF6G   5Q      5R      