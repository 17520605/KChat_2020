   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5      +    %CHAT_WPF.GUIs.ConversationItemControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CHAT_WPF.GUIs     5      .��5      � -   5          �Name$  ConversationItem��5   s   $��Center=�6J   $��50��6g    � ContextMenu 5	   
   �� 5
      ���	#CD252220 J� Opacity$
 0.95Q�61   
�������
�������.@�5      m� $��Delete Conversation��6    m� Icon 5      �� 5      $/��)/CHAT WPF;component/Asset/delete_50px.png��6    $��15��6S   $��15��6^   5      5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��170 �6   �� 5      $
��auto �6   .+�5   
   �� $��40��6   $��40��6   $��	10 0 10 0q�6(    �� CornerRadius$ 25��6;   ���	#FFB0B0B0$	��0.6q�6e   ��5      �� 5      -   5        ConversationAvatar�� �� ImageSource$- '/CHAT WPF;component/Asset/loadf (1).gif��5   9   5      �� 5   
   -   5         ��Name$ ConversationOnlineStatus��5      $��10��63   $��10��6>   $��Bottom=�6J   $��0,0,11,5q�6e   $��Right=�6w   $ 15��6�   ���#00CC006�   �� 5   
   $��1��6   .+�5       �� -   5         ��Name$ ConversationTitle��5       $��Khai Nguyễn��63   $��15(�6F   $��Medium"�6T   
���   �$��10 5 0 0q�6|   �� 5!      -   5        $ ConversationLastMessage��5!      $$��Không có tin nhắn mới...��69   $
��10 2q�6Y   
���   �$��CharacterEllipsis=�6z   $	 0.6Q�6�   $��11(�6�   5"      �� 5$   
   -   5        $* $ConversationUnReadMessageCountBorder��5$      $��2��6?   $��25��6O   $��25��6Z   $ 15��6f      PrimaryHueDarkBrush#��[  6x   $��Center=�6�   $��Center=�6�   $��5q�6�   ._�5%      �� -   5        $$ ConversationUnReadMessageCount��5%      $��11(�6@   $��5��6N   
�������$��Center=�6j   $��Center=�6�   5&      5'      5(      