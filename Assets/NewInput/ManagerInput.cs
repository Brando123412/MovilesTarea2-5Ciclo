using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerInput : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction positionAction;
    InputAction pressAction;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pressAction = playerInput.actions["Press"];
        positionAction = playerInput.actions["Position"];
    }
    private void OnEnable()
    {
        pressAction.performed += OnPress;
    }
    private void OnDisable()
    {
        pressAction.performed -= OnPress;
    }
    void OnPress(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);

    }
    void OnPosition(InputAction.CallbackContext context)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        position.z = 0;
    }
}
