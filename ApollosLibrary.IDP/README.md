dotnet ef migrations add InitialCreate -s ApollosLibrary.IDP -p ApollosLibrary.IDP.Domain --context ApollosLibraryIDPContext

dotnet ef database update -s ApollosLibrary.IDP -p ApollosLibrary.IDP.Domain --context ApollosLibraryIDPContext