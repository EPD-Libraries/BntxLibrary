using Revrs;

namespace BntxLibrary.Writers.WriterContextModels;

public interface IWriterContext
{
    public RevrsWriter Writer { get; }
}
