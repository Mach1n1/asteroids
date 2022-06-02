using UnityEngine.Events;
using UnityEngine;

public class PlayerMoveUI : MonoBehaviour
{
    [SerializeField] private PlayerMove player;

    public Vector2 Coordinate { get; private set; }
    public float Boost { get; private set; }
    public float Angle { get; private set; }

    public event UnityAction<Vector2> PlayerShipPositionChanged;
    public event UnityAction<float> SpeedChanged;
    public event UnityAction<float> AngleRotationChanged;

    private void FixedUpdate()
    {
        CoordinatesPlayerShip();
        InstantaneousSpeed();
        AngleRotation();
    }

    private void CoordinatesPlayerShip()
    {
        Coordinate = player.TransformPlayer.position;
        PlayerShipPositionChanged?.Invoke(Coordinate);
    }

    private void InstantaneousSpeed()
    {
        Boost = player.AccelerationPlayer.magnitude * 1000;
        SpeedChanged?.Invoke(Boost);
    }

    private void AngleRotation()
    {
        Angle = player.AngleRotatePlayer;
        AngleRotationChanged?.Invoke(Angle);
    }
}
