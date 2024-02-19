using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PinBallInput pinBallInput;
    public PinBallInput.PinBallActions PinBall;
    private PlayerMovement movement;
    private WeaponInput weaponInput;
    private WeaponSwitch weaponSwitching;
    // Start is called before the first frame update
    void Awake()
    {
        pinBallInput = new PinBallInput();
        PinBall = pinBallInput.PinBall;

        movement = GetComponent<PlayerMovement>();
        weaponInput = GetComponent<WeaponInput>();
        weaponSwitching = GetComponentInChildren<WeaponSwitch>();

        PinBall.Shoot.started += ctx => weaponInput.StartShot();
        PinBall.Shoot.canceled += ctx => weaponInput.EndShot();

        PinBall.WeaponNext.performed += ctx => weaponSwitching.WeaponNext();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.ProcessMoveX(PinBall.Movement.ReadValue<Vector2>().x);
        movement.ProcessMoveY(PinBall.Movement.ReadValue<Vector2>().y);
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
