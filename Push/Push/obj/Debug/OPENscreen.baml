   M S B A M L   `   `   `  ����?  ;Push, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PushPush  5   	       Push.OPENscreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Push     5   	   -   5          � WindowState$  	Maximized=�5   
    � WindowStyle$
 None=�5	       � Title$ 
OPENscreen��5
   	   $	��751��6   $
��1356��6)   .��5      � .+�5   
   �� $
��Fill=�6   $��Images/backround.jpg��6   6?   �� 5   
   -   5         ��Name$
 play��5   +    �� TextAlignment$ Center=�6   $
��play��69   $y�Hidden=�6E   $
��Left=�6Y   $��205,222,0,0q�6t   $	��Top=�6�   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	LightGray��6#    � Offset$ 0Q�65   � 5      $	 Red��6#   $ 1Q�6/   5      	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      6&   5      �� 5   
   -   5        $ about��5   �   $ Center=�6   $y�Hidden=�6+   $��about��6�   $
��Left=�6�   $��185,310,0,0q�6�   $	��Top=�6�   $��76(�6  $$��Tw Cen MT Condensed Extra Bold)�6-  	 6?   �� *Effect+
 �� ElementName$

 play����6k   �� *
Foreground+$

 play��6�  �� 5   
   -   5        $ instructions��5   �   $ Center=�6   $y�Hidden=�6+   $��instructions��6�   $��76(�6�   $$��Tw Cen MT Condensed Extra Bold)�6�   $
��Left=�6  $��110,393,0,0q�6  $	��Top=�63  	 6?   �� *Effect+$

 play����6k   �� *
Foreground+$

 play��6�  �� 5   
   -   5        $
 exit��5   ?   $ Center=�6   $y�Hidden=�6+   $
��exit��6�   $
��Left=�6�   $��211,476,0,0q�6�   $	��Top=�6�   $��76(�6  $$��Tw Cen MT Condensed Extra Bold)�6*  	 6M   �� *Effect+$

 play����6y   �� *
Foreground+$

 play��6v  �� 5   
   -   5        $
 push��5      $
��PUSH��6"   $
��Left=�6.   $��	79,82,0,0q�6I   $	��Top=�6\   $	��112(�6t   $��Gill Sans Ultra Bold)�6�   	 5        5         
BlurRadius$ 9Q�6#   64   ��5      �� 5        �� ImageSource$ Images/redbackround.jpg��6   5"      �� 5#   
   -   5         ��Name$ ticket4��5#      $
��Fill=�6!   $��Images/card4.jpg��6_    J� Opacity$ 1Q�6y   $��846,306,239,186q�6�   	 60   �� *Effect+$
 ticket2�� J� RenderTransformOrigin 6�   �� *RenderTransformOrigin+$
 ticket1��z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$ -7.401Q�6&   T� 5)      5*      5,      �� 5.   
   -   5        $ ticket2��5.      $
��Fill=�6!   $��Images/card2.jpg��60   $��933,72,144,414q�6J   $ 0.5,0.5&�6b   	 5/        50      $ 40Q�6#      ShadowDepth$ 20Q�63   z�52      V� 53      .~�54      �� �� 55      �� 56      $ 14.286Q�6&   T� 57      58      5:      �� 5;   
   $
��Fill=�6   $��Images/leafs.png��6   $��10,574,770,0q�69   6Q   �� 5=   
   -	   5        $ leftdoor��5=      $��Images/left.jpg��6"   $��-1585,0,1191,0q�6;   $
��Fill=�6S   $
��1000��6b   �� 5>   
   -
   5        $ 	rightdoor��5>      $��Images/right.jpg��6#   $��1292,0,-1686,0q�6=   $
��Fill=�6U   $
��1000��6e   5?      5@      