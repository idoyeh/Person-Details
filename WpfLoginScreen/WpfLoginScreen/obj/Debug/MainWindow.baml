   M S B A M L   `   `   `  ����I  EWpfLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfLoginScreenWpfLoginScreen  5   	       WpfLoginScreen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfLoginScreen     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��840��6)   $��14(�65   ���#04c582 � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$g aC:\Users\Ido Yehezkel\Desktop\Sadna\another projects\c# Projects\WpfLoginScreen\DetailsPerson.ico��6.   .��5
      � $��RightToLeft=�6   .+�5   
   �� $��20q�6   .+�5      �� $��חיפוש משתמש��6   
�������$��25(�6=   $��Center=�6K   6j   �� 5       �� Orientation$ 
Horizontal=�6   $��0 20 0 0q�62   $��Center=�6D   .+�5      �� $
��שם��6   
�������$��Right=�68   $��18(�6T   $��0 0 10 0q�6b   6w   �� 5      -   5        $��txtName��5      $	��200��6)   ���#545d6a
�������$��18(�6]   $��0 0 80 0q�6k   6   �� 5      $��תעודת זהות��6   
�������$��Center=�6@   $��18(�6]   $��0 0 10 0q�6k   6�   �� 5      -   5        $��txtID��5      $	��200��6'   ���#545d6a
�������$��18(�6[   $��0 0 40 0q�6i   6}   �� 5      -   5        $��	btnSearch��5      $��חפש��6B   
���  ��
�������$��18(�6t   $
��10 0q�6�   $��Center=�6�   6�   5      &   System.Windows.Controls.DataGrid  5      -   5        $��displayDetails��5         AutoGenerateColumns .  $��10q�6I   $��20q�6V   $	��740��6b   $	��260��6n   
�������$��Center=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ מזהה משתמש��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *UserID+6D     5      $ שם פרטי��6G    6)   �� *	FirstName+6G     5      $ שם משפחה��6F    6)   �� *
LastName+6F     5      $ מספר טלפון��6I    6)   �� *PhoneNumber+6I     5      $ 
כתובת��6E    6)   �� *	Address+6E     5       $ מין��6D    6)   �� *Gender+6D     5!      $ הצגת פרטים��6)   5$      �� 5&      -   5        $	��btn��5&      $��30��6    $��30��6,   6K   5'      5)      5*      