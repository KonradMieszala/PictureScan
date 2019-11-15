# PictureScan

##G��wne za�o�enie: znale�� duble zdj��.

###Do uruchomienia b�dzie potrzebne:
**- VS 2019+ - ze wzgl�du na .Net Core 3.0
- MS SQL Server
- EventStore**

**Dzia�anie aplikacji**
1. PictureScan.Producer wrzuca informacje o przeskanowanych zdj�ciach na kolejk� ES - m�g�bym wrzuca� te informacje prosto do bazy,
ale wykorzystuj� do tego celu najpierw ES w ramach praktyki z tym narz�dziem. Mo�na uruchomi� kilka komponent�w w celu szybszego
przeskanowania wszystkich zdj��
2. PictureScan.Consumer odczytuje event po evencie z ES i wrzuca odczytane eventy do bazy danych

###Uruchmienie aplikacji:###
1. pobra� repozytorium.
2. stworzy� baz� danych MS SQL Server
 - skonfigurowa� appsettings.json w PictureScan.DBMigrator
 - uruchomi� aplikacj�
3. stworzy� subskrypcj� na ES
 - skonfigurowa� appsettings.json w PictureScan.ESInit
 - uruchomi� aplikacj�
4. zrobi� skanowanie:
 - skonfigurowa� appsettings.json w PictureScan.Producer
 - wykona� build PictureScan.Producer
 - uruchomi� PictureScan.Producer - program powinien zacz�� przegl�da�, wskazany 
   w appsettings.json katalog, w poszukiwaniu plik�w *.png oraz *.jpg i wrzuca� eventy 
   do EventStore

cdn....
