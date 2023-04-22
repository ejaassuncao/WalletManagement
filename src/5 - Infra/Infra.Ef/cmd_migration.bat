REM VISUAL STUDIO -> MENU TOOLS -> NuGet Package Manager -> Package Manager Console (OBS.: ESCOLHER O PROJETO REPOSITORY no combobox)

REM  ******CODE_FIRST******
Add-Migration InitialCreate -s Presentation.Api
Update-Database -s Presentation.Api

REM ******DB_FIRST******
REM link templace class: https://learn.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding/templates?tabs=dotnet-core-cli
Scaffold-DbContext "Data Source=localhost,1433;Initial Catalog=sicof;User ID=sa_root;Password=Ej@210785;Integrated Security=False;MultipleActiveResultSets=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EntityData -ContextDir Context -Context -DataAnnotations "AppDBContext" -Tables dbo.wallet, tb_sector -Force

