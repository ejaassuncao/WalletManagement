﻿REM VISUAL STUDIO -> MENU TOOLS -> NuGet Package Manager -> Package Manager Console (OBS.: ESCOLHER O PROJETO REPOSITORY no combobox)

REM  ******CODE_FIRST******
Add-Migration InitialCreate
Update-Database

REM ******DB_FIRST******
Scaffold-DbContext "Data Source=.\\;Initial Catalog=sicof;User ID=sa_root;Password=Ej@210785;Integrated Security=False;MultipleActiveResultSets=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EntityData -ContextDir Context -Context "AppDBContext" -Tables dbo.wallet -Force
