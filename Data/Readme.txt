﻿- Faire la migration avec le mapping
- dotnet ef migrations add create-table-eventdatasource --startup-project "../Hosts/EventCenter/EventCenter.csproj"
- dotnet ef database update --startup-project "../Hosts/EventCenter/EventCenter.csproj"