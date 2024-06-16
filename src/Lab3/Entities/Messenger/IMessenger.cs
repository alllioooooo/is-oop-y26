namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public interface IMessenger
{
    void WriteMessage(string message);
    void Receive(string message);
}