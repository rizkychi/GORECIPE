   M S B A M L   `   `   `  ����@  <Gocip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Gocip.View
Gocip.View  5   	   !    Gocip.View.DataKategoriPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Gocip.View     5   	   $	��700��5   	   $	��250��5	   	   $��15,15,15,15q�5
   	     N� Title$  DataKategoriPage��5   	   .��5      � .+�5   
   ��  �� CornerRadius$ 1��6   $��1q�6"   ���#fff._�5      �� ���#fff.+�5      �� -   5         ��Name$ lblJudul��5      $��Daftar Kategori��6*   $��20(�6D   ���#000$��10,8,8,8q�6d   $��
ExtraLight"�6v   $��	Open sans)�6�   �� 5      ���#F1F2F7$��1��6.   � 5      $��10,10,10,10q�6    � RowDefinitions 5      �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5      � $��0,0,0,0q�6   $��0��6,    5      �� 5      $��0 �6,   �� 5      $	��30* �6,   �� 5      $	��30* �6,    � ColumnDefinitions 5      �� 5      $	��150 �6/   �� 5       $��1* �6/   .+�5"      �� $��Nama Kategori��6    $��12(�68   
���   �$��0��6Y   $��1��6i   $��Center=�6v   $��30��6�   �� 5#      $��Kategori Utama��6    $��12(�69   
���   �$��0��6Z   $��2��6j   $��Center=�6w   $��30��6�   �� 5$      -   5         ��Name$ txtCategoryName��5$   "   $	��200��6|   $��1��6�   $��1��6�   $
��Left=�6�   $��Center=�6�   {�. ��6<   ��  �� ElementName$ 
dgKategori�� �� Path$ SelectedItem.name�6�   �� 5%      -   5        $ 	txtSearch��5%   "   $
��Cari��65   $	��150��6A   $��1��6M   $��1��6]   $��Right=�6j   $��Center=�6�   6�   �� 5&      $��1q�6g   $��1��6{   $��30��6�   $��2��6�   $ 2��6�   $	��200��6�   $
��Left=�6�   $��5,5,5,5q�6�   ��6!   �� $ BorderBrush�$ txtCategoryMain��._�5'      �� -   5         ��Name$ txtCategoryMain��5'   '   $��Stretch=�6�   $��Stretch=�6�   	 �� SelectedIndex$	 0��6�   
 �� Text
 6@   �� $ 
dgKategori��$  SelectedItem.main_category�.@�5(   "   �� $
��Khas��6/   $
��Left=�6>   $	��198��6Y   �� 5)   "   $
��Rasa��6/   $
��Left=�6>   $	��198��6Y   �� 5*   "   $��Jenis��6/   $
��Left=�6?   $	��198��6Z   �� 5+   "   $��Bahan Utama��6/   $
��Left=�6E   $	��198��6`   �� 5,   "   $��Metode��6/   $
��Left=�6@   $	��198��6[   5.      5/      50      � 51      $��	0,10,0,10q�6   $��40��6.   $��1��6:    52      �� 53      $	��110 �6/   �� 54      $	��110 �6/   �� 55      $	��110 �6/   �� 56      $��3* �6/   �� 57      $	��110 �6/   �� 58      $	��110 �6/   .+�5:      �� -   5         ��Name$ 	btnTambah��5:   !   $��Tambah��64   $��0��6E   6U   �� 5;      -   5        $ btnUbah��5;   !   $
��Ubah��62   $��1��6A   6Q   �� 5<      -   5        $ btnHapus��5<   !   $��Hapus��63   $��2��6C   6S   �� 5=      -   5        $ 	btnSimpan��5=   !   $��Simpan��64   $��4��6E   $y�Visible=�6m   �� 5>      -	   5        $ 	btnCancel��5>   !   $��Batal��64   $��5��6D   $y�Visible=�6l   5?      �� 5@      $��	5,10,5,10q�6!   $��2��64   .+�5A      &   System.Windows.Controls.DataGrid  -
   5          Name$ 
dgKategori��5A   #   
dgKategori��   AutoGenerateColumns .  $	 0��6~      
IsReadOnly .    CanUserResizeColumns .     CanUserResizeRows .     CanUserReorderColumns .  ��6J   ��    Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6]      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6i      
Visibility$ Hidden=�6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� $ id_category�6t     5D   "   $ Nama Kategori��6V   $ * 6m    66   �� $
 name�6m     5E   "   $ Kategori Utama��6_   $ * 6w    66   �� $ main_category�6w   5G      5H      5I      5J      5K      5L      5N      