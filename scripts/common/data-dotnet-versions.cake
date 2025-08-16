Dictionary<string, string> dotnet_versions = new()
    {
        {
            "net8_0",
            """
            {
                "sdk":
                {
                    "version": "8.0.407",
                    "rollForward": "patch"
                },
                "msbuild-sdks":
                {
                    "MSBuild.Sdk.Extras": "3.0.44",
                    "Microsoft.Build.Traversal": "4.1.82",
                    "Microsoft.Build.NoTargets": "3.7.56",
                    "Xamarin.Legacy.Sdk": "0.2.0-alpha4"
                }
            }
            """
        },
        {
            "net9_0",
            """
            {
                "sdk":
                {
                "version": "9.0.201",
                "rollForward": "patch"
                },
                "msbuild-sdks":
                {
                    "MSBuild.Sdk.Extras": "3.0.44",
                    "Microsoft.Build.Traversal": "4.1.82",
                    "Microsoft.Build.NoTargets": "3.7.56",
                    "Xamarin.Legacy.Sdk": "0.2.0-alpha4"
                }
            }
            """
        },
        {
            "net10_0",
            """
            {
                "sdk":
                {
                "version": "10.0.100-preview.1.25120.13",
                "rollForward": "patch",
                "allowPrerelease": true
                },
                "msbuild-sdks":
                {
                    "MSBuild.Sdk.Extras": "3.0.44",
                    "Microsoft.Build.Traversal": "4.1.82",
                    "Microsoft.Build.NoTargets": "3.7.56",
                    "Xamarin.Legacy.Sdk": "0.2.0-alpha4"
                }
            }
            """
        },
    };
