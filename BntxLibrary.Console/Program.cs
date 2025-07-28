using BntxLibrary;

byte[] buffer = File.ReadAllBytes(@"F:\Software\Libraries\Nintendo\EPD-Libraries\BntxLibrary\data\Common.bntx");
TextureFile bntx = new(buffer);

Console.WriteLine(bntx.Name);
Console.WriteLine(bntx.Version);
Console.WriteLine(bntx.TargetPlatform);

foreach ((string textureName, Texture texture) in bntx.Textures) {
    Console.WriteLine(textureName);
}