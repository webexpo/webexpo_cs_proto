   M S B A M L   `   `   `  ���� \  XWebExpo.InterfaceGraphique.Csharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WebExpo.InterfaceGraphiqueWebExpo.InterfaceGraphique  ]3clr-namespace:WebExpo.InterfaceGraphique.Properties%WebExpo.InterfaceGraphique.Properties  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem +    %WebExpo.InterfaceGraphique.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :local(clr-namespace:WebExpo.InterfaceGraphique     Ap3clr-namespace:WebExpo.InterfaceGraphique.Properties     9System&clr-namespace:System;assembly=mscorlib       �Language$  fr-CA�5   /WebExpo.InterfaceGraphique.Properties.Resources   Title � Title# Z $	��542��$	��850��$��Trebuchet MS)� � 	Resources 2   ,WebExpo.InterfaceGraphique.PastDataConverter   PDConverterMean  PDConverterSD  PDConverterN   	HandleInt2   ,WebExpo.InterfaceGraphique.CheckBoxConverter  CBConverter��%C   &	        &	      &	 
     &	             .   .��� $��6,0,-6.8,-28.2q�$	��537��$	��Top=� � RowDefinitions �� $
��589* ��� $	��13* �.+��� -    ��Name$ buttonLancer��   StartCalculations#��Z $��28��$��172,474,176,0q�$	��Top=�$��14(��� -   $��Observations��$
��Left=�$	��196��$��	17,28,0,0q� �� 
AcceptsTab . 	 �� TextWrapping$
	 Wrap=�
 �� AcceptsReturn
 . $	��Top=�$	��183��.�� =� ErrorTemplate �� .R�� .+���  ��Name$ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 J� IsHitTestVisible .  ��  ��Name$ placeholder���  � AllowsTransparency . $��Right=� � HorizontalOffset$ 0�� � VerticalOffset$ 0��$
��Fade=�$��Right=� � PlacementTarget ��  �� ElementName$ errorBorder������ *AdornedElement.IsFocused+$ placeholder�� �� Mode$ OneWay=�.����  �� Orientation$ 
Horizontal=�.+�� $��Center=� � Points �    	=  	=  	=  z ���	#FFCB2E2E �� Stretch$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E �� CornerRadius$ 4�� �� Padding$ 4q�._��� 
����������� *[0].ErrorContent+.��.����  �� Path$ Entrs.Observations�$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=� �� ValidationRules :   4WebExpo.InterfaceGraphique.MeasureListValidationRule  ��    	StatModel#��Z $
��Left=�$��25��$��	218,6,0,0q�$	��Top=�$	��130��$
��Bold"� J� RenderTransformOrigin$ 0.5,0.5&�$��14(��� -    ��Name$ muInit��$
��Left=�$��20��$��521,139,0,0q�$
	 Wrap=�$	��Top=�$��49��.�� -   'WebExpo.InterfaceGraphique.BindingProxy  boundsProxy    Bounds0   *WebExpo.InterfaceGraphique.AlternateBounds!   Min1"   Max1#   Min2$   Max2��%D   &	             $! 50Q�$	" 120Q�$# -6.908Q�$$ 4.605Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.InitMu�$ TwoWay=�$ 	LostFocus=�% �� StringFormat$% 	{0:0.###}�� 5   /WebExpo.InterfaceGraphique.MinMaxValidationRule  &   
ValidRange& 3   -WebExpo.InterfaceGraphique.DoubleRangeChecker  '   Minimum' �� *
MinValue+( �� Source#( [ )   Maximum) �� *
MaxValue+#( [ �� -   $��InitValLabel��$
��Left=�$��22��$��414,117,0,0q�$	��Top=�$	��100��$ 0.5,0.5&�*   InitVals#��Z* �� -   $ 	sigmaInit��$
��Left=�$��20��$��521,164,0,0q�$
	 Wrap=�$	��Top=�$��49��.�� ��%C   &	             $	! 0.5Q�$" 10Q�$# 0.405Q�$$ 2.303Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.InitSigma�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� +   InterpretSettings#��Z+ $
��Left=�$��25��$��
10,229,0,0q�$	��Top=�$	��196��$
��Bold"�$ 0.5,0.5&�$��14(��� $��Observations��$
��Left=�$��25��$��7,5,0,0q�$	��Top=�$��94��$
��Bold"�$ 0.5,0.5&�$��14(�z�V� .~��� �� �� , �� Angle$, 0.747Q�T� 	� -   $��DistLogNormale��- 	� 	GroupName$
- dist��.   LogNorm#��Z. $
��Left=�$��225,108,0,0q�$	��Top=�/ d� 	IsChecked/ �� *ModelParams.LogNormalDstrn+$ TwoWay=�	� -   $��DistNormale��$
- dist��0   Norm#��Z0 $
��Left=�$��225,126,0,0q�$	��Top=�$��68���� 
1   OEL#��Z1 $
��Left=�$��22��$��
12,262,0,0q�$	��Top=�$	��146���� $
��Left=�$��22��$��172,261,0,0q�$
	 Wrap=�$	��Top=�$��43��.��.���� $ 	Entrs.VLE�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 4	   .WebExpo.InterfaceGraphique.RangeValidationRule	  2 	  Minimum$2 0Q� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� $
��Left=�$��40��$��
13,285,0,0q�$	��Top=�$	��168���� 3   	ProbCred1#�Z3  �� $�
�� �� 4   	ProbCred2#�Z4 �� $
��Left=�$��22��$��172,291,0,0q�$
	 Wrap=�$	��Top=�$��43��.��.���� $ Entrs.ProbCred�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $2 1Q�5 	  Maximum$5 99Q� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� $
��Left=�$��40��$��
17,318,0,0q�$	��Top=�$	��169���� 6   Exceedance1#�Z6  �� $�
�� �� 7   Exceedance2#�Z7 �� $
��Left=�$��22��$��172,322,0,0q�$
	 Wrap=�$	��Top=�$��43��.��.���� $! Entrs.FracDepassementLimite�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $	2 0.1Q�$5 99Q� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� 8   CritPercentilePerc#��Z8 $
��Left=�$��25��$��
12,351,0,0q�$	��Top=�$	��159���� $
��Left=�$��22��$��172,352,0,0q�$
	 Wrap=�$	��Top=�$��43��.��.���� $ Entrs.CentileCritique�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $2 1Q�$5 99Q� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� 9   MCMCSettings#��Z9 $
��Left=�$��25��$��	411,6,0,0q�$	��Top=�$	��159��$
��Bold"�$ 0.5,0.5&�$��14(��� $
��Left=�$��25��$��
414,36,0,0q�$	��Top=�$	��103��$ 0.5,0.5&�:   NIter#��Z: �� $
��Left=�$��22��$��
521,35,0,0q�$
	 Wrap=�$	��Top=�$��49������ *MCMCParams.NIter+$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��22��$��
415,64,0,0q�$	��Top=�$��72��$ 0.5,0.5&�;   NBurnIn#��Z; �� $
��Left=�$��22��$��
521,62,0,0q�$
	 Wrap=�$	��Top=�$��49������ *MCMCParams.NBurnin+$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��25��$��
416,91,0,0q�$	��Top=�$��92��$ 0.5,0.5&�<   	NThinning#��Z< �� $
��Left=�$��22��$��
521,89,0,0q�$
	 Wrap=�$	��Top=�$��49������ *MCMCParams.NThin+$ TwoWay=�$ PropertyChanged=��� -   $
��Left=�$��14��$��
712,36,0,0q�$	��Top=�$��16��.���� $ MCMCParams.MonitorBurnin�$ TwoWay=�$ 	LostFocus=�= �� 	Converter#= [ �� $
��Left=�$��26��$��
594,31,0,0q�$	��Top=�$	��104��$ 0.5,0.5&�>   MonitorBurnIn#��Z> �� -	   $��DAPLabel��$
��Left=�$��25��$��222,234,0,0q�$	��Top=�$	��247��$
��Bold"�$ 0.5,0.5&�$��14(��� ?   APrioriDist#�Z?  �� $��Consolas)�.�mu �� 
@   And#�Z@  �� $��Consolas)�.�sigmaG(clr-namespace:WebExpo.InterfaceGraphiqueWebExpo.InterfaceGraphique  �� 6k(clr-namespace:WebExpo.InterfaceGraphique     -
   $ MuLwr��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$ 
3.077,0.57&�$��360,262,0,0q�.�� ��%@   &	             $! 20Q�$" 85Q�$
# -100Q�$
$ -0.5Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.MuLower�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $ MuUpr��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$ 0.663,1.507&�$��433,262,0,0q�.�� ��%@   &	             $	! 0.5Q�$	" 100Q�$	# 0.5Q�$	$ 100Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.MuUpper�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� $
��Left=�$��231,269,0,0q�$	��Top=�$��85���� A   APrio#�ZA  �� $��Consolas)�.�mu�� $	��Min��$
��Left=�$��21��$��332,264,0,0q�$	��Top=�$��30��$��Italic$�$��11(��� $	��Max��$
��Left=�$��28��$��405,264,0,0q�$	��Top=�$��30��$��Italic$�$��11(��� -   $��NObservations��$��Right=�$
��Left=�$��23��$��	101,8,0,0q�$	��Top=�$	��102��$��[0 observations]��$��Italic$�$��10(��� $��Consolas)�$��mu��$
��Left=�$��24��$��427,139,0,0q�$	��Top=�$��26���� $��Consolas)�$��sigma��$
��Left=�$��25��$��427,164,0,0q�$	��Top=�$��42���� -   $��BWCanvas��$
��Left=�$	��216��$��465,381,-238,0q�$	��Top=�$	��525��B K� ZIndex$	B 103��C J� OpacityMaskC �	#FF681A1A
�������$��2��.+��� $
��Left=�$��33��$	��Top=�$	��376��$
��Bold"�$��14(��� D   APrioriDist2#�ZD  �� .�( �� E   BetweenWorkers#�ZE  �� .�) �� 	F   Of#�ZF  �� $��Consolas)�.�mu �� #�Z@  �� $��Consolas)�.�sigma�� $	��Min��$��24��G �� Left$	G 148��
H �� Top$H 33��$��28��$��Italic$�$��10(��� $	��Max��$��21��$	G 232��$H 33��$��34��$��Italic$�$��10(��� -   $��22��$	G 175��$
	 Wrap=�$H 30��$��58��.�� ��%@   &	             $! 20Q�$" 85Q�$
# -100Q�$
$ -0.5Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $" BwModelParams.MuOverallLower�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� $��22��$	G 259��$
	 Wrap=�$H 30��$��54��$ 0.056,0.539&�.�� ��%?   &	             $! 85Q�$	" 140Q�$	# 0.5Q�$	$ 100Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $" BwModelParams.MuOverallUpper�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ 	� -   $��DistribAPBW_Expostats��$- bwmodeltype��$��	Expostats��$��16��$G 19��$H 79��$��72��$
/ TrueY��� -   I ��Name$I DistribAPBW_ExpostatsLbl1��$��log.sigma.between.mu��$��24��$G 22��$	H 100��$	��142��$��Consolas)��� -   $I DistribAPBW_ExpostatsLbl2��$��log.sigma.between.prec��$��24��$G 23��$	H 126��$	��158��$��Consolas)��� -   $' !DistribAPBW_ExpostatsLogSigmaBwMu��$��20��$	G 175��$
	 Wrap=�$	H 100��$��58��.�� ��%E   &	             $! -0.69Q�$
" 2.30Q�$
# -0.9Q�$
$ 0.48Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $% BwModelParams.LogSigmaBetweenMu�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $) #DistribAPBW_ExpostatsLogSigmaBwPrec��$��20��$	G 175��$
	 Wrap=�$	H 127��$��58��.�� ��%@   &	             $	! 0.4Q�$	" 6.0Q�$	# 0.4Q�$	$ 6.0Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $' !BwModelParams.LogSigmaBetweenPrec�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $) #DistribAPBW_ExpostatsLogSigmaWiPrec��$��20��$	G 175��$
	 Wrap=�$	H 182��$��58��.�� ��%A   &	             $	! 0.4Q�$	" 6.0Q�$	# 0.4Q�$
$ -6.0Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $&  BwModelParams.LogSigmaWithinPrec�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $' !DistribAPBW_ExpostatsLogSigmaWiMu��$��20��$	G 175��$
	 Wrap=�$	H 155��$��59��$ 0.973,0.374&�.�� ��%D   &	             $! -0.69Q�$	" 2.3Q�$
# -0.9Q�$
$ 0.48Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $$ BwModelParams.LogSigmaWithinMu�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ 	� -   $��DistribAPBW_Uniform��$- bwmodeltype��J   Uniform#��ZJ $	G 238��$H 78���� -   $I DistribAPBW_UniformLbl7��$	��Min��$	G 339��$	H 102��$��10(�$��Italic$�{�.  �� -   $I DistribAPBW_UniformLbl8��$	��Max��$	G 425��$	H 102��$��10(�$��Italic$�{�.  �� -   $I DistribAPBW_UniformLbl5��$��sigma.between��$	G 244��$	H 101��{�.  $��Consolas)��� -   $I DistribAPBW_UniformLbl6��$��sigma.within��$	G 245��$	H 129��{�.  $��Consolas)��� -   $( "DistribAPBW_UniformSigmaBetweenMin��$��22��$	G 367��$
	 Wrap=�$	H 100��$��53��{�.  .�� ��%:   &	             $! 0Q�$	" 100Q�$# 0Q�$$ 3Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $) #BWUModelParams.SigmaBetweenRange[0]�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $(��"DistribAPBW_UniformSigmaBetweenMax��$��23��$	G 452��$
	 Wrap=�$H 99��$��58��{�.  .�� ��%:   &	             $! 0Q�$	" 100Q�$# 0Q�$$ 3Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $) #BWUModelParams.SigmaBetweenRange[1]�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $'��!DistribAPBW_UniformSigmaWithinMin��$��23��$	G 367��$
	 Wrap=�$	H 129��$��53��{�.  .�� ��%@   &	             $
! 0.01Q�$	" 100Q�$
# 0.01Q�$$ 3Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $( "BWUModelParams.SigmaWithinRange[0]�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $'��!DistribAPBW_UniformSigmaWithinMax��$��23��$	G 452��$
	 Wrap=�$	H 129��$��58��{�.  .�� ��%?   &	             $	! 0.1Q�$	" 100Q�$
# 0.01Q�$$ 3Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $( "BWUModelParams.SigmaWithinRange[1]�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -   $"I DistribAPBW_UniformLbl7_Copy��$	��Min��$	G 341��$	H 132��$��10(�$��Italic$�{�.  �� -    $"I DistribAPBW_UniformLbl8_Copy��$	��Max��$	G 425��$	H 133��$��10(�$��Italic$�{�.  �� -!   $$I DistribAPBW_ExpostatsLbl1_Copy��$��log.sigma.within.mu��$��24��$G 23��$	H 155��$	��138��$��Consolas)��� -"   $$I DistribAPBW_ExpostatsLbl2_Copy��$��log.sigma.within.prec��$��24��$G 23��$	H 181��$	��148��$��Consolas)��� $
��Left=�$	��Top=�$��85��$G 13��$H 37���� #�ZA �� $� ���� $��Consolas)�$�mu���� $
��Left=�$	��Top=�$	��103��$G 13��$H 59���� #�ZA �� $� ���� $��Consolas)�$�sigma���� -#   $��BWInitValsCanvas��$
��Left=�$��76��$��630,158,-46,0q�$	��Top=�$	��168��
�������.+��� $��Valeurs intiales��$��22��$��92���� $��Consolas)�$��
mu.overall��$��22��$H 20��$��82��$G 10���� $��21��$	G 106��$
	 Wrap=�$H 24��$��49��.�� ��%D   &	             $! 50Q�$	" 120Q�$# -6.908Q�$$ 4.605Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $! BwModelParams.InitMuOverall�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� $��Consolas)�$��sigma.within��$��22��$G 10��$H 47��$��91���� $��21��$	G 106��$
	 Wrap=�$H 47��$��49��.�� ��%C   &	             $	! 0.5Q�$" 10Q�$# 0.095Q�$$ 2.303Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $# BwModelParams.InitSigmaWithin�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ 	� -$   K 	�Name$K DistriAP_Expostats��$- 
priorsigma��$��	Expostats��$
/ TrueY�$��235,308,440,197.6q��� -%   $I DistriAP_ExpostatsLbl1��$��log.sigma.mu��$
��Left=�$��28��$	��Top=�$��93��$��242,325,0,0q�$��Consolas)��� -&   $I DistriAP_ExpostatsLbl2��$��log.sigma.prec��$
��Left=�$��28��$	��Top=�$	��111��$��242,351,0,0q�$��Consolas)��� -'   L ��Name$L DistriAP_ExpostatsPData��M   WithData#��ZM $
��Left=�$��248,377,0,0q�$	��Top=��� -(   $" DistriAP_ExpostatsPData_Mean��$
��Left=�$��22��$
	 Wrap=�$	��Top=�$��45��$��265,408,0,0q�{�.  ���� *PastData.Mean+$ TwoWay=�$% 	{0:0.###}��$ 	LostFocus=�#= [  �� -)   $"I DistriAP_ExpostatsPData_Lbl1��$
��Left=�$��25��$	��Top=�$��50��$
��mean��$��260,387,0,0q�{�.  �� -*   $"I DistriAP_ExpostatsPData_Lbl2��$
��Left=�$��25��$	��Top=�$��23��$��sd��$��312,387,0,0q�{�.  �� -+   $  DistriAP_ExpostatsPData_Sd��$
��Left=�$��22��$
	 Wrap=�$	��Top=�$��45��$ 0.764,0.609&�$��315,408,0,0q�{�.  ���� *PastData.SD+$ TwoWay=�$% 	{0:0.###}��$ 	LostFocus=�#= [ �� -,   $"I DistriAP_ExpostatsPData_Lbl3��$
��Left=�$��24��$	��Top=�$��17��$��n��$��363,388,0,0q�{�.  �� --   $ DistriAP_ExpostatsPData_N��$
��Left=�$��22��$
	 Wrap=�$	��Top=�$��33��$��365,408,0,0q�{�.  ���� *
PastData.N+$ TwoWay=�$% 	{0:0.###}��$ 	LostFocus=�#= [ �� -.   $" DistriAP_ExpostatsLogSigmaMu��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$��353,325,0,0q�.�� ��%F   &	             $! -0.90Q�$
" 0.48Q�$# -0.69Q�$
$ 2.30Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.LogSigmaMu�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ �� -/   $$ DistriAP_ExpostatsLogSigmaPrec��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$ 0.663,1.507&�$��353,352,0,0q�.�� ��%B   &	             $
! 0.40Q�$	" 6.0Q�$
# 0.40Q�$	$ 6.0Q�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ ModelParams.LogSigmaPrec�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}��   &   ' �� *
MinValue+#( [ ) �� *
MaxValue+#( [ 	� -0   $K DistriAP_Uniforme��$	��100��$- 
priorsigma��#��ZJ $��420,308,232,196.6q��� -1   $I DistriAP_UniformeLbl1��$��	sigma.inf��$
��Left=�$��28��$	��Top=�$��70��$��423,325,0,0q�{�.  $��Consolas)��� -2   $I DistriAP_UniformeLbl2��$��	sigma.sup��$
��Left=�$��28��$	��Top=�$��78��$��423,350,0,0q�{�.  $��Consolas)��� -3   $ DistriAP_UniformeSigmaSup��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$ 0.663,1.507&�$��493,351,0,0q�{�.  ���� *
SDRange[1]+$ TwoWay=�$% 
{0:0.###} ��$ 	LostFocus=��� -4   $ DistriAP_UniformeSigmaInf��$
��Left=�$��20��$	 NoWrap=�$	��Top=�$��45��$ 0.663,1.507&�$��493,326,0,0q�{�.  ���� *
SDRange[0]+$ TwoWay=�$% 
{0:0.###} ��$ 	LostFocus=��� $��Distribution��$
��Left=�$��
219,84,0,0q�$	��Top=��� $
��Type��$
��Left=�$��
219,28,0,0q�$	��Top=�	� -5   $��UseModelGES��
N   GES#��ZN $- interp��$
��Left=�$��
225,52,0,0q�$	��Top=�$
/ TrueY�	� -6   $��
UseModelBW��O   BWVariations#��ZO $- interp��$
��Left=�$��
225,71,0,0q�$	��Top=��� P   MeasErr#��ZP $
��Left=�$��218,141,0,0q�$	��Top=�	� -7   $��me_none��$- errmeas��Q   NoError#��ZQ $
��Left=�$��227,163,0,0q�$	��Top=�$
/ TrueY�	� -8   $K me_CV��$- errmeas��R   VarCoeff#��ZR $
��Left=�$	��Top=�$��227,182,0,0q��� -9   $I 	me_CVLbl1��$	��Min��$
��Left=�$��27��$	��Top=�$��37��$��Italic$�$��11(�{�.  $��239,201,0,0q��� -:   $ me_CVMin��$
��Left=�$��21��$
	 Wrap=�$	��Top=�$��45��$ 1.813,3.952&�$��267,200,0,0q�{�.  ���� *MERange.Minimum+$ TwoWay=�$% 	{0:0.###}��$ 	LostFocus=�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� -;   $I 	me_CVLbl2��$	��Max��$
��Left=�$��27��$	��Top=�$��33��$ 0.921,0.471&�$��Italic$�{�.  $��318,200,0,0q�$��11(��� -<   $ me_CVMax��$
��Left=�$��21��$
	 Wrap=�$	��Top=�$��45��{�.  $��348,200,0,0q����� *MERange.Maximum+$ TwoWay=�$% 	{0:0.###}��$ 	LostFocus=�.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� -=   $��BWWwctCanvas��$
��Left=�$��89��$��
12,375,0,0q�$	��Top=�$	��213��.+��� $��32��$	��155��$H 5���� S   CorrelThresh#�ZS  �� $�
�� �� T   WithinWorkers#�ZT �� $��21��$	G 160��$
	 Wrap=�$H 8��$��43��.��.���� $, &Entrs.SeuilCorrelationIntraTravailleur�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $2 0Q�$5 1Q� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.���� U   
RbRatioCov#��ZU $��22��$	��134��$H 34���� $��21��$	G 160��$
	 Wrap=�$H 34��$��43��.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $ Entrs.CouvertureRatioRb�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $2 0Q�$	5 100Q��� $��35��$	��155��$H 56���� V   OverExpoProbThresh1#�ZV  �� $�
�� �� W   OverExpoProbThresh2#�ZW �� $��21��$	G 160��$
	 Wrap=�$H 61��$��43��.�� �� .R�� .+��� $ errorBorder�����	#FFCB2E2E$��1q����	#11FF0000 .  �� $ placeholder���  . $��Right=�$ 0��$ 0��$
��Fade=�$��Right=� �� $ errorBorder������ *AdornedElement.IsFocused+$ placeholder��$ OneWay=�.���� $ 
Horizontal=�.+�� $��Center=� �    	=  	=  	=  z ���	#FFCB2E2E$
 Fill=����	#FFCB2E2E$��2���� ���	#FFCB2E2E$ 4��$ 4q�._��� 
����������� *[0].ErrorContent+.��.���� $! Entrs.SeuilProbSurexpoIndiv�$ TwoWay=�$ 	LostFocus=�$% 	{0:0.###}�� 	  $2 0Q�$	5 100Q��� $
��Left=�$��231,288,0,0q�$	��Top=�$	��103���� #�ZA �� $� ���� $��Consolas)�$�sigma���� X   OuputSettings#��ZX $��25��$��
591,7,20,0q�$	��Top=�$
��Bold"�$ 0.5,0.5&�$��14(��� $
��Left=�$��26��$��594,114,0,0q�$	��Top=�$	��240��$ 0.5,0.5&�Y   CSVSep#��ZY 	� ->   $��CsvSepPV��$- csvsep��Z   	SemiColon#��ZZ $
��Left=�$��604,138,0,0q�$	��Top=�$
/ TrueY�	� -?   $- csvsep��[   Comma#��Z[ $
��Left=�$��604,157,0,0q�$	��Top=��� $��40��$��594,55,46.4,0q�$	��Top=�$ 0.5,0.5&��� \   NumHistoClasses1#�Z\  �� $�
�� �� ]   NumHistoClasses2#�Z] �� -@   $��HistoNumClassesSlider��$
��Left=�$��22��$��
607,89,0,0q�$	��Top=�$	��121��^ � Minimum$^ 20Q�_ � Maximum$_ 50Q�` �� Interval$` 2��a �� TickPlacement$a BottomRight=�b �� IsSnapToTickEnabledb . �� -A   $��HistoNumClasses��$
��Left=�$��22��$��
712,62,0,0q�$
	 Wrap=�$	��Top=�$��26��c �� 
IsReadOnlyc . ���� $ HistoNumClassesSlider��$ Value�$ PropertyChanged=�$ OneWay=