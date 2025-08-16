#load "./nuget-restore.cake"

using Spectre.Console;

SamplesSolutions                        = GetFiles(samples_solutions);
SamplesProjects                         = GetFiles(samples_projects);
SamplesScriptsInteractiveCsharpCake     = GetFiles(samples_scripts_interactive_csharp_cake);

//---------------------------------------------------------------------------------------
Task("samples")
    .IsDependentOn ("samples-solutions")
    .IsDependentOn ("samples-projects")
    .IsDependentOn ("samples-scripts-interactive-csharp-cake")
    ;

// Task("samples-solutions")
//     .IsDependentOn ("samples-soultions-with-dependencies-project")
//     .IsDependentOn ("samples-soultions-with-dependencies-nuget")
//     ;

// Task("samples-projects")
//     .IsDependentOn ("samples-with-dependencies-project")
//     .IsDependentOn ("samples-with-dependencies-nuget")
//     ;

// Task("samples-project")
//     .IsDependentOn ("libs")
//     ;

// // compile samples with nuget
// Task("samples-with-dependencies-nuget")
//     .IsDependentOn ("libs")
//     ;

DotNetBuildSettings dotnet_settings = new DotNetBuildSettings
                                                {
                                                    Configuration = "Release",
                                                };
//----------------------------------------------------------------------------------------------------------------------
Task("samples-solutions")
    .Does
    (
        () =>
        {
            FilePathCollection files = SamplesSolutions;

            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Sample solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug"))
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
Task("samples-projects")
    .Does
    (
        () =>
        {
            FilePathCollection files = SamplesProjects;

            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Sample solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");
 
                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug"))
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
Task("samples-scripts-interactive-csharp-cake")
    .Does
    (
        () =>
        {
            FilePathCollection files = SamplesScriptsInteractiveCsharpCake;
            foreach(FilePath file in files)
            {
                AnsiConsole.MarkupLine($"{line_hash}");
                AnsiConsole.MarkupLine($"[bold aqua] Sample solution[/]");
                AnsiConsole.MarkupLine($"       [aqua]{file}[/]");

                foreach (string configuration in configurations)
                {
                    if (! BuildSystem.IsLocalBuild && configuration.Equals("Debug"))
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
