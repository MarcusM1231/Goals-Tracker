   M S B A M L   `   `   `  ????F  BGoalTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoalTracker.PagesGoalTracker.Pages  5           GoalTracker.Pages.HomePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:GoalTracker.Pages     5        N? 
Background
  ????? N? Title$ HomePage??5
       ? 	Resources 5         	FontColor ?? Property ?? Value??%J   &	        ?? 5   
   .?5      ??  ? ??
 ?   ?63   5      5      .??5      ? .+?5   
   ?? #??[  6   $
??Left=?63   $??0,0,0,0q?6N   $??26??6_   $	??Top=?6k   .??6?   	Home Page6?   ?? 5   
   #??[  6   $	??Top=?63   $
??Left=?6K   $??0,44,0,0q?6f   .??6x   Total Points:6?   ?? 5   
   -   5         ??Name$ totalPoints??5   3   #??[  6   $	??Top=?6H   $
??Left=?6`   $??	73,44,0,0q?6{   .??6?   06?   ?? 5   
   #??[  6   $	??Top=?63   $
??Left=?6K   $??0,88,0,0q?6f   .??6x   Total Goals Completed:6?   ?? 5   
   -   5        $ totalCompleted??5   3   #??[  6   $	??Top=?6K   $
??Left=?6c   $??
132,88,0,0q?6~   .??6?   06?   ?? 5    
   $??	0,160,0,0q?6   $??20(?6#   $??42??61   $	??Top=?6=   $
??Left=?6U   $	??341??6p   .??6|   Recent Goals Completed:6?   ? 5!   
   -   5         ?Name$ RecentGoals??5!      $??50,207,-47,61q?6)    5"       ?? 
TargetType??%U   '??       ?? 5#      " ??6   .?5$      ??  ? ??$ 10,10q?6/   5&      5'      5(      ?? 5*   
   -   5         ??Name$ ResetButton??5*      $??
682,33,0,0q?6@   $
??Left=?6T   $??69??6o   $??39??6z   $	??Top=?6?   .??6?   Reset6?   56      57      