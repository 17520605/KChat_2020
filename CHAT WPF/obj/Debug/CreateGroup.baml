   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CHAT_WPFCHAT_WPF  5   	       CHAT_WPF.CreateGroup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CHAT_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Icon$  Asset/messenger3.png��5   	    � Title$ Login��5
   	   $	��500��6   $	��420��6$    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��2* �6   6*   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   ���	#FFD7D7D7 � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $
��auto �6#   62   .+�5      �� $��0��6   $��Create group��6(   $
��16px(�6<   $
��20 0q�6L   $��Center=�6Z   6w   �� 5      -   5         ��Name$ close_btn_creategroup��5      $��1��64   $��Center=�6D   $��Right=�6_      MaterialDesignFlatButton#��[  6|   $��59��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6*   $��25��65     PrimaryHueDarkBrush#��[ 6A      Kind$ Close=�6s   5       5!      � 5"   
   $��1��6    5#      �� 5$      $
��auto �6#   62   �� 5%      $��* �6#   6/   .+�5'      � $��0��6   $��20 0 0 0q�6$   .+�5(      �� $��Group Name :��6   $��16(�60   $
��Left=�6>   $��Center=�6Y   5)      � 5*      $��1��6   $	��230��6#   .+�5+      �� )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Enter group name��6   $��16(�6L   $��Center=�6Z   $��	0,0,0,0.2q�6u   5,      5-      � 5.   
   $��2��6   .+�5/      �� $.��(Invite friend to this group conversation��6   $��Center=�6H   $��20 10q�6c   
���   �$��10(�6�   6�   50      � 51   
   $��3��6   $
��20 0q�6   .+�52      �� $*	 $Search friend by name or phonenumber��6   $��15(�6\   $
��Left=�6j   $��Center=�6�   $��	0,0,0,0.2q�6�   $	��380��6�   53      � 54   
   $��4��6   $
��0 10q�6   .+�55         CHAT_WPF.AddFriendGroup  56      � 57   
   $��5��6   .+�58      � $��10q�6    59      �� 5:      $��* �6'   �� 5;      $��* �6'   �� 5<      $��* �6'   .+�5>      �� #��[  6   
�������$��1��6]   .��6m   CANCEL5@      �� 5A      #��[  6   $��2��6L   .��6\   CREATE GROUP5C      5D      5E      5F      5G      