   M S B A M L   `   `   `  ����m  iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting  5   	   \ XWebExpo.InterfaceGraphique.Csharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:WebExpo.InterfaceGraphique.Properties%WebExpo.InterfaceGraphique.Properties 5   	   *   $WebExpo.InterfaceGraphique.Resultats   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5   	   Ap3clr-namespace:WebExpo.InterfaceGraphique.Properties     5   	   -   5        5  /WebExpo.InterfaceGraphique.Properties.Resources    MarcovHisto � Title# Z  5	   	   $	��900��64   $	��850��6A    � WindowState$ 	Minimized=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   .+�5   
   7  1System.Windows.Forms.Integration.WindowsFormsHost  $��0��6   $��0��6(   $
��Left=�68   $	��250��6S   $��	20,20,0,0q�6`   $	��Top=�6s   $	��800��6�      Child. 5      ;   5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        histoMu��[ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  System.Windows.Forms.Control   Dock$
 Left=�5   2      Series 5      <   6System.Windows.Forms.DataVisualization.Charting.Series  5         Name$ mu��6*   	   	ChartType$	 Column=�64   O   ISystem.Windows.Forms.DataVisualization.Charting.DataPointCustomProperties
   ColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$	
 Red 6G      
ChartAreas 5      ?   9System.Windows.Forms.DataVisualization.Charting.ChartArea  5         Legends 5      <	   6System.Windows.Forms.DataVisualization.Charting.Legend	  5      5       5!        5"   
   $��1��6   $��0��6(   $
��Left=�68   $	��250��6S   $��	20,20,0,0q�6`   $	��Top=�6s   $	��800��6�   . 5#        -   5        
histoSigma��$
 Left=�5#   5    5$        5%      $ sigma��6*   $	 Column=�67    5'        5(       5*      	  5+      5-      5.        5/   
   $��2��6   $��0��6(   $
��Left=�68   $	��250��6S   $��	20,20,0,0q�6`   $	��Top=�6s   $	��800��6�   . 50        -   5        histoSigma2��$
 Left=�50   6    51        52      $ sigma��6*   $	 Column=�67    54        55       57      	  58      5:      5;      5<      5=      