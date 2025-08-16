#load "./nuget-restore.cake"

LibrarySourceSolutions  = GetFiles(source_solutions);
LibrarySourceProjects   = GetFiles(source_projects);

//----------------------------------------------------------------------------------------------------------------------
Task("libs")
    .IsDependentOn ("nuget-restore-libs")
    .IsDependentOn ("libs-msbuild-solutions")
    .IsDependentOn ("libs-msbuild-projects")
    .IsDependentOn ("libs-dotnet-solutions")
    .IsDependentOn ("libs-dotnet-projects")
    ;

//----------------------------------------------------------------------------------------------------------------------
Task("libs-dotnet-solutions")
    .Does
    (
        () =>
        {
            FilePathCollection files = LibrarySourceSolutions;
            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Library solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    dotnet_settings.Configuration = configuration;

                    try
                    {
                        DotNetClean($"{file}");
                        DotNetBuild($"{file}", dotnet_settings);
                    }    
                    catch(Exception exc)
                    {
                        AnsiConsole.MarkupLine($"[bold red] Error[/]");
                        AnsiConsole.MarkupLine($"       [red] file      : {file}[/]");
                        AnsiConsole.MarkupLine($"       [red] exception : {exc.Message}[/]");
                    }
                }
            }

            return;
        }
    );
//----------------------------------------------------------------------------------------------------------------------
Task("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            FilePathCollection files = LibrarySourceProjects;
            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Library solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    dotnet_settings.Configuration = configuration;

                    try
                    {
                        DotNetClean($"{file}");
                        DotNetBuild($"{file}", dotnet_settings);
                    }    
                    catch(Exception exc)
                    {
                        AnsiConsole.MarkupLine($"[bold red] Error[/]");
                        AnsiConsole.MarkupLine($"       [red] file      : {file}[/]");
                        AnsiConsole.MarkupLine($"       [red] exception : {exc.Message}[/]");
                    }
                }
            }

            return;
        }
    );
//----------------------------------------------------------------------------------------------------------------------

Task("libs-msbuild-solutions")
    .Does
    (
        () =>
        {
            FilePathCollection files = LibrarySourceSolutions;
            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Library solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    dotnet_settings.Configuration = configuration;

                    try
                    {
                        DotNetClean($"{file}");
                        DotNetBuild($"{file}", dotnet_settings);
                    }    
                    catch(Exception exc)
                    {
                        AnsiConsole.MarkupLine($"[bold red] Error[/]");
                        AnsiConsole.MarkupLine($"       [red] file      : {file}[/]");
                        AnsiConsole.MarkupLine($"       [red] exception : {exc.Message}[/]");
                    }
                }
            }

            return;
        }
    );


Task("libs-msbuild-projects")
    .Does
    (
        () =>
        {
            FilePathCollection files = LibrarySourceProjects;
            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Library project[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    dotnet_settings.Configuration = configuration;

                    try
                    {
                        DotNetClean($"{file}");
                        DotNetBuild($"{file}", dotnet_settings);
                    }    
                    catch(Exception exc)
                    {
                        AnsiConsole.MarkupLine($"[bold red] Error[/]");
                        AnsiConsole.MarkupLine($"       [red] file      : {file}[/]");
                        AnsiConsole.MarkupLine($"       [red] exception : {exc.Message}[/]");
                    }
                }
            }

            return;
        }
    );
//---------------------------------------------------------------------------------------
