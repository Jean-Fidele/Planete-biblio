﻿- Faire la migration avec le mapping
- dotnet ef migrations add initial101 --startup-project "../bibliotheque/Bibliotheque.csproj"
- dotnet ef database update --startup-project "../bibliotheque/Bibliotheque.csproj"
- git revert commit-name : ca poiinte vert le commit avant commit-name
- git reset --soft --Head~1 : ca supprime le dernier commit et laisse les derniers changements avant le commit