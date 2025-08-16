#load "./nuget-restore.cake"

using Spectre.Console;

SamplesSolutions                        = GetFiles(samples_solutions);
SamplesScriptsInteractiveCsharpCake     = GetFiles(samples_scripts_interactive_csharp_cake);

//---------------------------------------------------------------------------------------
Task("data")
    ;

Task("samples-scripts-interactive-csharp-cake")
    .Does
    (
        () =>
        {
            FilePathCollection files = GetFiles("./samples/**/*.cake");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                try
                {
                    CakeExecuteScript
                        (
                            file,
                            new CakeSettings
                            {
                                Verbosity = Verbosity.Diagnostic,
                                Arguments = new Dictionary<string, string>()
                                {
                                    { "verbosity",  verbosity},
                                    { "target",     "nuget-pack"},
                                },
                            }
                        );
                }
                catch
                {
                    Error ("Build/Run failed File: {0}", file);
                }
            }

            return;
        }
    );

//---------------------------------------------------------------------------------------
