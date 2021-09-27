Remarks for using FluentEmail library:

1. To be able to use templates by Razor engine, the following property must be added under PropertyGroup in the consuming csproj:
    <PreserveCompilationReferences>true</PreserveCompilationReferences>
    in addition, according to this video https://www.youtube.com/watch?v=qSeO9886nRM in 20:49 one should also add <PreserveCompilationContext>true</PreserveCompilationContext>
    Check is it'd be still necessary after upgrading to .NET Core 5.0.
