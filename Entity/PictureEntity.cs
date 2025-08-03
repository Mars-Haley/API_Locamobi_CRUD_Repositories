namespace Locamobi.Entity;

public class PictureEntity
{
    public int Id { get; set; }
    public string ArchiveName { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public DateTime CreatedIn { get; set; } = DateTime.Now;
}