   M S B A M L   `   `   `  ����F  BGoalTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GoalTrackerGoalTracker  5   	       GoalTracker.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GoalTracker     5   	   -   5          � 
ResizeMode$  CanMinimize=�5   	   
����� � � Title$ Goals Tracker��5
   	   $	��450��6   $	��800��6,   .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $
��207* �6   .+�5   
   �� -   5         ��Name$ 
HomeButton��5      $��45,5,0,0q�6>   $��2��6P   $��30��6a   $	��Top=�6m   $
��Left=�6�   $	��100��6�   .��6�   Home6�   �� 5   
   -   5        $ DailyButton��5      $��30��6A   $	��100��6M   $	��Top=�6Y   $
��Left=�6q   $��	249,5,0,0q�6�   $��2��6�   .��6�   Daily6�   �� 5   
   -   5        $ EventButton��5      $��30��6A   $	��100��6M   $	��Top=�6Y   $
��Left=�6q   $��	466,5,0,0q�6�   $��2��6�   .��6�   Weekly6�   �� 5   
   -   5        $ LongtermButton��5      $��30��6I   $	��Top=�6U   $��	655,5,0,0q�6m   $
��Left=�6�   $	��100��6�   $��2��6�   .��6�   	Long-term6�    � 5   
   -   5          �Name$ CurrentPage��5        � Source$ /Pages/HomePage.xaml?�6%     � NavigationUIVisibility$ Hidden=�6\   $��	3,30,3,10q�6}   $��1��6�   6�   5      5      