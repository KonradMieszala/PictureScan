# PictureScan

G��wne za�o�enie: znale�� duble zdj��.

Do uruchomienia b�dzie potrzebne:
- VS 2019+ - ze wzgl�du na .Net Core 3.0
- MS SQL Server
- EventStore

Uruchmienie aplikacji:
1. pobra� repozytorium.
2. stworzy� baz� danych MS SQL Server
 - skonfigurowa� appsettings.json w PictureScan.DBMigrator
 - uruchomi� aplikacj�
3. zrobi� skanowanie:
 - skonfigurowa� appsettings.json w PictureScan.Producer
 - wykona� build PictureScan.Producer
 - uruchomi� PictureScan.Producer - program powinien zacz�� przegl�da�, wskazany 
   w appsettings.json katalog, w poszukiwaniu plik�w *.png oraz *.jpg i wrzuca� eventy 
   do EventStore

cdn....
