   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CHAT_WPFCHAT_WPF  5          CHAT_WPF.ContactTab   5       localclr-namespace:CHAT_WPF  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��600��5	      $
��1000��6     � 	Resources  5
         show_list_yourfriend �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value  show_list_search_friend  	Load_list��%�  &	        &	 �     &	 '    �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ list_friend��6_   ..�5      i� $ 0��6)   # Z 65   5      5      �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ 
list_seach��6_   ..�5      i� $ 0��6)   # Z 65   5      5      �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ list_friend��6_   ..�5      i� $ 0��6)   # Z 65   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ 	open_btn2��66   .[�5      �� -   5        	 ��Name$-	 'show_list_search_friend_BeginStoryboard��5      #��[ 6O   �� 5      
 �� BeginStoryboardName$*
 $show_list_yourfriend_BeginStoryboard��6   �� 5      $ 
 Load_list_BeginStoryboard1��6   5       :� 5!   
   $ ButtonBase.Click��6   $ 	open_btn1��66   .[�5"      �� -   5        $*	 $show_list_yourfriend_BeginStoryboard��5"      #��[  6L   �� 5#      $-
 'show_list_search_friend_BeginStoryboard��6   �� 5$      $ 
 Load_list_BeginStoryboard1��6   5%      :� 5&   
   $ FrameworkElement.Loaded��6   .[�5'      �� -   5        $ 	 Load_list_BeginStoryboard1��5'      #��[ 6B   �� 5(      $*
 $show_list_yourfriend_BeginStoryboard��6   �� 5)      $-
 'show_list_search_friend_BeginStoryboard��6   5*      .��5,      �  � ColumnDefinitions 5-   
   �� 5.      $	��300 �6   �� 5/      $��* �6   .+�51   
   �� -   5         ��Name$ MessagePanel��51      $��0��6+   ���#FFFFFF.+�52      �  � RowDefinitions 53      �� 54      $
��auto �6$   64   �� 55      $��* �6$   61   .+�57      � -   5         �Name$ 
button_all��57      $��0��6+   $��50��68    58      �� 59      $��* �6+   �� 5:      $��* �6+   �� 5;      $��* �6+   .+�5=      �� -   5         ��Name$ 	open_btn1��5=      $��50��60     MaterialDesignFlatButton#��[ 6<   $��0��6n   .��5>      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��62   $��25��6=      Kind$ 
UserSearch=�6I   5?      �� 5@      -   5        $ 	open_btn2��5@      $��50��60   #��[ 6<   $��1��6o   .��5A        $��25��62   $��25��6=   $ GroupAdd=�6I     PrimaryHueDarkBrush#��[ 6Y   5B      �� 5C      -   5        $ 	open_btn3��5C      $��50��60   #��[ 6<   $��2��6n   .��5D        $��25��62   $��25��6=   $ ViewDashboard=�6I   #��[ 6^   5E      5F      � 5G      -	   5        $ list_friend��5G      $��1��6,   $y�Hidden=�69    5H      �� 5I      $
��auto �6(   68   �� 5J      $��* �6(   65   .+�5L      � -
   5        $ seach_your_friend��5L      $��0��66    5M      �� 5N      $��* �6,   69   �� 5O      $��* �6,   69   �� 5P      $��* �6,   69   .+�5R      �� $��0��6%   .+�5S      �� #��[ 6(   5T      �� 5U      $��1��6"   $
��10 5q�6/    % !MaterialDesignFloatingHintTextBox#��[ 6=   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Tìm kiếm bạn bè của bạn��6x   #��[ 6�   5V      �� 5W      -   5        $ usercontrol_your_friend��5W   !   $��1��6B   .+�5X      !   CHAT_WPF.ListContactControl  65     5Y      65     5Z      65     5[      65   5\      5]      � 5^      -   5        $ 
list_seach��5^      $��1��6+   $y�Hidden=�68    5_      �� 5`      $
��auto �6(   68   �� 5a      $��* �6(   65   .+�5c      � -   5        $ seach_friend��5c      $��0��61    5d      �� 5e      $��* �6,   69   �� 5f      $��* �6,   69   �� 5g      $��* �6,   69   .+�5i      �� $��0��6%   .+�5j      �� #��[ 6(   5k      �� 5l      $��1��6"   $
��10 5q�6/   #��[ 6=   $? 9Nhập số điện thoại hoặc tên để tìm kiếm��6x   #��[ 6�   5m      �� 5n      -   5        $ usercontrol_friend��5n   !   $��1��6=   .+�5o      #   CHAT_WPF.SuggestFriendControl  67     5p      67   5q      5r      5s      �� 5t      -   5        $ ConversationListBox��5t      68   5u      � 5v   
   $��1��6   ���	#FFE4E4E4.+�5w      �� $��Asset/Capture1.PNG��6   $
��None=�60   �� 5x      $��Make Friend��6   $��Center=�6+   $��282,129,282,0q�6H   $��25(�6_   #��[ 6m   6�   5z      5{      5|      