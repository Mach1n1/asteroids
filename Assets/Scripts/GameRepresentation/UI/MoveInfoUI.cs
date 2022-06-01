using TMPro;
using UnityEngine;

public class MoveInfoUI : MonoBehaviour
{
    [SerializeField] private PlayerMoveUI player;

    [SerializeField] private TMP_Text _coordinatPlayer;
    [SerializeField] private TMP_Text _angleRotationPlayer;
    [SerializeField] private TMP_Text _instantaneousSpeedPlayer;

    private void OnEnable()
    {
        player.CoordinatesShipPlayerChanged += OnCoordinatesShipPlayerChanged;
        player.AngleRotationChanged += OnAngleRotationChanged;
        player.SpeedChanged += OnChangedSpeed;
    }

    private void OnDisable()
    {
        player.CoordinatesShipPlayerChanged -= OnCoordinatesShipPlayerChanged;
        player.AngleRotationChanged -= OnAngleRotationChanged;
        player.SpeedChanged -= OnChangedSpeed;
    }

    private void OnCoordinatesShipPlayerChanged(Vector2 coordinates)
    {
        _coordinatPlayer.text = $"Coordinate: {coordinates}";
    }

    private void OnAngleRotationChanged(float angle)
    {
        _angleRotationPlayer.text = $"AngleRotation: {Mathf.RoundToInt(angle)}°";
    }

    private void OnChangedSpeed(float boost)
    {
        _instantaneousSpeedPlayer.text = $"Speed: {Mathf.RoundToInt(boost)}";
    }
}
