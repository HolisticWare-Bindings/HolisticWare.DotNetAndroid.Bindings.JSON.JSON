Project Improvement Plan for HolisticWare.DotNetAndroid.Bindings.JSON.JSON
Date: 2025-08-21

1. Overview
This document proposes a detailed improvement plan for the .NET Android binding project that wraps the org.json Java library. The plan groups improvements by theme and explains the rationale for each proposed change. It is intended to enhance API quality, reliability, packaging, and maintainability while minimizing risk.

2. Source and Assumptions
- Intended source document: docs/requirements.md. Status: Not found in repository at the time of writing.
- This plan is provisional and based on:
  - Inspection of the repository layout and project files.
  - Common goals and constraints for Android Java binding libraries targeting .NET.
  - Observed configuration in the .csproj and Transform files.
- When docs/requirements.md becomes available, update this plan to align precisely with the stated goals and constraints. All items marked [TO VERIFY] should be validated against that document.

3. Extracted Key Goals (Provisional)
- Provide a high-quality, idiomatic .NET binding for the org.json Java library to be consumed in Android apps. [TO VERIFY]
- Keep parity with upstream API versions while following .NET naming and design guidelines to improve developer experience. [TO VERIFY]
- Deliver as a NuGet package with predictable, reproducible builds and semantic versioning aligned with upstream. [TO VERIFY]
- Ensure compatibility with modern Android API levels and .NET for Android toolchains. [TO VERIFY]
- Maintain small footprint and linker friendliness to minimize app size and startup time. [TO VERIFY]

4. Extracted Key Constraints (Provisional)
- API surface must remain functionally consistent with upstream org.json to avoid breaking consumers’ expectations. [TO VERIFY]
- Respect upstream licensing and attribution requirements. [TO VERIFY]
- Avoid exposing Java-only patterns or leaky abstractions that are awkward in C# (e.g., vague Object returns, ambiguous overloads). [TO VERIFY]
- Support the targeted .NET runtime (currently net9.0-android) and minimum Android API (SupportedOSPlatformVersion=21) unless requirements specify otherwise. [TO VERIFY]
- Ensure builds are deterministic and CI-friendly; avoid reliance on local environment assumptions. [TO VERIFY]

5. Repository Observations (Facts from Current Codebase)
- Target Framework: net9.0-android (HolisticWare.DotNetAndroid.Bindings.JSON.JSON.csproj, line 3).
- SupportedOSPlatformVersion: 21 (Android 5.0 Lollipop) (line 4).
- Nullable: enable (line 5).
- IsTrimmable: true (line 10), indicating intent to be linker/trimmer friendly.
- Versioning:
  - VersionPrefix: 2025.01.07 (line 17) — resembles upstream snapshot date versioning.
  - PackageVersion uses $(Version) (line 22); ensure overall version resolves correctly.
- External artifacts:
  - external/json-20250107.jar present — likely the upstream org.json drop for 2025-01-07.
  - external/json-20250517.jar_remove present (appears to be a removed/placeholder file; consider cleanup).
- Transform files:
  - Transforms/Metadata.Namespaces.xml maps org.json to HolisticWare.DotNetAndroid.Bindings.JSON namespace.
  - Transforms/Metadata.xml contains an attr mapping for ai.picovoice.picollm to HolisticWare.AI.Picovoice.PicoLLM — likely a leftover and unrelated to org.json; may need cleanup.
  - EnumFields.xml and EnumMethods.xml currently contain only commented examples, no active mappings.

6. Improvement Plan by Theme (with Rationale)

6.1 Binding Surface and API Quality
Rationale: Ensure a clean, idiomatic C# API that matches upstream functionality while improving discoverability and usability.
Actions:
- Audit generated classes for ambiguous overloads, use of raw Object, and Java-centric naming. Where safe, apply Metadata.xml/Transforms to improve names and overload clarity. [TO VERIFY]
- Ensure exceptions are mapped to meaningful .NET exceptions where appropriate (e.g., JSONException). [TO VERIFY]
- Confirm nullable annotations propagate to public C# surface (Nullable enabled). Adjust with metadata where necessary. [TO VERIFY]
- Hide non-applicable members (Java-only constructs) to reduce confusion. [TO VERIFY]

6.2 Namespaces and Metadata Hygiene
Rationale: Consistent namespaces improve developer expectations and avoid collisions.
Actions:
- Keep org.json mapped to HolisticWare.DotNetAndroid.Bindings.JSON (already configured). ✓
- Remove unrelated or stale mappings from Transforms/Metadata.xml (e.g., ai.picovoice.picollm) to avoid confusion and incorrect renames. [TO VERIFY]
- Maintain a minimal, documented Metadata.xml that only includes relevant renames/hides for org.json.

