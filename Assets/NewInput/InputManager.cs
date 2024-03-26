using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : Singelton<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    Tap controlTaps;
    private void Awake()
    {
        controlTaps = new Tap();
    }
    private void OnEnable()
    {
        controlTaps.Enable();
    }
    private void OnDisable()
    {
        controlTaps.Disable();
    }
    private void Start()
    {
        controlTaps.TapController.Presset.started += ctx => StartTouch(ctx);
        controlTaps.TapController.Presset.canceled += ctx => EndTouch(ctx);
    }
    void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Inicio" + controlTaps.TapController.Position.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            OnStartTouch(controlTaps.TapController.Position.ReadValue<Vector2>(), Time.time);
        }
    }
    void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("End" + controlTaps.TapController.Position.ReadValue<Vector2>());  
        if (OnEndTouch != null)
        {
            OnEndTouch(controlTaps.TapController.Position.ReadValue<Vector2>(), Time.time);
        }
    }
}
