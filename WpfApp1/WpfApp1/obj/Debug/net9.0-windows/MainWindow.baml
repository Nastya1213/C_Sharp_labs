   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1050��6)   .��5	      � $��0,0,23,0q�6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	OrderGrid��5         AutoGenerateColumns$ False��5         SelectionMode$ Single=�5         CanUserAddRows$ False��5      $��	20,20,0,0q�5      ��5      �� *Orders+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6G   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 60   �� *Id+6G     5      $ Дата��6%   $ 50 6O   	 63   �� *	DateAdd+6O     5      $ Тип доставки��6%   $	 100 6[   	 6;   �� *TypeProduct+6[     5      $ Продукт��6%   $	 100 6R   	 66   �� *	Product+6R     5      $ Вес��6%   $ 50 6M   	 62   �� *Weight+6M     5      $ 
Объём��6%   $ 50 6O   	 64   �� *Volume+6O     5      $ Расстояние��6%   $ 80 6V   	 69   �� *
Distance+6V     5      $ Кол-во��6%   $ 50 6R   	 65   �� *
Quantity+6R     5      $ ФИО��6%   $	 120 6O   	 62   �� *
FullName+6O     5      $! Номер телефона��6%   $	 120 6]   	 6=   �� *PhoneNumber+6]     5      $ Статус��6%   $ 50 6P   	 65   �� *Status+6P     5       $ Отвественный��6%   	 6;   �� *ResponsibleEmployee+5"      �� 5$      $��1��6   
 �� Orientation$
 
Horizontal=�6   $��Center=�67   $��10q�6T   .+�5%   
   �� -   5        $��Добавить��5%      $	��100��6$   $��5q�60   6;   �� 5&   
   -   5        $ ��Редактировать��5&      $	��100��6)   $��5q�65   6@   �� 5'   
   -   5        $��Удалить��5'      $	��100��6#   $��5q�6/   6:   �� 5(   
   -   5        $��
Склад��5(      $	��100��6!   $��5q�6-   68   5)      5*      5+      