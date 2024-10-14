# Tabular Model Definition Language (TMDL)

TMDL is Microsoft's new language for defining tabular models for Analysis Services and Power BI. It targets professional developers and is designed to be human-readable and editable in any text editor. Furthermore, TMDL projects work well with source control and collaborative workflows.

TMDL is currently in Public Preview.

* [TMDL Overview](https://pbi.onl/tmdl-docs)

## TMDL History

| TOM Version                                                                                             | TMDL Release                                                     | Max CompatLevel | Date        | TE / pbi-tools | Notes |
| ------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- | --------------- | ----------- | -------------- | ----- |
| [19.86.2.1](https://www.nuget.org/packages/Microsoft.AnalysisServices/19.86.2.1)                        | [Oct-2024](https://github.com/mthierba/tmdl-history/pull/19)     | 1608            |  9-Oct-2024 | TBD | Adds `MetadataSerializationOptions.IncludeInferredDataTypes` |
| [19.84.10](https://www.nuget.org/packages/Microsoft.AnalysisServices/19.84.10)                          | [Sep-2024](https://github.com/mthierba/tmdl-history/pull/18)     | 1608            |  3-Sep-2024 | TBD | Adds `DataBindingHint` (1608) |
| [19.84.6](https://www.nuget.org/packages/Microsoft.AnalysisServices/19.84.6)                            | [GA](https://github.com/mthierba/tmdl-history/pull/17)           | 1606            |  1-Aug-2024 | NA / [1.1.1](https://github.com/pbi-tools/pbi-tools/releases/tag/1.1.1) | NuGet package renamed as `Microsoft.AnalysisServices` |
| [19.84.1](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.84.1)       | [Preview-15](https://github.com/mthierba/tmdl-history/pull/16)   | 1606            |  2-Jul-2024 | [2.25.0](https://github.com/TabularEditor/TabularEditor/releases/tag/2.25) / [1.0.1](https://github.com/pbi-tools/pbi-tools/releases/tag/1.0.1) |
| [19.82.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.82.0)       | [Preview-14](https://github.com/mthierba/tmdl-history/pull/15)   | 1606            | 11-Jun-2024 | NA |
| [19.80.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.80.0)       | [Preview-13](https://github.com/mthierba/tmdl-history/pull/14)   | 1606            |  7-May-2024 | NA |
| [19.79.1.1](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.79.1.1)   | [Preview-12](https://github.com/mthierba/tmdl-history/pull/13)   | 1606            | 12-Apr-2024 | [2.24.1](https://github.com/TabularEditor/TabularEditor/releases/tag/2.24.1) / NA |
| [19.77.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.77.0)       | [Preview-11](https://github.com/mthierba/tmdl-history/pull/12)   | 1606            | 15-Mar-2024 | [2.24.0](https://github.com/TabularEditor/TabularEditor/releases/tag/2.24.0) / NA |
| [19.76.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.76.0)       | [Preview-10](https://github.com/mthierba/tmdl-history/pull/11)   | 1606            |  2-Feb-2024 |  | Minor API Change: `MetadataFormattingOptions.IndentationSize` _(was: 'IndentationLevelLength')_ |
| [19.74.2](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.74.2)       | [Preview-9](https://github.com/mthierba/tmdl-history/pull/10)    | 1606            |  4-Jan-2024 | [2.22.0](https://github.com/TabularEditor/TabularEditor/releases/tag/2.22.0) / [1.0.0-rc.8](https://github.com/pbi-tools/pbi-tools/releases/tag/1.0.0-rc.8) |
| [19.72.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.NetCore.retail.amd64/19.72.0)       | [Preview-8](https://github.com/mthierba/tmdl-history/pull/9)     | 1605            |  8-Dec-2023 |   | BREAKING: Dropped separate TMDL NuGet packages (merged into main TOM DLL); Serialization Options |
| [19.69.6.2](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.69.6.2-TmdlPreview)   | [Preview-7](https://github.com/mthierba/tmdl-history/pull/7) | 1605            |  6-Nov-2023 | 2.21.1 / 1.0.0-rc.7 |
| [19.69.2.2](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.69.2.2-TmdlPreview)   | [Preview-6](https://github.com/mthierba/tmdl-history/pull/6) | 1604            | 16-Oct-2023 |
| [19.67.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.67.0-TmdlPreview)       | [Preview-5](https://github.com/mthierba/tmdl-history/pull/5) | 1604            |  5-Sep-2023 | 2.20.2 / 1.0.0-rc.5 |
| [19.65.12.3](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.65.12.3-TmdlPreview) | [Preview-4](https://github.com/mthierba/tmdl-history/pull/4) | 1604            | 15-Aug-2023 |
| [19.65.7.2](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.65.7.2-TmdlPreview)   | [Preview-3](https://github.com/mthierba/tmdl-history/pull/3) | 1604            |  6-Jul-2023 |
| [19.65.4](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.65.4-TmdlPreview)       | --                                                           | 1604            |  8-Jun-2023 | 2.19.0 / 1.0.0-rc.5+preview.1 | _no TMDL updates_ |
| [19.64.0](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.64.0-TmdlPreview)       | [Preview-2](https://github.com/mthierba/tmdl-history/pull/2) | 1604            |  5-May-2023 | 2.18.2 / 1.0.0-rc.4 |
| [19.61.1.4](https://www.nuget.org/packages/Microsoft.AnalysisServices.Tabular.Tmdl.NetCore.retail.amd64/19.61.1.4-TmdlPreview)   | [Preview-1](https://github.com/mthierba/tmdl-history/pull/1) | 1604            | 10-Apr-2023 | 2.18.1 / 1.0.0-rc.3 |
