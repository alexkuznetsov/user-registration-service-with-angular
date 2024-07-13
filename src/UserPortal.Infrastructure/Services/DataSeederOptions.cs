namespace UserPortal.Infrastructure.Services;

internal class DataSeederOptions
{
    public bool Enabled { get; set; } = false;
    public string SeedFile { get; set; } = null!;
}
