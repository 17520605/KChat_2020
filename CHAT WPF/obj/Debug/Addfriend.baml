   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CHAT_WPFCHAT_WPF  5   	       CHAT_WPF.Addfriend   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CHAT_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��2* �6   6*   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   ���	#FFD7D7D7 � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $
��auto �6#   62   .+�5      �� $��0��6   $��
Add friend��6(   $
��16px(�6:   $
��20 0q�6J   $��Center=�6X   6u   �� 5      -   5         ��Name$ close_btn_addFriend��5      $��1��62   $��Center=�6B   $��Right=�6]      MaterialDesignFlatButton#��[  6z   $��59��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6*   $��25��65     PrimaryHueDarkBrush#��[ 6A      Kind$ Close=�6s   5      5      � 5    
   $��1��6    5!      �� 5"      $
��auto �6#   62   �� 5#      $��* �6#   6/   .+�5%      � $��0��6   $��20 0 0 0q�6$    5&      �� 5'      $
��auto �6'   66   �� 5(      $��* �6'   63   .+�5*      � $��0��6   $��5q�6'   .+�5+        $ Phone=�6.   $��25��6;   $��25��6F    J� RenderTransformOrigin$ 0.4,1.16&�6R   $��0,3,0,-1q�6s   6�   5,      � 5-      $��1��6   $��5q�6'   .+�5.      �� $��(+84)��6    $��20(�6-   6=   5/      50      � 51      $��1��6   $	��180��6#   .+�52      �� )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Phone Number��6   $��20(�6H   $
��Left=�6V   $��Center=�6q   $	��180��6�   53      54      � 55   
   $��2��6    56      �� 57      $
��auto �6#   62   �� 58      $��* �6#   6/   .+�5:      � $��0��6   .+�5;        $��25��6*   $��25��65   
�������$��Center=�6S   $��10q�6n   $ At=�6z   6�   5<      � 5=      $��1��6   .+�5>      �� $��You may know��6   $��Center=�60   
�������$��20(�6]   6m   5?      5@      � 5A   
   $��3��6   .+�5B      #   CHAT_WPF.SuggestFriendControl  5C      � 5D   
   $��4��6   .+�5E      � $��10q�6    5F      �� 5G      $��* �6'   �� 5H      $��* �6'   �� 5I      $��* �6'   .+�5K      �� #��[  6   
�������$��1��6]   .��6m   CANCEL5M      �� 5N      #��[  6   $��2��6L   .��6\   SEARCH5P      5Q      5R      5S      5T      