   M S B A M L   `   `   `  ����C  ?MetroApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MetroAppMetroApp  5   	       MetroApp.AddUpdateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MetroApp     5   	     � Icon$  	/logo.png��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Ee wer weg r��5
   	   $	��700��6   $	��500��6+   .��5      � ��5   
   �� 5       �� ImageSource$" /Images/water_texture840.jpg��6    j� Stretch$
 Fill=�6D    � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $
��553* �6   �� 5      $	��50* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ tbTitle��5      $'��!Добавить/Изменить��5      $��2��5      $��Center=�5      $��30(�5      �� 5   
   -   5         ��Name$ 	StPanText��5      $��10q�5       $��Center=�5!      $��1��5"      6$   �� 5#   
   -   5        $ StPanTxtBox��5#      $��10q�5$      $��Center=�5%      $��1��5&      $��1��5'      6'   �� 5)   
   -   5        	 ��Name$	 btnAddUpdate��5)      $	��150��5*      $��50��5+      $��button��5,      $��20(�5-      $��2��5.      $��Center=�5/      $��Center=�50      $��2��51      
�������
��� � �54      55      56      