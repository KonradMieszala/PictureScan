# PictureScan

##G³ówne za³o¿enie: znaleŸæ duble zdjêæ.

###Do uruchomienia bêdzie potrzebne:
**- VS 2019+ - ze wzglêdu na .Net Core 3.0
- MS SQL Server
- EventStore**

**Dzia³anie aplikacji**
1. PictureScan.Producer wrzuca informacje o przeskanowanych zdjêciach na kolejkê ES - móg³bym wrzucaæ te informacje prosto do bazy,
ale wykorzystujê do tego celu najpierw ES w ramach praktyki z tym narzêdziem. Mo¿na uruchomiæ kilka komponentów w celu szybszego
przeskanowania wszystkich zdjêæ
2. PictureScan.Consumer odczytuje event po evencie z ES i wrzuca odczytane eventy do bazy danych

###Uruchmienie aplikacji:###
1. pobraæ repozytorium.
2. stworzyæ bazê danych MS SQL Server
 - skonfigurowaæ appsettings.json w PictureScan.DBMigrator
 - uruchomiæ aplikacjê
3. stworzyæ subskrypcjê na ES
 - skonfigurowaæ appsettings.json w PictureScan.ESInit
 - uruchomiæ aplikacjê
4. zrobiæ skanowanie:
 - skonfigurowaæ appsettings.json w PictureScan.Producer
 - wykonaæ build PictureScan.Producer
 - uruchomiæ PictureScan.Producer - program powinien zacz¹æ przegl¹daæ, wskazany 
   w appsettings.json katalog, w poszukiwaniu plików *.png oraz *.jpg i wrzucaæ eventy 
   do EventStore

cdn....
