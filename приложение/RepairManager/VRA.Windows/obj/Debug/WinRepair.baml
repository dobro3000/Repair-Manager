   M S B A M L   `   `   `  ����F  BVRA.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VRA.WindowsVRA.Windows  5   	       VRA.Windows.WinAddRepair   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:VRA.Windows     5   	     � Title$  Ремонт станка��5   	   $	��366��6   $	��305��6,    � 
ResizeMode$ NoResize=�68    � SizeToContent$ WidthAndHeight=�6N    � WindowStartupLocation$ CenterOwner=�6m   .��5	      � $��0,0,2,7q�6    � RowDefinitions 5
   
   �� 5      $	��16* �6   �� 5      $
��275* �6   �� 5      $	��39* �6    � ColumnDefinitions 5   
   �� 5      $	��41* �6   �� 5      $	��32* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��10,4,0,0q�6B   $
��Wrap=�6T   $��Станок��6h   $	��Top=�6v   $��1��6�   �� 5   
   -   5         ��Name$ 	cbMachine��5      $
��Left=�6&   $��	162,4,0,0q�6A   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$ CodeMashine��6�   $��2��6�   $��1��6�   ��6x   �� 6�   �� 5   
   -   5        $ cbTypeRepair��5      $
��Left=�6)   $��
162,45,0,0q�6D   $	��Top=�6X   $	��120��6p   $ NameTypeRepair��6�   $��2��6�   $��1��6�   ��6|   �� 6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	10,51,0,0q�6C   $
��Wrap=�6V   $	��Top=�6j   $��1��6�   �� 6�   $�Вид��6�   �� 6�   $� ��6�   �� 6�   $�ремонта��6�   6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��	10,93,0,0q�6C   $
��Wrap=�6V   $!��Начало ремонта��6j   $	��Top=�6�   $��1��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dpStartDate��5   h   $
��Left=�6   $��
162,93,0,0q�60   $	��Top=�6D   $	��120��6\   $��2��6}   $��1��6�   �� 5   
   -   5        
 ��Name$
 tmNote��5      $
��Left=�6"   $��87��6=   $��
10,158,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��272��6�   $��2��6�   $��1��6�   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��
10,137,0,0q�6C   $
��Wrap=�6W   $��Примечание��6k   $	��Top=�6}   $��1��6�   �� 5   
   -	   5         ��Name$ btnSave��5      $��Сохранить��6"   $
��Left=�66   $��	10,16,0,0q�6Q   $	��Top=�6d   $	��114��6|   $��2��6�   �� 5   
   -
   5        $ 	btnCancel��5      $��Отмена��6$   $
��Left=�65   $��0,16,0,0q�6P   $	��Top=�6b   $	��120��6z   $��1��6�   $��2��6�   �� 5   
   -   5        $ 
textBlock4��5      $
��Left=�6(   $��
10,250,0,0q�6C   $
��Wrap=�6W   $:��4обязательные поля помечены *��6k   $	��Top=�6�   $��2��6�   $��1��6�   5      5       