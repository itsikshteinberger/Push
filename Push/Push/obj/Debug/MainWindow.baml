   M S B A M L   `   `   `  ����?  ;Push, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PushPush  5   	       Push.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Push     5   	   -   5          � Title$  
MainWindow��5   	    � WindowState$ 	Maximized=�6    � WindowStyle$
 None=�5	      $	��751��6   $
��1356��6(    � 	Resources 5
      ��%    5      .��5      � .+�5   
   �� -   5         ��Name$
 back��5   8   $��Images/blue.jpg��6   $
��Fill=�6)   6H   '� 5   
   -   5        $��MainViewport3D��5       '� Camera 5      =� 5      -   5        cam�� =� FieldOfView$ 40Q�5   1    � NearPlaneDistance$
 0.13Q�6B    � FarPlaneDistance$ InfinityQ�6[   	 � Position$	 0.39,2.1,-18.341�6x   
 � LookDirection$
 -0.02,-0.16,0.995�6�    � UpDirection$ 0,0.99,0.165�6�    �� 	Transform 5      �� 5       �� CenterX$ 0Q�6,    �� CenterY$ 0Q�68    �� CenterZ$ 0Q�6D    �� Rotation 5      �� 5   "    �� Axis$ 0,1,05�66    �� Angle$ 0Q�6C   -   5        ro1��5   M   5      5      .x�5      g�  g� Content 5      h� 5       .��5!      h� -   5        LevelsGroup��5!   '   5"      5$      g� 5(       5)      t� 5*       t� 	Direction$ -0.99,-0.16,-0.045�6'    �� Color$ White��6E   5,      g� 5-       5.      t� 5/      $ 0.0,0.0,1.05�6'   $ White��6?   51      g� 52       53      t� 54      $ -1.0,-0.1,0.05�6'   $ White��6A   56      g� 57       58      t� 59      $ -0.1,0.0,-1.05�6'   $ White��6A   5;      g� 5<       5=      t� 5>      $ 1.0,-0.2,0.05�6'   $ White��6@   5@      5A      �� 5B   
   $,��&Select your level and than click Enter��6   $	��100��6B   $��469,611,-1030,-168q�6O   $��25(�6k   $
��Bold"�6y   $��Aharoni)�6�   ��5C      �� 5D       �� Opacity$ 1Q�6"    �� Color$ White��6.   -   5        Instruction��5D   <   5F      �� 5G   
   -   5         ��Name$ x��5G      $
��Left=�6   $��1292,-15,-220,0q�6:   $
��Wrap=�6S   $��X��6g   $	��Top=�6p   $	��100(�6�   $��64��6�   $	��117��6�    J� RenderTransformOrigin$ 0.677,2.396&�6�   ��5H      �� 5I       �� ImageSource$ Images/wall.jpg��6    J� Effect 5K      3  -System.Windows.Media.Effects.DropShadowEffect  5L         
BlurRadius$ 15Q�6#      Opacity$ 1Q�63   -	   5        Xshadow��5L   ?   5N      �� 5O   
   -
   5        $ o��5O      $
��Left=�6   $��1228,-15,-156,0q�6j   $
��Wrap=�6�   $��?��6�   $	��Top=�6�   $	��100(�6�   $��64��6�   $	��117��6�   ��6:   �� *
Foreground+ �� ElementName$ x�� 5Q        5R      $ 15Q�6#   $ 1Q�63   -   5        oshadow��5R   ?   5T      �� 5U   	   -   5        $ back1��5U      $
��Fill=�6   $��Images/backroundopen.jpg��6-   6R   �� 5V   
   -   5        $
 play��5V   +    �� TextAlignment$ Center=�6   $
��play��69   $
��Left=�6E   $��205,222,0,0q�6`   $	��Top=�6u   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�   ��5W      �� 5X        �� EndPoint$  0.5,1&�6&   ! �� 
StartPoint$! 0.5,0&�67   .��5Y      � " � Color$" 	LightGray��6#   # � Offset$# 0Q�65   � 5Z      $	" Red��6#   $# 1Q�6/   5[       5]        5^      6&   5`      �� 5a   
   -   5        $ about��5a   �   $ Center=�6   $��about��6�   $
��Left=�6�   $��185,310,0,0q�6�   $	��Top=�6�   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�    6+   �� *Effect+$
 play����6W   �� *
Foreground+$
 play��6.  �� 5b   
   -   5        $ instructions��5b   �   $ Center=�6   $��instructions��6�   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�   $
��Left=�6�   $��110,393,0,0q�6
  $	��Top=�6   6+   �� *Effect+$
 play����6W   �� *
Foreground+$
 play��6  �� 5c   
   -   5        $
 exit��5c   +   $ Center=�6   $
��exit��6�   $
��Left=�6�   $��211,476,0,0q�6�   $	��Top=�6�   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�    69   �� *Effect+$
 play����6e   �� *
Foreground+$
 play��6�   �� 5f   	   -   5        $ ��Name$$ button��5f      $��Button��6    $��75��61   $y�Hidden=�6<   �� 5h   
   -   5        $ leftdoor��5h      $��Images/left.jpg��6"   $��-1585,0,1191,0q�6;   $
��Fill=�6S   $
��1000��6b   �� 5i   
   -   5        $ 	rightdoor��5i      $��Images/right.jpg��6#   $��1292,0,-1686,0q�6=   $
��Fill=�6U   $
��1000��6e   �� 5j   
   -   5        % ��Name$
% dark��5j   0   
���   �& J� Opacity$& 0Q�6$   5l      5n      5o      