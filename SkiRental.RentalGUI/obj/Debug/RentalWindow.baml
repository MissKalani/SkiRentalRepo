   M S B A M L   `   `   `  ����N  JSkiRental.RentalGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SkiRental.RentalGUISkiRental.RentalGUI  5   	   O,clr-namespace:SkiRental.RentalGUI.ViewModelsSkiRental.RentalGUI.ViewModels  5   	   &     SkiRental.RentalGUI.RentalWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SkiRental.RentalGUI     5   	   ;vm,clr-namespace:SkiRental.RentalGUI.ViewModels     5   	   -   5          � Title$
  Rent��5	   	   $	��350��6   $	��500��6#    � DataContext 5
      3   -SkiRental.RentalGUI.ViewModels.RentalWindowVM  5   
    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        Rent��   Command$% local:RentalWindowCommands.Rent��5   '   6n     5   
   -   5        
Cancel��$' !local:RentalWindowCommands.Cancel��5   )   6t   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   .+�5      �� $��0��6   .+�5      �� $��Product Information��6   .��5      �� .+�5      � .+�5      �� .��6$   
Product:6.   �� 5      ��6$   ��  �� Path$ Equipment.ProductName�5       � 5!      .+�5"      �� .��6$   Type:6+   �� 5#      ��6$   �� $&  Equipment.EquipmentType.TypeName�5$      5%      5&      �� 5'      $��Rental Information��6   .��5(      �� .+�5)      �� .��6    Plan6&   �� 5*      -   5        $��cbRentalPlan��5*   #    �� DisplayMemberPath$ Description��6_    �� SelectedValuePath$
 Plan��6�   ��67   �� *RentalPlanItems+	 �� SelectedValue	 6   �� *SelectedRentalPlan+6�   �� 5+      .��6    Customer Name6/   �� 5,      ��6"   �� *CustomerName+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5-      .��6    Customer Phone60   �� 5.      ��6"   �� *CustomerPhoneNumber+$
 PropertyChanged=�5/      50      � 51      .+�52      �� .��6   Total Price:6*   �� 53      ��6   �� *CalculatedPrice+54      55      56      � 57   
   $��1��6   .+�58      �� $	��120��6   $
��Left=�6!   $'��!local:RentalWindowCommands.Cancel��6<   .��6h   Cancel6p   �� 59      $	��120��6   $��Right=�6!   $%��local:RentalWindowCommands.Rent��6=   .��6g   Rent6m   5:      5;      5=      