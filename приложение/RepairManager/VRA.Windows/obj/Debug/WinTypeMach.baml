   M S B A M L   `   `   `  ����F  BVRA.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VRA.WindowsVRA.Windows  5   	       VRA.Windows.WinTypeMach   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:VRA.Windows     5   	     � Title$  Вид станка��5   	   $	��240��6   $	��305��6)    � 
ResizeMode$ NoResize=�65    � SizeToContent$ WidthAndHeight=�6K    � WindowStartupLocation$ CenterOwner=�6j   .��5	      � $��10,0,4,7q�6    � RowDefinitions 5
   
   �� 5      $	��65* �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $
��143* �6   �� 5      $
��133* �6   �� 5      $	��13* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��0,10,0,0q�6B   $
��Wrap=�6T   $��Код станка*��6h   $	��Top=�6{   $��1��6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��0,52,0,0q�6C   $
��Wrap=�6U   $��Марка*��6i   $	��Top=�6w   $��1��6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��0,95,0,0q�6C   $
��Wrap=�6U   $��Год выпуска*��6i   $	��Top=�6}   $��1��6�   �� 5   
   -   5         ��Name$ tbCodeMachine��5      $
��Left=�6)   $��23��6D   $��9,10,0,0q�6P    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   $��2��6�   $��2��6�   �� 5   
   -   5        $ tbMark��5      $
��Left=�6"   $��23��6=   $��9,51,0,0q�6I   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��120��6�   $��2��6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 btnSave��5      $��Сохранить��6"   $
��Left=�66   $��	0,173,0,0q�6Q   $	��Top=�6d   $	��104��6|   $��1��6�   �� 5   
   -   5        $	 	btnCancel��5      $��Отмена��6$   $
��Left=�65   $��
29,173,0,0q�6P   $	��Top=�6d   $	��104��6|   $��2��6�   $��2��6�   �� 5   
   -   5        $ dpData��5      $
��Left=�6"   $��23��6=   $��9,94,0,0q�6I   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��120��6�   $��2��6�   $��2��6�   �� 5   
   -	   5        $ 
textBlock3��5      $
��Left=�6(   $��	0,140,0,0q�6C   $
��Wrap=�6V   $:��4обязательные поля помечены *��6j   $	��Top=�6�   $��1��6�   $��2��6�   5      5      