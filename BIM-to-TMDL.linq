<Query Kind="Statements">
  <NuGetReference Version="19.76.0">Microsoft.AnalysisServices.NetCore.retail.amd64</NuGetReference>
  <Namespace>AMO = Microsoft.AnalysisServices</Namespace>
  <Namespace>Microsoft.AnalysisServices.Tabular.Serialization</Namespace>
  <Namespace>TOM = Microsoft.AnalysisServices.Tabular</Namespace>
</Query>

var bimPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "Contoso.bim").Dump("BIM Source");
var targetPath = Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "TMDL").Dump("TMDL Destination");

var db = TOM.JsonSerializer.DeserializeDatabase(File.ReadAllText(bimPath), mode: AMO.CompatibilityMode.PowerBI);

MetadataSerializationOptions options = new MetadataSerializationOptionsBuilder(MetadataSerializationStyle.Tmdl)
	.WithChildrenMetadata()
	.WithoutRestrictedInformation()
	.WithFormattingOptions(new MetadataFormattingOptionsBuilder()
		.WithEncoding(Encoding.UTF8)
		.WithNewLineStyle(NewLineStyle.WindowsStyle)
		.WithSpacesIndentationMode(2)
		.WithTabsIndentationMode()
		.GetOptions())
	.GetOptions();
	
options.Dump("Serialization Options");
		
TOM.TmdlSerializer.SerializeDatabaseToFolder(db, options, targetPath);

// Verify:
TOM.TmdlSerializer.DeserializeDatabaseFromFolder(targetPath).Dump();
