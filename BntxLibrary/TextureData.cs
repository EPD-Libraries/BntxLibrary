namespace BntxLibrary;

public sealed class TextureData
{
    public List<byte[]> MipMapLevels { get; set; }

    public TextureData()
    {
        MipMapLevels = [];
    }
    
    public TextureData(int capacity)
    {
        MipMapLevels = new List<byte[]>(capacity);
    }
    
    public TextureData(params List<byte[]> levels)
    {
        MipMapLevels = levels;
    }

}