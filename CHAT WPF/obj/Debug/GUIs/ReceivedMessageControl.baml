   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5      *    $CHAT_WPF.GUIs.ReceivedMessageControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CHAT_WPF.GUIs     5      .��5      � -   5          � ColumnDefinitions  5	   
   �� 5
      $
��auto �6   6.   �� 5      $
��auto �6   6.   .+�5   
   � $��0��6   .+�5      �� $��40��6   $��40��6    $��20 5 5 5q�6,    �� CornerRadius$ 80��6>   $	��Top=�6P   $��1q�6h   ���	#FFDFDFDF��5      �� 5      -   5        
Avatar�� �� ImageSource$ /Asset/3.jpg��5   1   5      5      � 5   
   $��1��6   .+�5      � $��	5 5 20 10q�6    � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   .+�5      � -   5         �Name$ MessageEmojiContainer��5   $   $��0��6   5      �� 5      $��1��6   $��0q�6&   ���#FFFFFF$	��600��6F   $ 5��6U   ._�5      �  5       �� 5!      $
��auto �6,   6<   �� 5"      $
��auto �6,   6<   �� 5#      $
��auto �6,   6<   .+�5%      �� -   5         ��Name$ MessageImagesContainer��5%   %   $��0��6E    �� Orientation$ Vertical=�6R   5'      �� 5(      -   5        $ MessageFilesContainer��5(   %   $��1��6D   $ Vertical=�6Q   5*      �� 5+      -   5         ��Name$ MessageTextContainer��5+   .   $��2��6!   $	��400��6L    � 	Resources 5,      	 �� 
TargetType
 �� Property �� Value��%H  '��       �� 5-   "   "	 ��6(   .�5.   &   �� 
 � ��$ 15(�6A   �� 5/   &   
 � ��$ 15 10q�6?   �� 50   &   
 � ��
 �   �6C   �� 51   &   
 �@��
IsReadOnly . 6C   �� 52   &   
 � ��
 ���� 6C   �� 53   &   
 �@��TextWrapping$
 Wrap=�6E   �� 54   &   
 � ��$ 0q�6H   55   #   56      58      59      5:      � 5;      $��2��6   $��0 5 0 0q�6$     5<      �� 5=      $
��auto �6+   6:   �� 5>      $��* �6+   67   .+�5@      � $��0��6   $
��Left=�6+   $��20��6F   $
��auto��6R   .+�5A      �� -   5         ��Name$ SendTime��5A   p   $y�Hidden=�6$   $��Center=�68   $��Center=�6U   $��2012/110/11��6�   ���#727171$��2��6�   6�   5B      � 5C      $��1��6   $
��Left=�6+   $��20��6F   $
��auto��6R   6a   5D      5E      5F      5G      5H      