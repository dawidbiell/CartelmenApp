# Tworzenie nowej migracji
dotnet ef migrations add XXXXX --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext -v

# Usowane ostatniej migracji
dotnet ef migrations remove --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext

# lista migracji
dotnet ef migrations list --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext

# Aktualizacja bazy danych do najnowszej migracji
dotnet ef database update --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext -v

# Aktualizacja bazy danych do konkretnej migracji
dotnet ef database update XXXXX --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext

# Usuwanie bazy danych
dotnet ef database drop --project Cartelmen.Infrastructure --startup-project Cartelmen.Server --context CartelmenDbContext -v