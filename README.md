# PictureScan

G³ówne za³o¿enie: znaleŸæ duble zdjêæ.

Do uruchomienia bêdzie potrzebne:
- VS 2019+ - ze wzglêdu na .Net Core 3.0
- MS SQL Server
- EventStore

Uruchmienie aplikacji:
1. pobraæ repozytorium.
2. stworzyæ bazê danych MS SQL Server
 - skonfigurowaæ appsettings.json w PictureScan.DBMigrator
 - uruchomiæ aplikacjê
3. zrobiæ skanowanie:
 - skonfigurowaæ appsettings.json w PictureScan.Producer
 - wykonaæ build PictureScan.Producer
 - uruchomiæ PictureScan.Producer - program powinien zacz¹æ przegl¹daæ, wskazany 
   w appsettings.json katalog, w poszukiwaniu plików *.png oraz *.jpg i wrzucaæ eventy 
   do EventStore

cdn....
