   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5      &     CHAT_WPF.GUIs.SentMessageControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      'localclr-namespace:CHAT_WPF.GUIs  5      "  WpfAnimatedGif.ImageBehavior    AnimateInDesignMode  . .��5
      � $��	5 5 20 20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � -   5         �Name$ MessageEmojiContainer��5      $��0��6   5      �� 5   
   $��1��6   $��0q�6   ���#E2E2EE$	��600��6>    �� CornerRadius$ 5��6M   ._�5      �  5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   .+�5      �� -   5         ��Name$ MessageImagesContainer��5      $��0��6=    �� Orientation$ Vertical=�6J   5      �� 5      -   5        $ MessageFilesContainer��5      $��1��6<   $ Vertical=�6I   5      �� 5       -   5         ��Name$ MessageTextContainer��5    &   $��2��6   $	��400��6D    � 	Resources 5!       �� 
TargetType	 �� Property
 �� Value��%H  '��       �� 5"      " ��6    .�5#      �� 	 � ��$
 15(�69   �� 5$      	 � ��$
 15 10q�67   �� 5%      	 � ��

 �   �6;   �� 5&      	 �@��
IsReadOnly
 . 6;   �� 5'      	 � ��

 ���� 6;   �� 5(      	 �@��TextWrapping$

 Wrap=�6=   �� 5)      	 � ��$
 0q�6@   5*      5+      5-      5.      5/      � 50   
   $��2��6   $��0 5 0 0q�6    � ColumnDefinitions 51      �� 52      $��* �6#   6/   �� 53      $
��auto �6#   62   .+�55      � $��0��6   $
��Left=�6#   $��20��6>   $
��auto��6J   6Y   � 56      $��1��6   $��Right=�6#   $��20��6?   .+�57      �� -   5         ��Name$ SendTime��57      $��	2 asdsads��6.   $y�	Collapsed=�6?   ���#727171$��Right=�6l   6�   '   !CHAT_WPF.GUIs.SmallLoadingControl  58      -   5          Name$ SentLoading��58   ,   6C   59      5:      5;      5<      