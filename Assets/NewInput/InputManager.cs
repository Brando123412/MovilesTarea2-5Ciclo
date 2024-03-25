using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

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
        EnhancedTouchSupport.Enable();
        controlTaps.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        controlTaps.Disable();
        TouchSimulation.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }
    private void Start()
    {
        controlTaps.TapController.Presset.started += ctx => StartTouch(ctx);
        controlTaps.TapController.Presset.canceled += ctx => EndTouch(ctx);
    }
    void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Inicio" + context.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            //OnStartTouch(controlTaps.TapController.Position.ReadValue<Vector2>(), (float)context.startTime);
            OnStartTouch(context.ReadValue<Vector2>(), (float)context.startTime);
        }
    }
    void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("End" + controlTaps.TapController.Position.ReadValue<Vector2>());  
        if (OnEndTouch != null)
        {
            OnEndTouch(controlTaps.TapController.Position.ReadValue<Vector2>(), (float)context.time);
        }
    }
    private void FingerDown(Finger finger)
    {
        if (OnEndTouch != null)
        {
            OnStartTouch(finger.screenPosition, Time.time);
        }
    }
    private void Update()
    {
        //Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
        foreach (UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
        }
    }
}
