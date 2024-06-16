using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflectorDecorator : IDeflector
{
    private readonly IDeflector _baseDeflector;
    private int _antimatterFlashCount;

    public PhotonDeflectorDecorator(IDeflector baseDeflector)
    {
        _baseDeflector = baseDeflector;
    }

    public int Level => _baseDeflector.Level;

    public bool IsOffline
    {
        get => _baseDeflector.IsOffline || _antimatterFlashCount >= 3;
        private set => throw new System.NotImplementedException();
    }

    public void TakeDamage(IObstacle obstacle)
    {
        if (obstacle is AntimatterFlash)
        {
            _antimatterFlashCount++;
            return;
        }

        _baseDeflector.TakeDamage(obstacle);
    }

    public void Destroy()
    {
        IsOffline = true;
    }
}