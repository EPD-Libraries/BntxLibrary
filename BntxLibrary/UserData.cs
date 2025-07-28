using System.Text;
using BntxLibrary.Common.Gfx;
using BntxLibrary.Common.Util;
using BntxLibrary.Extensions;

namespace BntxLibrary;

public class UserData : List<UserDataEntry>
{
    public UserData()
    {
    }

    public UserData(int count) : base(count)
    {
    }

    internal static unsafe UserData? FromRes(ResTextureInfo* textureInfo)
    {
        ResDic* userDataNames = textureInfo->UserDataNames.GetPtr();
        if (userDataNames == null) {
            return null;
        }
        
        int entryCount = userDataNames->EntryCount;
        GfxUserData* userData = textureInfo->UserData.GetPtr();

        UserData result = new(entryCount);
        for (int i = 0; i < textureInfo->UserDataNames.Get().EntryCount; ++i) {
            GfxUserData entry = userData[i];
            BinaryString<byte>* name = entry.Name.GetPtr();
            result.Add(
                new UserDataEntry(
                    Encoding.UTF8.GetString(&name->Chars, name->Length),
                    entry.Type,
                    entry.Type switch {
                        GfxUserDataType.Int => entry.IntArray.ToList(),
                        GfxUserDataType.Float => entry.FloatArray.ToList(),
                        GfxUserDataType.String => entry.StringArray.ToStringList(),
                        GfxUserDataType.Byte => entry.ByteArray.ToList(),
                        GfxUserDataType.WString => entry.WideStringArray.ToStringList(),
                        _ => throw new NotSupportedException($"Invalid UserData type: {entry.Type}")
                    }
                )
            );
        }

        return result;
    }
}