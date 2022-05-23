using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Game.Logic;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Boost boost;
    [SerializeField] private ItsTimeToStop timeStop;
    private PlayerInputActions input;
    private PlayerMovement movement;
    private Transform transformPlayer;
    private float rotatePlayer;

    
    private void Awake()
    {
        input = new PlayerInputActions();
        movement = new PlayerMovement();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        transformPlayer = GetComponent<Transform>();
    }

    private void Update()
    {
        ReadInputValues();
        TryToMove();
        TryToAccelerate();
        TryToRotate();
    }

    private void ReadInputValues()
    {
        rotatePlayer = input.Player.Rotate.ReadValue<float>();
    }

    private void TryToMove()
    {
        movement.Move(transformPlayer);
    }

    private void TryToAccelerate()
    {
        if (PlayerIsMoving())
        {
                movement.Accelerate(transformPlayer, boost.unitsInSecond, boost.maxBoost, Time.deltaTime);
        }
        else
        {
            movement.Slow(timeStop.SecondsToStop, Time.deltaTime);
        }
    }

    private void TryToRotate()
    {
       movement.SetRotateValue(rotatePlayer);
       movement.SetSpeed(boost.rotation, Time.deltaTime);
       movement.Rotate(transformPlayer);
       movement.GetEulerAngle(rotatePlayer, transformPlayer);
    }

    private bool PlayerIsMoving()
    {
        return input.Player.MoveForward.phase == InputActionPhase.Performed;
    }
}


[Serializable]
internal class Boost
    {
        [SerializeField] private float mySpeed;
        [SerializeField] private float myMaxSpeed;
        [SerializeField] private float myRotationSpeed;

        public float unitsInSecond => mySpeed;    
        public float maxBoost => myMaxSpeed;
        public float rotation => myRotationSpeed;
    }

[Serializable]
internal class ItsTimeToStop
{
    [SerializeField] private float seconds;

    public float SecondsToStop => seconds;
}