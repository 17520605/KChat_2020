   M S B A M L   `   `   `  ����C  ?CHAT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CHAT_WPF.GUIsCHAT_WPF.GUIs  5   	   &     CHAT_WPF.GUIs.CreateNewGroupChat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CHAT_WPF.GUIs     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��450��6   $	��350��6$    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � Icon$. (/CHAT WPF;component/Asset/messenger3.png��5   	   ���	#FF2395EF$	��0.5q�5   !   $��Segoe UI Emoji)�5   	   .��5      � -   5         � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��2* �6   6*   �� 5      $
��auto �6   6,   .+�5   
   � -   5        $��0��5      ���	#FF2395EF � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $
��auto �6#   62   .+�5      �� $��0��6   
�������$��Create group��6;   $
��16px(�6O   $
��20 0q�6_   $��Center=�6m   6�   �� 5      -   5         ��Name$ close_btn_creategroup��5      $��1��6X   $��Center=�6h   $��Right=�6�      MaterialDesignFlatButton#��[  6�   $��59��6�   .��5       '  !MaterialDesignThemes.Wpf.PackIcon  $��25��6*   $��25��65   
�������   Kind$ Close=�6T   5!      5"      � 5#   
   $��1��6   $�� 0 10q�6    5$      �� 5%      $
��auto �6#   62   �� 5&      $��* �6#   6/   .+�5(      � $��0��6   $��20 0 0 0q�6$   .+�5)      �� $��Group Name :��6   $��16(�60   $
��Left=�6>   $��Center=�6Y   $��UTM Seagull)�6t   5*      � 5+      $��1��6   $	��180��6#   .+�5,      �� -   5        	 ��Name$	 	GroupName��5,      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Enter group name��6-   $��16(�6_   $��Center=�6m   $��	0,0,0,0.2q�6�   $
��Bold"�6�   5-      5.      � 5/   
   $��2��6   $
��20 0q�6!   .+�50      �� -   5        $	 SearchTextBox��50      $��5 0 0 0q�6P   $*
 $Search friend by name or phonenumber��6b   $��Center=�6�   $	��310��6�   $
��Bold"�6�   51      � 52   
   -   5        $��InvitedUsersContainer��52      $��3��61   $
��20 0q�6>   54      � 55   
   $��4��6   $��0 10 0 0q�6   .+�56      �� $��Hidden=�6   .��57      �� -   5         ��Name$ SearchResultsContainer��57      $��4��6=    �� Orientation$ Vertical=�6J   $	��Top=�6a   6{   58      59      � 5:   
   $��5��6   .+�5;      � $��5q�6    5<      �� 5=      $��* �6'   �� 5>      $��* �6'   �� 5?      $
��auto �6'   .+�5A      �� -   5        #��[  5A   ;   
�������$��1��6   $��12(�6�   .��6�   CANCEL6�   �� 5B      -	   5        $ CreateButton��5B      
�������$��12(�6e   $��2��6t   ��6�   Z� .��6�   CREATE GROUP6�   '   !CHAT_WPF.GUIs.SmallLoadingControl  5C      -
   5          Name$ CreateLoading��5C   ,   $y�	Collapsed=�6C   6\   5D      5E      5F      5G      