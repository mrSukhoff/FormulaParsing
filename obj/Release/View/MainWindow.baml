   M S B A M L   `   `   `  ���� I  EFormulaParsing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Stacker.ViewModelsStacker.ViewModels      FormulaParsing.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /vm clr-namespace:Stacker.ViewModels       � Title$  Разбор строки��$	��800��$	��600�� � 
ResizeMode$ CanMinimize=� � DataContext "  Stacker.ViewModels.ViewModel   � 	Resources  
  Color1 �� Color 
 Color2 
 Color3 
 Color4 �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 &     &	 9     '�� L     '�� �     '�� �    �� $ #2179e3���� $ #218CE3���� $ #FFFFFF���� $ #010101���� " ��.���  � ��# �   ��  � ��$ 24(���  � ��$
 Bold"���  � ��$
 Vani)���  � ��$ Center=���  � ��$ Bottom=��� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 20(���  � ��$
 Bold"���  � ��$
 Vani)���  �@��TextWrapping$
 Wrap=��� " ��.���  � ��$ 24(���  � ��$ SemiBold"���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � �� �� " ��.R��� $	 Border��$
 5��$��3q�#���  #���  ._��� $��2q�$��Center=�$��Center=���.  P�  �@J�IsMouseOver . . ��� $ Border��# �   � ���� $ Border��# �   � ��P�  � �� . . ��� $ Border��# �   � ���� $ Border��# �    � ���� # �    � ��.��� #���  $��0 0 0 0q� � RowDefinitions �� $��1* ��� $��3* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��2* �.+��� $��0��$��ВЫРАЖЕНИЕ���� $��1��$��10 10 10 10q����� *
Expression+�� $��2��$��ПЕРЕМЕННАЯ���� $��3��$��10 10 10 10q����� *ValueOfVariable+�� $��4��$��Результат���� $��5��$��50(����� *Result+ �� Mode$ OneWay=��� $��6��$��66��$��10 10 10 10q�$��20 10 20 10q�$��Расчитать��