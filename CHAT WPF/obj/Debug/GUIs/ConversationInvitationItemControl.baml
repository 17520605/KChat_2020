   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5      5    /CHAT_WPF.GUIs.ConversationInvitationItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CHAT_WPF.GUIs     5      .��5      � -   5          �Name$  
InviteItem��5      .+�5	   
   �� .@�5
   
   �� $��Stretch=�6   ��65   Z� .��5      � $��Center=�6   $��5q�60    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $	��150 �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $	��5 0q�6-    �� Orientation$ 
Horizontal=�6:   $��Center=�6S   .+�5      �� $��40��6   $��40��6)    �� CornerRadius$ 25��65   
�������$	��0.6q�6[   ��5      �� 5      -   5        
Avatar�� �� ImageSource$- '/CHAT WPF;component/Asset/loadf (1).gif��5   9   ._�5      �� $��10��6!   $��10��6,   $��Bottom=�68   $��Right=�6T   $ 15��6p   ���#00CC00 J� RenderTransformOrigin$ 
-0.16,0.16&�6�   5      5      �� 5      $��1��6   $��5q�6-   $ 
Horizontal=�68   $��Center=�6Q   .+�5      �� -   5         ��Name$ FullName��5   $   $
��Wrap=�66   $��
Loading...��6J   $��15(�6\   ���	#FF1976D2$
��10 0q�6�   5      �� 5      -   5         ��Name$ InviteButton��5      $��2��6R   $��80��6b   $��25��6m   $��Center=�6y   $��Center=�6�   $��5q�6�   ���	#FF1976D2���	#FF1976D2��6�   Z� .��5      �� -   5        $ Contenstatus��5       $��11(�66   $��Invite��6D   
�������$��Center=�6e   $��Center=�6�   5      � 5      -   5        $  Loading��5   '   $��2��6   $y�	Collapsed=�68   $��Center=�6O   .+�5       '   !CHAT_WPF.GUIs.SmallLoadingControl  62   5!      5#      5$      5%      5&      5'      