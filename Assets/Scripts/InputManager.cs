using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public float moveVal;
    InputSystem_Actions inputActions;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Move.performed += i => moveVal = i.ReadValue<float>();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        inputActions?.Enable();
    }

    private void OnDisable()
    {
        inputActions?.Disable();
    }
}
