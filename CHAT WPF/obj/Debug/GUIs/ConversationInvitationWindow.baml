   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5   	   0    *CHAT_WPF.GUIs.ConversationInvitationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CHAT_WPF.GUIs     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��450��6   $	��320��6$   ���	#FF2395EF$	��0.5q�5
   !    � 
ResizeMode$ NoResize=�5   	    � Icon$. (/CHAT WPF;component/Asset/messenger3.png��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	    � 	Resources 5       	  addmb �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value
 R� KeyTime  System.Windows.Visibility   Visible R� Value   Hidden  mb��%?  &	        &	 )    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ Member��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.4��6'   $		 330Q�69   5      T� 5      $ (UIElement.Visibility)�6,   $ Member��6_   ..�5      i� $
 0��6)   # Z 65   i� 5      $
 0:0:0.4��6)   # Z 6;   5      T� 5      $ (UIElement.Visibility)�6,   $ 	AddMember��6_   ..�5      i� $
 0��6)   # Z 65   i� 5      $
 0:0:0.2��6)   # Z 6;   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	AddMember��6�   .\�5        $ 0:0:0.2��6'   $
	 -330Q�69     5       $ 0:0:0.6��6'   $	 0Q�69   5!      5"      �� 5#   
   .��5$      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	AddMember��6�   .\�5%        $ 0��6'   $	 0Q�63     5&      $ 0:0:0.4��6'   $
	 -330Q�69   5'      T� 5(      $ (UIElement.Visibility)�6,   $ 	AddMember��6_   ..�5)      i� $
 0��6)   # Z 65   i� 5*      $
 0:0:0.4��6)   # Z 6;   5+      T� 5,      $ (UIElement.Visibility)�6,   $ Member��6_   ..�5-      i� $
 0:0:0.2��6)   # Z 6;   5.      U� 5/      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ Member��6�   .\�50        $ 0:0:0.2��6'   $		 330Q�69     51      $ 0:0:0.6��6'   $	 0Q�69   52      53      54       � Triggers 55      :� 56   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ 	open_btn1��66   .[�57      �� -   5         ��Name$ addmb_BeginStoryboard1��57      #��[  6>   �� 58       �� BeginStoryboardName$ addmb_BeginStoryboard2��6   59      :� 5:   
   $ ButtonBase.Click��6   $ 	open_btn2��66   .[�5;      �� $ addmb_BeginStoryboard1��6   �� 5<      -   5        $ addmb_BeginStoryboard2��5<      #��[ 6>   5=      .��5?      � -   5        .+�5@   
   � .+�5A      �  � RowDefinitions 5B      �� 5C      $
��auto �6$   64   �� 5D      $
��auto �6$   64   �� 5E      $��* �6$   61   .+�5G      � -   5        $��0��5G      ���	#FF2395EF � ColumnDefinitions 5H      �� 5I      $��* �6+   67   �� 5J      $
��auto �6+   6:   .+�5L      �� $��0��6    $��Invite Friend to group��60   
�������$
��16px(�6a   $
��20 0q�6q   $��Center=�6   6�   �� 5M      -   5         ��Name$ close_btn_invite_friend��5M      $��1��6>   $��Center=�6N   $��Right=�6i     MaterialDesignFlatButton#��[ 6�   $��59��6�   .��5N      '  !MaterialDesignThemes.Wpf.PackIcon  $��25��62   $��25��6=   
�������   Kind$ Close=�6\   5O      5P      � 5Q      -   5         �Name$ 
button_all��5Q      $��1��6+   $��35��68   $��5q�6D   $	��Top=�6O    5R      �� 5S      $��* �6+   �� 5T      $��* �6+   .+�5V      �� -   5        $ 	open_btn1��5V      $��30��60   #��[ 6<   $��0��6n   .��5W        $��25��62   $��25��6=   $ GroupAdd=�6I   5X      �� 5Y      -   5        $ 	open_btn2��5Y      $��30��60   #��[ 6<   $��1��6o   .��5Z        $��25��62   $��25��6=   $
 User=�6I     PrimaryHueDarkBrush#��[ 6U   5[      5\      � 5]      $��2��6   .+�5^      � -	   5        $ 	AddMember��5^       J� RenderTransformOrigin$ 0.5,0.5&�6.   z�5_      V� 5`      .~�5a   "   �� �� 5b   "   �� 5c   "   T� 5d   "   5e       5g      �� 5h      $
��auto �6,   6<   �� 5i      $
��auto �6,   6<   �� 5j      $
��auto �6,   6<   �� 5k      $��* �6,   69   .+�5m      � $��0��6   .+�5n      �� $.��(Invite friend to this group conversation��6(   $��Center=�6X   $��20 10q�6s   
���   �$��10(�6�   6�   5o      � 5p      -
   5        $��InvitedUsersContainer��5p   $   $��1��6A   $��20 0 0 0q�6N   5r      � 5s      $��2��6$   $��20 0 0 0q�61   .+�5t      �� -   5         ��Name$ SearchTextBox��5t   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$* $Search friend by name or phonenumber��6`   $��12(�6�   $
��Left=�6�   $��Center=�6�   $	��280��6�   5u      � 5v      $��3��6   .+�5w      �� $��Hidden=�6+   .��5x   "   �� -   5         ��Name$ SearchResultsContainer��5x   -   6O   5y      5z      � 5{      -   5        $ Loading��5{   -   $��4��6   .+�5|      %   CHAT_WPF.GUIs.BigLoadingControl  68   5}      5~      � 5      -   5        $ Member��5      $ 0.5,0.5&�6+   $y�Hidden=�6K   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "    T� X$	 330Q�65   5�       5�      �� 5�      $
��auto �6,   6<   �� 5�      $��* �6,   69   .+�5�      � $��0��6   .+�5�      �� $��Member of group��6(   $��Center=�6?   $��20 10q�6Z   
���   �$��10(�6|   6�   5�      � 5�      $��1��6   .+�5�      �� $��Hidden=�6+   .��5�   "   �� 60   5�      5�      � 5�      $��1��6   .+�5�        68   5�      5�      5�      5�      5�      5�      5�      