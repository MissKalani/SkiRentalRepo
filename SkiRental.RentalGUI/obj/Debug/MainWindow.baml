   M S B A M L   `   `   `  ����N  JSkiRental.RentalGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SkiRental.RentalGUISkiRental.RentalGUI  5   	   O,clr-namespace:SkiRental.RentalGUI.ViewModelsSkiRental.RentalGUI.ViewModels  5   	   $    SkiRental.RentalGUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SkiRental.RentalGUI     5   	   ;vm,clr-namespace:SkiRental.RentalGUI.ViewModels     5   	   -   5          � Title$  	SkiRental��5	   	   $	��350��6   $	��525��6(    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5        Exit��   Command$# local:MainWindowCommands.Exit��5   '   6l     5   
   -   5        
Update��$% local:MainWindowCommands.Update��5   )   6r     5   
   -   5        
OpenRental��$) #local:MainWindowCommands.OpenRental��5   -   6~     5   
   -   5        
Return��$% local:MainWindowCommands.Return��5   )   6r     5   
   -   5        	About��$$ local:MainWindowCommands.About��5   (   6o    � DataContext 5      1   +SkiRental.RentalGUI.ViewModels.MainWindowVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $��_File��6   .@�5      m� $��_Update��6    m� Command$% local:MainWindowCommands.Update��6,   m� 5      $��_Exit��6   $# local:MainWindowCommands.Exit��6*   5      m� 5      $��_Help��6   .@�5      m� $��_About��6   $$ local:MainWindowCommands.About��6+   5       5!      �� 5"   
   $��1��6   .@�5#      �� $
��Rent��5$   6   .��5%      �  5&      �� 5'      $
��Auto �6(   �� 5(      $��* �6(   .+�5*      � $��0��6    .+�5+      �� $	��120��6!   $	��0,5q�6-   $)��#local:MainWindowCommands.OpenRental��6:   .��6h   Rent6n   5,      &   System.Windows.Controls.DataGrid  5-      -   5        $��dgAvailableEquipment��5-   ,   $��1��6      
IsReadOnly .    SelectionMode$ Single=�6Z      AutoGenerateColumns .  ��6�   �� *AvailableEquipment+	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Product Name��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   ��  �� Path$ ProductName�  50      $

 Type��61    6?   �� $ EquipmentType.TypeName�  51      $
 Price Per Hour��61    6I   �� $  EquipmentType.PricePerHour�  52      $
 State��61    6@   �� $  EquipmentState.Description�54      55      56      �� 57      $��Return��58   8   .��59      �  5:      �� 5;      $
��Auto �6(   �� 5<      $��* �6(   .+�5>      � $��0��6    .+�5?      �� $	��120��6!   $	��0,5q�6-   $%��local:MainWindowCommands.Return��6:   .��6d   Return6l   5@        5A      -   5        $��dgRentedEquipment��5A   ,   $��1��6    . $ Single=�6W    .   �� SelectedValuePath$ Rental��6�   ��6�   �� *	Rentals+ �� SelectedValue 6�   �� *SelectedRentalToReturn+	 5B        5C      $
 Product Name��61    6G   �� $" Rental.Equipment.ProductName�  5D      $
 Customer Name��61    6H   �� $ Rental.CustomerName�  5E      $
 Customer Phone��61    6I   �� $  Rental.CustomerPhoneNumber�  5F      $
 Due Time��61    6C   �� $ DueTime�5H      5I      5J      5K      5L      5M      