   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5       Travel_agency$   Travel_agency.Pages.Statistics   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Atoolkit-http://schemas.microsoft.com/wpf/2008/toolkit     5      �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5        N� Title$  
Отчет��5	       N� 
Background 5      �� 5   
    �� ImageSource$- '/Travel_agency;component/Images/bgn.png��6   .��5      � .+�5   
   � $
��Left=�6   $	��800��6*   $	��500��66   $��0,0,0,0q�6C    � RowDefinitions 5      �� 5      $	��89* �6    �� 5      $	��11* �6    .+�5      �� $E��?/Travel_agency;component/Images/side panel images/graphSide.jpg��6   $��
-9,0,600,0q�6]   $��2��6q   �� 5      $��193,0,584,0q�6    J� RenderTransformOrigin$ 0.5,0.5&�6-   $��2��6M   z�5      V� 5      .~�5      ��  �� ScaleX$ -1Q�6)   �� 5      �� 5      T� 5      5      ��5       �� 5!       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5"      �  � Color$ 	#33FFFFFF��6'   	 � Offset$	 0Q�69   � 5#      $ White��6'   $	 1Q�65   5$      5&      >   8System.Windows.Controls.DataVisualization.Charting.Chart  5'      $��223,124,10,10q�6   $��2��64   
 J� IsHitTestVisible
 .  ��5(      �� 5)      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5*      � $ 	#33FFFFFF��6'   $	 0Q�69   � 5+      $ 	#7FFFFFFF��6'   $	 1Q�69   5,         Series. 5.      C   =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5        $��ChartOne��5.   &   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value��5/   	      IndependentValuePath$ Month��6$   ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Количество��6A   50      �� 51      -   5         ��Name$ routeCb��51   6   $
��Left=�6G   $��
362,84,0,0q�6b   $	��Top=�6v   $	��318��6�   ��6   �� *routes+6�   �� 52         
LabelStyle#��[  6   $%��Название путевки��68   $
��Left=�6S   $��
228,75,0,0q�6n   $	��Top=�6�   54      �� 55   
   #��[  6   $��36(�64   $'��!Статистика продаж��6B   $
��Left=�6^   $��
227,10,0,0q�6y   $	��Top=�6�   $��78��6�   $	��420��6�   �� 56   
   $��	0,0,604,0q�6   $ 0.5,0.5&�6'   ���	#7FFFFFFF6G   57      58      