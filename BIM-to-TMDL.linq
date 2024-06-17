<Query Kind="Statements">
  <NuGetReference Version="19.76.0">Microsoft.AnalysisServices.NetCore.retail.amd64</NuGetReference>
  <Namespace>AMO = Microsoft.AnalysisServices</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Serialization</Namespace>
  <Namespace>TOM = Microsoft.AnalysisServices.Tabular</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Extensions</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Tmdl</Namespace>
</Query>

typeof(Microsoft.AnalysisServices.Tabular.TmdlSerializer).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion.Dump();
var bimPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "Contoso.bim").Dump("BIM Source");
var targetPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "TMDL").Dump("TMDL Destination");

var db = TOM.JsonSerializer.DeserializeDatabase(File.ReadAllText(bimPath), mode: AMO.CompatibilityMode.PowerBI);

MetadataSerializationOptions options = new MetadataSerializationOptionsBuilder(MetadataSerializationStyle.Tmdl)
	.WithChildrenMetadata()
	.WithoutRestrictedInformation()
	.WithExpressionTrimStyle(TmdlExpressionTrimStyle.TrimTrailingWhitespaces | TmdlExpressionTrimStyle.TrimLeadingCommonWhitespaces)
	.WithFormattingOptions(new MetadataFormattingOptionsBuilder(MetadataSerializationStyle.Tmdl)
		.WithEncoding(Encoding.UTF8)
		.WithNewLineStyle(NewLineStyle.WindowsStyle)
		.WithTabsIndentationMode()
		.WithBaseIndentationLevel(0)
		.WithCasingStyle(TmdlCasingStyle.CamelCase)
		.GetOptions())
	.GetOptions();
	
options.Dump("Serialization Options");
		
TOM.TmdlSerializer.SerializeDatabaseToFolder(db, options, targetPath);

// Verify:
TOM.TmdlSerializer.DeserializeDatabaseFromFolder(targetPath).Dump();
