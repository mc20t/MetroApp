   M S B A M L   `   `   `  ����C  ?MetroApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MetroApp.PagesMetroApp.Pages  5      $    MetroApp.Pages.StationStatPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MetroApp.Pages     5        N� Title$  Статистика��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��593* �6   .+�5   
   �� $0��*Статистика по станциям��6   $��40(�5      $��Center=�5      $��Center=�5      �� 5   
   -   5         ��Name$ btnExit��5      $��30,0,0,0q�5      $��
Назад��5      $
��Left=�5      $��Center=�5      $��60��5      $��30��5      $��18(�5      5      �� 5    
   $��1��6   .@�5!      �� $��Районы��6   .��5"      � ���	#FFE5E5E5.+�5#      �� .��5$      �� .+�5%      �� $��Районы��6(   $��Center=�5&   (   $��0 20 0 5q�5'   (   $��20(�5(   (   �� 5)      -   5         ��Name$ lvArea��5)   '   $��Disabled=�5+   '   $
��auto��5,   '    �� View 5-   "   �� 5.   &   .P�5/   *   �� $��
Район��69    �� Width$
 auto��50   -    �� DisplayMemberBinding 51   -   �� *Area+�� 52   *   $)��#Количество станций��69   $
 auto��53   -    54   -   �� *CountStations+�� 55   *   $��
Округ��69   $
 auto��56   -    57   -   �� *
District+�� 58   *   $��
Город��69   $
 auto��59   -    5:   -   �� *City+�� 5;   *   $��
Карта��69   $
 auto��5<   -    5=   -   �� *Map+5>   '   5@      �� 5B      $��Округи��6(   $��Center=�5C   (   $��0 20 0 5q�5D   (   $��20(�5E   (   �� 5F      -   5        $ 
lvDistrict��5F   '   $��Disabled=�5H   '   $
��auto��5I   '    5J   "   �� 5K   &   .P�5L   *   �� $��
Округ��69   $
 auto��5M   -    5N   -   �� *
District+�� 5O   *   $)��#Количество станций��69   $
 auto��5P   -    5Q   -   �� *CountStations+�� 5R   *   $)��#Количество районов��69   $
 auto��5S   -    5T   -   �� *
CountAreas+�� 5U   *   $��
Город��69   $
 auto��5V   -    5W   -   �� *City+�� 5X   *   $��
Карта��69   $
 auto��5Y   -    5Z   -   �� *Map+5[   '   5]      �� 5_      $��Города��6(   $��Center=�5`   (   $��0 20 0 5q�5a   (   $��20(�5b   (   �� 5c      -   5        $ lvCity��5c   '   $��Disabled=�5e   '   $
��auto��5f   '    5g   "   �� 5h   &   .P�5i   *   �� $��
Город��69   $
 auto��5j   -    5k   -   �� *City+�� 5l   *   $)��#Количество станций��69   $
 auto��5m   -    5n   -   �� *CountStations+�� 5o   *   $)��#Количество районов��69   $
 auto��5p   -    5q   -   �� *
CountAreas+�� 5r   *   $)��#Количество округов��69   $
 auto��5s   -    5t   -   �� *CountDistricts+�� 5u   *   $��
Карта��69   $
 auto��5v   -    5w   -   �� *Map+5x   '   5z      �� 5|      $��
Карты��6(   $��Center=�5}   (   $��0 20 0 5q�5~   (   $��20(�5   (   �� 5�      -   5        $ lvMap��5�   '   $��Disabled=�5�   '   $
��auto��5�   '    5�   "   �� 5�   &   .P�5�   *   �� $��
Карта��69   $
 auto��5�   -    5�   -   �� *Map+�� 5�   *   $)��#Количество станций��69   $
 auto��5�   -    5�   -   �� *CountStations+�� 5�   *   $)��#Количество районов��69   $
 auto��5�   -    5�   -   �� *
CountAreas+�� 5�   *   $)��#Количество округов��69   $
 auto��5�   -    5�   -   �� *CountDistricts+�� 5�   *   $)��#Количество городов��69   $
 auto��5�   -    5�   -   �� *CountCities+5�   '   5�      5�      5�      5�      5�      �� 5�      $9��3Технические характеристики��6   .��5�      � ���	#FFE5E5E5.+�5�      �� .��5�      �� .+�5�      �� $%��Диапозон глубины��6(   $��Center=�5�   (   $��0 20 0 5q�5�   (   $��20(�5�   (   �� 5�      -   5        $ lvDepthType��5�   '   $��Disabled=�5�   '   $
��auto��5�   '    5�   "   �� 5�   &   .P�5�   *   �� $��От м��69   $
 auto��5�   -    5�   -   �� *	Minimum+�� 5�   *   $��До м��69   $
 auto��5�   -    5�   -   �� *	Maximum+�� 5�   *   $)��#Количество станций��69   $
 auto��5�   -    5�   -   �� *CountStations+5�   '   5�      �� 5�      $��Особенности��6(   $��Center=�5�   (   $��0 20 0 5q�5�   (   $��20(�5�   (   �� 5�      -   5        $ lvPeculiarity��5�   '   $��Disabled=�5�   '   $
��auto��5�   '    5�   "   �� 5�   &   .P�5�   *   �� $��Особенность��69   $
 auto��5�   -    5�   -   �� *Peculiarity+�� 5�   *   $)��#Количество станций��69   $
 auto��5�   -    5�   -   �� *CountStations+5�   '   5�      5�      5�      5�      5�      �� 5�      $ ��Строительство��6   .��5�      � ���	#FFE5E5E5.+�5�      �� .��5�      �� .+�5�      �� $��Расположение��6(   $��Center=�5�   (   $��0 20 0 5q�5�   (   $��20(�5�   (   �� 5�      -   5        $ 
