   M S B A M L   `   `   `  ����F  BVRA.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:VRA.WindowsVRA.Windows  5   	       VRA.Windows.WinMachine   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:VRA.Windows     5   	     � Title$  Станки��5   	   $	��272��6   $	��306��6%    � 
ResizeMode$ NoResize=�61    � SizeToContent$ WidthAndHeight=�6G    � WindowStartupLocation$ CenterOwner=�6f   .��5	      � $��0,0,4,7q�6    � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      $	��77* �6   �� 5      $	��71* �6   .+�5   
   �� -   5         ��Name$ cbCodeMachine��5      $
��Left=�6*   $��8,24,0,0q�6E   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ CodeMachine��6�   $��1��6�   ��6{   �� 6�   �� 5   
   -   5        $ cbEnterprise��5      $
��Left=�6)   $��8,71,0,0q�6D   $	��Top=�6V   $	��120��6n   $ NameEnterprise��6�   $��1��6�   ��6z   �� 6�   �� 5   
   -   5        $ 	cbCountry��5      $
��Left=�6&   $��	8,116,0,0q�6A   $	��Top=�6T   $	��120��6l   $ NameCountry��6�   $��1��6�   ��6x   �� 6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	23,24,0,0q�6B   $
��Wrap=�6U   $	��Top=�6i   �� 6�   $�Код станка��6�   �� 6�   $�*��6�   6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	23,71,0,0q�6C   $
��Wrap=�6V   $	��Top=�6j   �� 6�   $�Предприятие��6�   �� 6�   $�*��6�   6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��
23,116,0,0q�6C   $
��Wrap=�6W   $	��Top=�6k   �� 6�   $�Страна��6�   �� 6�   $�*��6�   6�   �� 5   
   -   5        	 ��Name$	 btnSave��5      $��Сохранить��6"   $
��Left=�66   $��
10,209,0,0q�6Q   $	��Top=�6e   $	��108��6}   6�   �� 5   
   -   5        $	 	btnCancel��5      $��Отменить��6$   $
��Left=�67   $��
25,209,0,0q�6R   $	��Top=�6f   $	��103��6~   $��1��6�   �� 5   
   -	   5        $ 
textBlock3��5      $
��Left=�6(   $��
23,164,0,0q�6C   $
��Wrap=�6W   $	��Top=�6k   $��2��6�   �� 6�   $9�3обязательные поля помечены ��6�   �� 6�   $�*��6�   6�   5      5      