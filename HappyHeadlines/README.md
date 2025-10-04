HappyHeadlines:

Dette projekt simulerer en caching-løsning for HappyHeadlines.
Formålet er at vise, hvordan to cache-lag kan forbedre ydeevne og reducere belastningen på databasen.


Funktioner:

- ArticleCache: Forhåndsindlæser artikler fra de seneste 14 dage (preload).  
- CommentCache Henter kommentarer ved cache-miss og gemmer de 30 senest tilgåede artikler (LRU-algoritme).  
- Dashborad: Viser løbende cache-hit-ratioer for begge caches i konsollen.

 
Kør projektet:

1. Tryk CTRL + f5 eller kør "dotnet run"
2 Se dashboardet opdatere cache-ydeevnen i realtid




