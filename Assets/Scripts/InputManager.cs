using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PinBallInput pinBallInput;
    public PinBallInput.PinBallActions PinBall;
    private PlayerMovement movement;
    // Start is called before the first frame update
    void Awake()
    {
        pinBallInput = new PinBallInput();
        PinBall = pinBallInput.PinBall;

        movement = GetComponent<PlayerMovement>();

        //Player Motor
        //PinBall.Jump.performed += ctx => motor.Jump();
        //PinBall.Crouch.started += ctx => motor.StartCrouch();
        //PinBall.Crouch.canceled += ctx => motor.EndCrouch();
        //pinBallInput.PinBall.Aim.canceled += ctx => playerWeapon.EndAim();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.ProcessMove(PinBall.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        PinBall.Enable();
    }

    private void OnDisable()
    {
        PinBall.Disable();
    }
}
