   M S B A M L   `   `   `  ����  Memory Note    Memory_Note.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Memory Note��5	   	   $	��450��6   $	��400��6+    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      5        5   
   -   5        $
 Open��5      5        5   
   -   5        $
 Save��5      5      .��5      � .+�5   
   o� $	��Top=�6   
�������.@�5      m� $
��File��6   .@�5      m� $
��_New��6    m� Command$	 New��6)   m� 5      -   5         m�Name$ openMenuItem��5      $��_Open��61   $
 Open��6@    m� Icon 5      �� 5      $��/assets/default/open.png��6    5      �� 5      m� 5      -   5        $ saveMenuItem��5      $��_Save��61   $
 Save��6@    5      �� 5      $��/assets/default/save.png��6    5       �� 5!      m� 5"      -   5        $��_Exit��5"      6*   5#      m� 5$      $
��Edit��6   .@�5%      m� $��_Undo��6   $
 Undo��6*   m� 5&      $��_Redo��6   $
 Redo��6*   �� 5'      m� 5(      -   5        $ cutMenutItem��5(      $
��_Cut��61   $	 Cut��6?    5)      �� 5*      $��/assets/default/cut.png��6    5,      m� 5-      -	   5        $ copyMenuItem��5-      $��_Copy��61   $
 Copy��6@    5.      �� 5/      $��/assets/default/copy.png��6    51      m� 52      -
   5        $ pasteMenuItem��52      $��_Paste��62   $ Paste��6B    53      �� 54      $��/assets/default/paste.png��6    56      57      m� 58      $��Tools��6   .@�59      m� -   5        $ encryptMenuItem��59      $��Encrypt text file��64    5:      �� 5;      $!��/assets/default/encrypt.png��6    5=      m� 5>      -   5        $ decrptMenuItem��5>      $��Decrypt text file��63    5?      �� 5@      $!��/assets/default/decrypt.png��6    5B      5C      m� 5D      $��Window��6   .@�5E      m� -   5        $��	Dark mode��5E       m� IsCheckable . 6\   m� 5F      -   5        $��Spell check��5F       . 6`   m� 5G      -   5        $��Font...��5G      6,   5H      5I      �� 5J   
   -   5         ��Name$ noteTextBox��5J      	 �� 
AcceptsTab	 . 
 �� AcceptsReturn
 . $��Stretch=�6N   $
��auto��6l    �� TextWrapping$
 Wrap=�6z   $�� ��6�   $��0,18,0,0q�6�   $��24(�6�   5K      5L      