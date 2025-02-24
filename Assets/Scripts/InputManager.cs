using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public float moveVal;
    InputSystem_Actions inputActions;

    public static bool JumpWasPressed;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        inputActions = new InputSystem_Actions();

        // Movimiento horizontal
        inputActions.Player.Move.performed += i => moveVal = i.ReadValue<float>();
        inputActions.Player.Move.canceled += _ => moveVal = 0f; // Detener el movimiento al soltar

        // Detección de salto
        inputActions.Player.Jump.started += _ => JumpWasPressed = true;
        inputActions.Player.Jump.canceled += _ => JumpWasPressed = false;

        inputActions.Enable();
    }

    private void OnEnable() => inputActions?.Enable();
    private void OnDisable() => inputActions?.Disable();
}