6.3 Build, Versioning, and Packaging
Rationale: Predictable, reproducible builds and correctly versioned packages reduce integration risk.
Actions:
- Ensure Version is computed from VersionPrefix (+ optional VersionSuffix) and that PackageVersion resolves correctly in CI. [TO VERIFY]
- Align package versioning strategy with upstream org.json releases (date-version scheme appears in use). Document the strategy in README and this plan. [TO VERIFY]
- Enable/verify deterministic builds and SourceLink for debugging. [TO VERIFY]
- Add NuGet metadata completeness: Authors, License, ProjectUrl, RepositoryUrl, Description, Tags, etc. [TO VERIFY]
- Clean up external/ to only include the chosen upstream artifact (remove *_remove files). [TO VERIFY]

6.4 Targeting and Compatibility
Rationale: Ensure compatibility with current Android and .NET for Android.
Actions:
- Validate whether min supported Android version (21) meets requirements; consider raising if justified by org.json or platform support. [TO VERIFY]
- Confirm compatibility with the latest stable .NET for Android toolchain; document required workloads and versions. [TO VERIFY]
- If upstream ships AAR features/resources (not typical for org.json), ensure proper packaging; otherwise keep JAR-only simple path. ✓

6.5 Performance, Trimming, and Linker
Rationale: Maintain small footprint and safe trimming behavior.
Actions:
- With IsTrimmable=true, review public surface to ensure no required members are trimmed at runtime. Add [Preserve] attributes or linker descriptors only where needed. [TO VERIFY]
- Avoid reflection-dependent patterns in samples and documentation. [TO VERIFY]
- Validate that release builds under full linking succeed and sample apps run. [TO VERIFY]

6.6 Testing and CI
Rationale: Catch regressions, especially when updating the upstream JAR.
Actions:
- Create minimal unit tests that exercise key org.json APIs (JSONObject, JSONArray, JSONTokener). [TO VERIFY]
- Provide a tiny sample Android app to validate integration and linker settings. [TO VERIFY]
- Set up CI (e.g., GitHub Actions/Azure DevOps) to build the project, run tests, and (optionally) run a signature/API diff check between releases. [TO VERIFY]

6.7 Documentation and Samples
Rationale: Improve developer onboarding and support.
Actions:
- Add a README with Quickstart, supported versions, and notes on differences from upstream Java usage. [TO VERIFY]
- Generate or curate XML documentation summaries; consider importing Javadoc where feasible. [TO VERIFY]
- Maintain a CHANGELOG for version bumps, especially when mapping changes affect API.
- Provide a simple sample demonstrating JSONObject/JSONArray usage in an Android app. [TO VERIFY]

6.8 Security, Licensing, and Compliance
Rationale: Ensure license compliance and supply-chain trust.
Actions:
- Verify upstream org.json license; include LICENSE and third-party notices as required. [TO VERIFY]
- Consider generating SBOM in CI for releases (e.g., CycloneDX). [TO VERIFY]
- If organizationally required, sign assemblies/NuGets. [TO VERIFY]

6.9 Release and Maintenance
Rationale: Predictable updates and community health.
Actions:
- Document a release checklist: update external jar, bump VersionPrefix, run tests, update changelog, publish package. [TO VERIFY]
- Create issue/PR templates and contribution guidelines if accepting external contributions. [TO VERIFY]
- Define support policy (e.g., supported Android API levels, .NET versions). [TO VERIFY]

7. Rationale Summary
- API quality improvements reduce developer friction and support burden.
- Metadata hygiene prevents accidental misnaming and keeps the binding focused on org.json.
- Strong versioning and CI practices create trust and enable safe, repeatable releases.
- Targeting and linker attention keep the library usable across a wide range of Android devices while maintaining small app size.
- Documentation and samples accelerate adoption and make maintenance sustainable.

8. Acceptance Criteria
- The project builds successfully in CI with deterministic settings. [TO VERIFY]
- A NuGet package can be produced with complete metadata. [TO VERIFY]
- Basic tests pass and a sample app runs using JSONObject/JSONArray without runtime/linker issues. [TO VERIFY]
- Documentation exists: README, this plan, and CHANGELOG. [TO VERIFY]
- No stale or unrelated transform entries remain. [TO VERIFY]

9. Open Questions and Next Steps
- Provide docs/requirements.md so this plan can be reconciled with official goals/constraints.
- Confirm intended min/max Android API levels and .NET versions.
- Confirm versioning scheme and alignment with upstream org.json releases.
- Confirm licensing and distribution requirements (e.g., signing, internal feeds).
- After confirmation, prioritize the actions above into short-, mid-, and long-term backlogs and convert them into tracked issues.
