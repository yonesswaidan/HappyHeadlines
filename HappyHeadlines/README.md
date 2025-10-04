HappyHeadlines:

Dette projekt simulerer en caching-l�sning for HappyHeadlines.
Form�let er at vise, hvordan to cache-lag kan forbedre ydeevne og reducere belastningen p� databasen.


Funktioner:

- ArticleCache: Forh�ndsindl�ser artikler fra de seneste 14 dage (preload).  
- CommentCache Henter kommentarer ved cache-miss og gemmer de 30 senest tilg�ede artikler (LRU-algoritme).  
- Dashborad: Viser l�bende cache-hit-ratioer for begge caches i konsollen.

 
K�r projektet:

1. Tryk CTRL + f5 eller k�r "dotnet run"
2 Se dashboardet opdatere cache-ydeevnen i realtid




