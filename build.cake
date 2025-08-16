// https://www.nuget.org/packages/Cake.CoreCLR
//  Cake.CoreCLR add to ./tools/ folder for debugging
#addin nuget:?package=Cake.FileHelpers&version=7.0.0

//---------------------------------------------------------------------------------------
// unit testing
#tool nuget:?package=NUnit.ConsoleRunner&version=3.17.0
#tool nuget:?package=xunit.runner.console&version=2.7.0
//---------------------------------------------------------------------------------------
// coverage
#tool nuget:?package=OpenCover&version=4.7.1221
// dotCover is commercial
// #tool "nuget:?package=JetBrains.dotCover.CommandLineTools"
//---------------------------------------------------------------------------------------
// reporting
#tool nuget:?package=ReportUnit&version=1.5.0-beta1&prerelease
#tool nuget:?package=ReportGenerator&version=5.2.1

#load "./externals-data.cake"

//---------------------------------------------------------------------------------------
string TARGET = Argument ("t", Argument ("target", "Default"));
string verbosity = Argument ("v", Argument ("verbosity", "diagnostic"));

verbosity= "normal";

string source_solutions                             = $"./source/**/*.sln";
string source_projects                              = $"./source/**/*.csproj";
string samples_solutions                            = $"./samples/**/*.sln";
string samples_projects                             = $"./samples/**/*.csproj";
string samples_scripts_interactive_csharp_cake      = $"./samples/**/*.cake";
string externals_scripts_interactive_csharp_cake    = $"./externals/**/*.cake";
string samples_cake_scripts                         = $"./samples/**/*.cake";
string tests_cake_scripts                           = $"./tests/**/*.cake";
string data_cake_scripts                           = $"./data/**/*.cake";

FilePathCollection LibrarySourceSolutions                   = GetFiles(source_solutions);
FilePathCollection LibrarySourceProjects                    = GetFiles(source_projects);

FilePathCollection SamplesSolutions                         = GetFiles(samples_solutions);
FilePathCollection SamplesScriptsInteractiveCsharpCake      = GetFiles(samples_solutions);
FilePathCollection SamplesProjects                          = GetFiles(samples_projects);

string[] configurations = new string[]
{
    "Debug",
    "Release",
};

string[] clean_folder_patterns = new string[]
{
    "./externals/",
    "./output/",
    "./**/.vs/",
    "./**/.idea/",
    "./**/*-packages/",
    "./**/.mfractor/",
    "./source/**/bin/",
    "./source/**/obj/",
    "./source/**/packages/",
    "./samples/**/bin/",
    "./samples/**/obj/",
    "./samples/**/packages/",
    "./samples/**/tools/",
    "./tests/**/bin/",
    "./tests/**/obj/",
    "./tests/**/packages/",
    "./tests/**/tools/",
};


string[] clean_file_patterns = new string[]
{
    "./**/*.binlog",
    "./**/.DS_Store",
};

readonly string line_hash    = new string('#', 120);
readonly string line_equal   = new string('=', 120);
readonly string line_dash    = new string('-', 120);
readonly string line_dot     = new string('.', 120);

#load "./scripts/common/externals.cake"
#load "./scripts/private-protected-sensitive/externals.private.cake"
#load "./scripts/common/main.cake"
#load "./scripts/common/nuget-restore.cake"
#load "./scripts/common/nuget-pack.cake"
#load "./scripts/common/libs.cake"
#load "./scripts/common/samples.cake"
#load "./scripts/common/tests-unit-tests.cake"


// FilePathCollection UnitTestsNUnitMobileProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.Xamarin*.csproj");
// FilePathCollection UnitTestsXUnitProjects = GetFiles($"./tests/unit-tests/project-references/**/*.XUnit.csproj");
// FilePathCollection UnitTestsMSTestProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.csproj");


Task("Default")
.Does
    (
        () =>
        {
            RunTarget("unit-tests");
            RunTarget("nuget-pack");
            RunTarget("samples");

            return;
        }
    );

RunTarget (TARGET);

if( ! IsRunningOnWindows())
{
    try
    {
        int exit_code = StartProcess
                                (
                                    "tree",
                                    new ProcessSettings
                                    {
                                        Arguments = @"-h ./output"
                                    }
                                );
    }
    catch(Exception ex)
    {
        Information($"unable to start process - tree {ex.Message}");
    }
}
else
{
    // int exit_code = StartProcess
    //                         (
    //                             "dir",
    //                             new ProcessSettings
    //                             {
    //                                 Arguments = @"output"
    //                             }
    //                         );

}
