   M S B A M L   `   `   `  ����F  BVRA.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VRA.WindowsVRA.Windows  5   	       VRA.Windows.WinEnterprise   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:VRA.Windows     5   	     � Title$  Предприятие��5   	   $	��165��6   $	��297��6*    � 
ResizeMode$ NoResize=�66    � SizeToContent$ WidthAndHeight=�6L    � WindowStartupLocation$ CenterOwner=�6k   .��5	      � $��0,0,4,4q�6    � RowDefinitions 5
   
   �� 5      $	��32* �6   �� 5      $	��46* �6   �� 5      $	��43* �6   �� 5      $	��11* �6    � ColumnDefinitions 5   
   �� 5      $
��148* �6   �� 5      $
��139* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��10,9.467,0,0q�6B   $
��Wrap=�6X   $-��'Название предприятия��6l   $	��Top=�6�   $��1��6�   �� 5   
   -   5         ��Name$ tbEnterprise��5      $
��Left=�6(   $��23��6C   $��11,9.467,0,0q�6O    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   $��1��6�   $��1��6�   �� 5   
   -   5        	 ��Name$	 btnSave��5      $��Сохранить��6"   $
��Left=�66   $��	10,19,0,0q�6Q   $	��Top=�6d   $	��105��6|   $��2��6�   �� 5   
   -   5        $	 	btnCancel��5      $��Отмена��6$   $
��Left=�65   $��	22,19,0,0q�6P   $	��Top=�6c   $	��109��6{   $��1��6�   $��2��6�   5      5      