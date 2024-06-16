namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger.Display;

public interface IDisplay
{
    void ShowMessage(string message);
    void Receive(string message);
}