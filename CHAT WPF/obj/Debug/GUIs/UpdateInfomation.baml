   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5   	   $    CHAT_WPF.GUIs.UpdateInfomation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CHAT_WPF.GUIs     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��330��6$    � 
ResizeMode$ NoResize=�5
   	    � Icon$. (/CHAT WPF;component/Asset/messenger3.png��5   	   ���	#FF2395EF$	��0.5q�5   !    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      � -   5        .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $��* �6    6-   �� 5      $
��auto �6    60   �� 5      $��* �6    6-   �� 5      $
��auto �6    60   .+�5      � -   5        $��0��5      ���	#FF2395EF � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $
��auto �6'   66   .+�5      �� $��0��6   $��Update Info��6,   $
��16px(�6?   $
��20 0q�6O   
�������$��Center=�6p   6�   �� 5      -   5         ��Name$ close_btn_infoUpdate��5      $��1��6[   $��Center=�6k   $��Right=�6�      MaterialDesignFlatButton#��[  6�   $��59��6�   .��5       '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6.   $��25��69   
�������   Kind$ Close=�6X   5!      5"      � 5#      $��1��6   .+�5$      � -   5        .+�5%      �� -   5        	 ��Name$	 backgroundupade��5%      $
��auto��66   $	��160��6C   $	��Top=�6P   ��5&      �� 5'      
 �� ImageSource$2
 ,/CHAT WPF;component/Asset/background2021.jpg��6)   5)      �� 5*      -   5        $ iconchangebackground��5*      
������� * &MaterialDesignFloatingActionMiniButton#��[ 6�   $�� 290 80 0 0q�6�   ��6Z   Z� ��6p   Z� .��5+        $��Center=�63   $��Center=�6N   $ Camera=�6k   $��20��6y   $��20��6�   5,      5-      � 5.      -   5        .+�5/      �� -   5        $	 avatarupdate��5/      $	��100��64   $	��100��6@    �� CornerRadius$ 80��6M   $��1q�6_   
�������$��Center=�6�   $��Center=�6�   $��0 50 0 0q�6�   ��50      �� 51      -	   5        avatarchange��$*
 $/CHAT WPF;component/Asset/avatar.jpg��51   ?   53      �� 54      -
   5        $ iconchangeavatar��54      ���	#FF1C8EFF#��[ 6�   $��160,125,100,0q�6�   ��6V   Z� ��6l   Z� .��55        $��Center=�63   $��Center=�6N   $ Camera=�6k   $��25��6y   $��25��6�   56      57      � 58       59      �� 5:      $��* �6+   67   �� 5;      $
��auto �6+   6:   .+�5=      � $��0��6   .+�5>      �� -   5         ��Name$ Fullnamechange��5>   "   $��20(�6:   $��Center=�6H   $��Center=�6e   $��Nguyễn Hữu Minh Khai��6�   $��60,180,60.6,-5q�6�   6�   5?      5@      5B      � 5C      $��3��6   .+�5D      � $��10,20,10,10q�6    5E      �� 5F      $��* �6(   65   �� 5G      $��* �6(   65   �� 5H      $��* �6(   65   �� 5I      $��* �6(   65   .+�5K      � $��0��6    5L      �� 5M      $��* �6/   6;   �� 5N      $��4* �6/   6<   .+�5P      �� $��0��6$   $��Phone :��64   
���   �$��15(�6V   $��Center=�6d   6�   �� 5Q      -   5         ��Name$ phonechange��5Q   $   $��1��69   $
��15 0q�6I   $��09999999999��6W   
�������$��15(�6|   $��Center=�6�   6�   5R      � 5S      $��1��6    5T      �� 5U      $��* �6/   6;   �� 5V      $��4* �6/   6<   .+�5X      �� $��0��6$   $��Gender :��64   
���   �$��15(�6W   $��Center=�6e   6�   �� 5Y      -   5        $ genderchange��5Y   .   $	��230��6"   $��1��6D   $��	5 -10 0 0q�6T   
�������$
��Male��6z   $��15(�6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   5Z      � 5[      $��2��6    5\      �� 5]      $��* �6/   6;   �� 5^      $��4* �6/   6<   .+�5`      �� $��0��6$   $��Email :��64   
���   �$��15(�6V   $��Center=�6d   6�   �� 5a      -   5        $ Emailchange��5a   "   $	��230��67   $��1��6C   $��	5 -10 0 0q�6S   
�������$!��Nguyenhuuminhkhai@gmail.com��6y   $��15(�6�   #��[ 6�   5b      � 5c      $��3��6    5d      �� 5e      $��* �6/   6;   �� 5f      $��4* �6/   6<   .+�5h      �� $��0��6$   $��	Address :��64   
���   �$��15(�6X   $��Center=�6f   6�   �� 5i      -   5        $ Addresschange��5i   "   $	��230��69   $��1��6E   $��	5 -10 0 0q�6U   
�������$��
THUDUC-HCM��6{   $��15(�6�   #��[ 6�   5j      5k      5l      � 5m      $��4��6   .+�5n      � $��5q�6    5o      �� 5p      $��* �6+   �� 5q      $��* �6+   �� 5r      $��* �6+   .+�5t      �� #��[  6   $��0��6O   5v      �� 5w      -   5        $ close_btn_infoUpdate1��5w      #��[  6`   $��1��6�   $��14(�6�   
�������.��6�   CANCEL5y      �� 5z      -   5        #��[  5z   >   $��2��6p   $��14(�6�   .��6�   UPDATE5|      5}      5~      5      %   CHAT_WPF.GUIs.BigLoadingControl  5�   
   -   5          Name$ Loading��5�   "   65   5�      5�      