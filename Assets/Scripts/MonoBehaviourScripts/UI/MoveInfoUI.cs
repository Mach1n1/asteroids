using TMPro;
using UnityEngine;

public class MoveInfoUI : MonoBehaviour
{
    [SerializeField] private PlayerMoveUI player;

    [SerializeField] private TMP_Text playerPosition;
    [SerializeField] private TMP_Text playerRotation;
    [SerializeField] private TMP_Text playerSpeed;

    private void OnEnable()
    {
        player.PlayerShipPositionChanged += OnPlayerPositionChanged;
        player.AngleRotationChanged += OnAngleRotationChanged;
        player.SpeedChanged += OnChangedSpeed;
    }

    private void OnDisable()
    {
        player.PlayerShipPositionChanged -= OnPlayerPositionChanged;
        player.AngleRotationChanged -= OnAngleRotationChanged;
        player.SpeedChanged -= OnChangedSpeed;
    }

    private void OnPlayerPositionChanged(Vector2 coordinates)
    {
        playerPosition.text = $"Position: {coordinates}";
    }

    private void OnAngleRotationChanged(float angle)
    {
        playerRotation.text = $"Rotation: {Mathf.RoundToInt(angle)}°";
    }

    private void OnChangedSpeed(float boost)
    {
        playerSpeed.text = $"Speed: {Mathf.RoundToInt(boost)}";
    }
}
