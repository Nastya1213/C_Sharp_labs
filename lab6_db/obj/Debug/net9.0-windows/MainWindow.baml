   M S B A M L   `   `   `  ����  lab6_db    lab6_db.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� -   5        $��Добавить��5      $��0,0,10,0q�6A   �� 5      -   5        $ ��Редактировать��5      $��0,0,10,0q�6G   �� 5      -   5        $��Удалить��5      6'   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ RequestsGrid��5      $��1��6)      AutoGenerateColumns$ False��5         SelectionMode$ Single=�5         CanUserAddRows$ False��5      $��10q�5      ��5      �� *
Requests+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6G   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 60   �� *Id+6G     5      $ Дата��6%   $		 120 6Q   
 63   �� *	DateAdded+6Q     5      $ Оборудование��6%   $		 150 6]   
 6;   �� *EquipmentType+6]     5      $ Модель��6%   $		 150 6X   
 65   �� *EquipmentModel+6X     5      $ Статус��6%   $		 120 6P   
 65   �� *Status+6P     5      $ Описание��6%   $		 100 6^   
 67   �� *ProblemDescription+6^     5      $ Клиент��6%   $		 150 6T   
 65   �� *
ClientName+6T   5      5       5!      