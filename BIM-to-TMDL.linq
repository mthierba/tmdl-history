<Query Kind="Statements">
  <NuGetReference Version="19.86.2.1">Microsoft.AnalysisServices</NuGetReference>
  <Namespace>AMO = Microsoft.AnalysisServices</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Extensions</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Serialization</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Tmdl</Namespace>
  <Namespace>TOM = Microsoft.AnalysisServices.Tabular</Namespace>
</Query>

typeof(Microsoft.AnalysisServices.Tabular.TmdlSerializer).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Dump();
var bimPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "Contoso.bim").Dump("BIM Source");
var targetPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "TMDL").Dump("TMDL Destination");

var db = TOM.JsonSerializer.DeserializeDatabase(File.ReadAllText(bimPath), mode: AMO.CompatibilityMode.PowerBI);

MetadataSerializationOptions options = new MetadataSerializationOptionsBuilder(MetadataSerializationStyle.Tmdl)
	.WithChildrenMetadata()
	.WithInferredDataTypes()
	.WithoutRestrictedInformation()
	.WithExpressionTrimStyle(TmdlExpressionTrimStyle.TrimTrailingWhitespaces | TmdlExpressionTrimStyle.TrimLeadingCommonWhitespaces)
	.WithMetadataOrderHints()
	.WithFormattingOptions(new MetadataFormattingOptionsBuilder(MetadataSerializationStyle.Tmdl)
		.WithEncoding(Encoding.UTF8)
		.WithNewLineStyle(NewLineStyle.WindowsStyle)
		.WithTabsIndentationMode()
		.WithBaseIndentationLevel(0)
		.WithCasingStyle(TmdlCasingStyle.CamelCase)
		.GetOptions())
	.WithCompatibilityOptions(new MetadataCompatibilityOptionsBuilder()
		.WithTargetCompatibilityMode(Microsoft.AnalysisServices.CompatibilityMode.PowerBI)
		.WithTargetCompatibilityLevel(1606)
		.GetOptions())
	.GetOptions();
	
options.Dump("Serialization Options");
		
TOM.TmdlSerializer.SerializeDatabaseToFolder(db, targetPath, options);

// Verify:
TOM.TmdlSerializer.DeserializeDatabaseFromFolder(targetPath).Dump();