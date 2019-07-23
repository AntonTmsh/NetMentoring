namespace Epam.NetMentoring.Disposable
{
    public interface IFileWriter
    {
        void Write(string str);
        void WriteLine(string str);
    }
}