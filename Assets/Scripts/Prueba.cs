using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem;
public class Prueba : MonoBehaviour
{
    private InputManager inputManager;
    Camera cameraMain;  
    private void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }
    private void OnDisable()
    {
        
         inputManager.OnEndTouch -= Move;
        
    }

    public void Move(Vector2 touchPosition, float time)
    {
        Vector3 touchCoordinates = new Vector3(touchPosition.x,touchPosition.y,0);
        Vector3 worldCoordinated = cameraMain.ScreenToWorldPoint(touchCoordinates);
        transform.position = worldCoordinated;
    }
    private void Update()
    {
       /* if (Touchscreen.current.primaryTouch.press.isPressed)
        {

            

            
                if (inputManager. == TouchPhase.Began)
                {
                    isTouch = true;
                    puntoA = positionSpanw;
                    if (timeTouch == 0)
                    {
                        timeTouch = time;
                    }
                }
                if (isTouch && touch.phase == TouchPhase.Ended)
                {
                    puntoB = positionSpanw;
                    isTouch = false;
                    cantidadTouch++;
                }
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                MovedObject();
            }
        }     */
    }

}