   M S B A M L   `   `   `  ����Z  VEszaki_kozephegyseg_kilatoi_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Eszaki_kozephegyseg_kilatoi_GUIEszaki_kozephegyseg_kilatoi_GUI  5   	   0    *Eszaki_kozephegyseg_kilatoi_GUI.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Eszaki_kozephegyseg_kilatoi_GUI     5   	     � Title$'  !Északi középhegység kilátói��5   	   $	��660��6-   $	��800��6:   $��16(�6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��5* �6   �� 5      $
��0.5* �6   .+�5   
   �� 
����d�$��2��6,   $'��!Északi középhegység kilátói��6@   $��24(�6f   $
��Bold"�6t   $��Center=�6�   $��Center=�6�   
�������6�   �� 5   
   -   5         ��Name$ 	lbHegyseg��5      $��10q�6%   $��1��61   $��0��6>   6N   �� 5   
   
����d�$��0,0,0,0q�6,   $��0,0,0,0q�6=   $��3��6O   $��2��6\   $'��!Készítette: Vangel Celina Hanna��6p   $��16(�6�   $��Italic$�6�   $��Center=�6�   $��Center=�6�   
�������6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgDetails��5   A   $��1��6T   $��1��6d      AutoGenerateColumns$ False��6q   $��10q�6�      CanUserSortColumns$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Megnevezés��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *ViewpointName+  5      $
 Hegy��6%   	 63   �� *
Mountain+  5      $ 	Magasság��6%   
   SortDirection
 
Descending6d   	 67   �� *Height+ �� StringFormat$	 0 m��6d     5      $ Épült��6%   	 64   �� *Built+5      �� 5   
   -   5        $��txbDescription��5   =   $��0��6   $��2��6$   $��10q�61   $
��Wrap=�6S   �� 5    
   -   5        $��imgImage��5    9   $��1��6   $��2��6    $��10q�6-   69   5!      5"      