lvLocation��5�   '   $��Disabled=�5�   '   $
��auto��5�   '    5�   "   �� 5�   &   .P�5�   *   �� $��Расположение��69   $
 auto��5�   -    5�   -   �� *
Location+�� 5�   *   $)��#Количество станций��69   $
 auto��5�   -    5�   -   �� *CountStations+5�   '   5�      �� 5�      $��Конструкция��6(   $��Center=�5�   (   $��0 20 0 5q�5�   (   $��20(�5�   (   �� 5�      -	   5        $ lvConstruction��5�   '   $��Disabled=�5�   '   $
��auto��5�   '    5�   "   �� 5�   &   .P�5�   *   �� $��Конструкция��69   $
 auto��5�   -    5�   -   �� *Construction+�� 5�   *   $)��#Количество станций��69   $
 auto��5�   -    5�   -   �� *CountStations+5�   '   5�      �� 5�      $��Перекрытия��6(   $��Center=�5�   (   $��0 20 0 5q�5�   (   $��20(�5�   (   �� 5      -
   5        $ lvFloor��5   '   $��Disabled=�5  '   $
��auto��5  '    5  "   �� 5  &   .P�5  *   �� $��Перекрытия��69   $
 auto��5  -    5  -   �� *Floor+�� 5	  *   $)��#Количество станций��69   $
 auto��5
  -    5  -   �� *CountStations+5  '   5     �� 5     $��
Опоры��6(   $��Center=�5  (   $��0 20 0 5q�5  (   $��20(�5  (   �� 5     -   5        $ lvPillar��5  '   $��Disabled=�5  '   $
��auto��5  '    5  "   �� 5  &   .P�5  *   �� $��
Опоры��69   $
 auto��5  -    5  -   �� *Pillar+�� 5  *   $)��#Количество станций��69   $
 auto��5  -    5  -   �� *CountStations+5   '   5"     �� 5$     $��Пролёты��6(   $��Center=�5%  (   $��0 20 0 5q�5&  (   $��20(�5'  (   �� 5(     -   5        $ lvSpan��5(  '   $��Disabled=�5*  '   $
��auto��5+  '    5,  "   �� 5-  &   .P�5.  *   �� $��Пролёты��69   $
 auto��5/  -    50  -   �� *Span+�� 51  *   $)��#Количество станций��69   $
 auto��52  -    53  -   �� *CountStations+54  '   56     �� 58     $��Платформы��6(   $��Center=�59  (   $��0 20 0 5q�5:  (   $��20(�5;  (   �� 5<     -   5        $ 
lvPlatform��5<  '   $��Disabled=�5>  '   $
��auto��5?  '    5@  "   �� 5A  &   .P�5B  *   �� $��Береговые��69   $
 auto��5C  -    5D  -   �� *
Unilateral+�� 5E  *   $��Островные��69   $
 auto��5F  -    5G  -   �� *	Bilateral+�� 5H  *   $)��#Количество станций��69   $
 auto��5I  -    5J  -   �� *CountStations+5K  '   5M     5N     5O     5P     5Q     �� 5S     $��Другое��6   .��5T     � ���	#FFE5E5E5.+�5U     �� .��5V     �� .+�5W     �� $1��+Диапозон загруженности��6(   $��Center=�5X  (   $��0 20 0 5q�5Y  (   $��20(�5Z  (   �� 5[     -   5        $ lvTrafficType��5[  '   $��Disabled=�5]  '   $
��auto��5^  '    5_  "   �� 5`  &   .P�5a  *   �� $"��От тыс. чел./сут.��69   $
 auto��5b  -    5c  -   �� *	Minimum+�� 5d  *   $"��До тыс. чел./сут.��69   $
 auto��5e  -    5f  -   �� *	Maximum+�� 5g  *   $��Описание��69   $
 auto��5h  -    5i  -   �� *TrafficDescription+�� 5j  *   $)��#Количество станций��69   $
 auto��5k  -    5l  -   �� *CountStations+5m  '   5o     �� 5q     $%��Ценовой диапозон��6(   $��Center=�5r  (   $��0 20 0 5q�5s  (   $��20(�5t  (   �� 5u     -   5        $ lvHousingCost��5u  '   $��Disabled=�5w  '   $
��auto��5x  '    5y  "   �� 5z  &   .P�5{  *   �� $��От тыс. руб./м2��69   $
 auto��5|  -    5}  -   �� *	Minimum+�� 5~  *   $��До тыс. руб./м2��69   $
 auto��5  -    5�  -   �� *	Maximum+�� 5�  *   $)��#Количество станций��69   $
 auto��5�  -    5�  -   �� *CountStations+5�  '   5�     �� 5�     $��Государства��6(   $��Center=�5�  (   $��0 20 0 5q�5�  (   $��20(�5�  (   �� 5�     -   5        $ lvState��5�  '   $��Disabled=�5�  '   $
��auto��5�  '    5�  "   �� 5�  &   .P�5�  *   �� $-��'Название государства��69   $
 auto��5�  9    5�  9   �� *	StateName+�� 5�  *   $)��#Количество станций��69   $
 auto��5�  9    5�  9   �� *CountStations+5�  '   5�     5�     5�     5�     5�     5�     5�     5�     