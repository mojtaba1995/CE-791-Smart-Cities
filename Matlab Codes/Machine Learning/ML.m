!load fisheriris
!rng default % for reproducibility

!data = xlsread('2.xlsx');
!outputs = xlsread('2.xlsx',1,'A1:X73');
!inputs = xlsread('2.xlsx',1,'AB1:AY4');


!gscatter(outputs(:,1),outputs(:,2))

outputs = xlsread('4 Not Stable.xlsx',1,'A1:ER73');
inputs = xlsread('4 Not Stable.xlsx',1,'FP1:LG4');