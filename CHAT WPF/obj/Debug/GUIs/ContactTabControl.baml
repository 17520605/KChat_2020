   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5      %    CHAT_WPF.GUIs.ContactTabControl   5      %localclr-namespace:CHAT_WPF.GUIs  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��600��5	      $
��1000��6     � 	Resources  5         show_list_yourfriend �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value  show_list_search_friend  	Load_list��%�  &	        &	 �     &	 '    �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ list_friend��6_   ..�5      i� $ 0��6)   # Z 65   5      5      �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ 
list_seach��6_   ..�5      i� $ 0��6)   # Z 65   5      5      �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ list_friend��6_   ..�5      i� $ 0��6)   # Z 65   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ 	open_btn2��66   .[�5      �� -   5        	 ��Name$-	 'show_list_search_friend_BeginStoryboard��5      #��[ 6O   �� 5      
 �� BeginStoryboardName$*
 $show_list_yourfriend_BeginStoryboard��6   �� 5       $ 
 Load_list_BeginStoryboard1��6   5!      :� 5"   
   $ ButtonBase.Click��6   $ 	open_btn1��66   .[�5#      �� -   5        $*	 $show_list_yourfriend_BeginStoryboard��5#      #��[  6L   �� 5$      $-
 'show_list_search_friend_BeginStoryboard��6   �� 5%      $ 
 Load_list_BeginStoryboard1��6   5&      :� 5'   
   $ FrameworkElement.Loaded��6   .[�5(      �� -   5        $ 	 Load_list_BeginStoryboard1��5(      #��[ 6B   �� 5)      $*
 $show_list_yourfriend_BeginStoryboard��6   �� 5*      $-
 'show_list_search_friend_BeginStoryboard��6   5+      .��5-      � -   5         � ColumnDefinitions 5.   
   �� 5/      $	��270 �6   �� 50      $	��730 �6   .+�52   
   �� -   5         ��Name$ MessagePanel��52      $��0��6+   ���#FFFFFF.+�53      �  � RowDefinitions 54      �� 55      $
��auto �6$   64   �� 56      $��* �6$   61   .+�58      � -   5         �Name$ 
button_all��58      $��0��6+   $��50��68    59      �� 5:      $��* �6+   �� 5;      $��* �6+   �� 5<      $��* �6+   .+�5>      �� -   5         ��Name$ 	open_btn1��5>      $��50��60     MaterialDesignFlatButton#��[ 6<   $��0��6n   .��5?      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��62   $��25��6=      Kind$ 
UserSearch=�6I   5@      �� 5A      -   5        $ 	open_btn2��5A      $��50��60   #��[ 6<   $��1��6o   .��5B        $��25��62   $��25��6=   $ GroupAdd=�6I     PrimaryHueDarkBrush#��[ 6Y   5C      �� 5D      -	   5        $ 	open_btn3��5D      $��50��60   #��[ 6<   $��2��6n   .��5E        $��25��62   $��25��6=   $ ViewDashboard=�6I   #��[ 6^   5F      5G      � 5H      -
   5        $ list_friend��5H      $��1��6,   $y�Hidden=�69    5I      �� 5J      $
��auto �6(   68   �� 5K      $��* �6(   65   .+�5M      � -   5        $ seach_your_friend��5M      $��0��66    5N      �� 5O      $��* �6,   69   �� 5P      $��* �6,   69   �� 5Q      $��* �6,   69   .+�5S      �� $��0��6%   .+�5T      �� #��[ 6(   5U      �� 5V      -   5         ��Name$ FriendSearchText��5V   "   $��1��6[   $
��10 5q�6h    % !MaterialDesignFloatingHintTextBox#��[ 6v   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Tìm kiếm bạn bè của bạn��6�   #��[ 6�   5W      � 5X      $��1��6   .+�5Y      �� $��Hidden=�6'   .��5Z      �� -   5        $ FriendsContainer��5Z   )   6E   5[      5\      5]      � 5^      -   5        $ 
list_seach��5^      $��1��6+   $y�Hidden=�68    5_      �� 5`      $
��auto �6(   68   �� 5a      $��* �6(   65   .+�5c      � -   5        $ seach_friend��5c      $��0��61    5d      �� 5e      $��* �6,   69   �� 5f      $��* �6,   69   �� 5g      $��* �6,   69   .+�5i      �� $��0��6%   .+�5j      �� #��[ 6(   5k      �� 5l      -   5        $ SuggestSearchText��5l   "   $��1��6]   $
��10 5q�6j   #��[ 6x   $? 9Nhập số điện thoại hoặc tên để tìm kiếm��6�   #��[ 6�   5m      � 5n      $��1��6   .+�5o      �� $��Hidden=�6'   .��5p      �� -   5        $ SuggestedUsersContainer��5p   )   6L   5q      5r      5t      5u      �� 5v      -   5        $ ConversationListBox��5v      68   5w      � 5x   
   -   5        $" InformationPersonalContainer��5x      $��1��6   5z      � 5{   
   -   5        $' !InformationPersonalImageContainer��5{      $��1��6   .+�5|         CHAT_WPF.GUIs.SlideKchat  6!   5}      5~      5      