   M S B A M L   `   `   `  ����  lab6_db    lab6_db.RequestWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Заявка��5   	   $	��400��6   $	��400��6%    � WindowStartupLocation$ CenterScreen=�61   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $$��Дата добавления:��6   $��0��6+   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��DateAddedPicker��5      $��0��6,   $��	120,0,0,5q�69      SelectedDate 6L   �� *	DateAdded+�� 5   
   $&�� Тип оборудования:��6   $��1��6,   �� 5   
   -   5        $��EquipmentTypeTextBox��5      $��1��6.   $��	120,0,0,5q�6;   ��6N   �� *EquipmentType+�� 5   
   $��Модель:��6   $��2��6"   �� 5   
   -   5        $��EquipmentModelTextBox��5      $��2��6/   $��	120,0,0,5q�6<   ��6O   �� *EquipmentModel+�� 5   
   $��Статус:��6   $��3��6"   �� 5   
   -   5        $��StatusComboBox��5      $��3��6)   $��	120,0,0,5q�66    �� SelectedValuePath$ Content��5   4    �� SelectedValue 6   �� *Status+.@�5      �� .��6   
Новая6"   �� 5      .��6   В работе6%   �� 5      .��6   Завершена6&   5       �� 5"   
   $(��"Описание проблемы:��6   $��4��6-   �� 5#   
   -   5        $��ProblemDescriptionTextBox��5#      $��4��63   $��	120,0,0,5q�6@   ��6S   �� *ProblemDescription+�� 5%   
   $��Клиент:��6   $��5��6"   �� 5&   
   -   5        $��ClientNameTextBox��5&      $��5��6+   $��	120,0,0,5q�68   ��6K   �� *
ClientName+�� 5(   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5)      �� -   5        $��Сохранить��5)      $��80��6B   $��0,0,10,0q�6M   �� 5*      -   5        $��Отмена��5*      $��80��6A   5+      5,      5-      