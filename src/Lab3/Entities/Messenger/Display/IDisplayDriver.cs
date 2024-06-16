namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger.Display;

public interface IDisplayDriver
{
    void Clear();
    void SetColor(string color);
    void WriteText(string text);
}