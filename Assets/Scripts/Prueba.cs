using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Prueba : MonoBehaviour
{
    InputManager inputManager;
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
    
}


/*Para Agarrar referencia de la camama en cero
    private Camera camaraMain;
    En el awake
    cameraMain = Camera.Main;
    en donde se agarra referencia 
    cameraMain.nearClipPlane;
    /*private Vector2 pos;
    Touch primerTouch;
    [SerializeField] GameObject instanciaObjeto;
    [SerializeField] Vector3 positionSpanw;
    Vector3 touchPosition;

    [SerializeField] bool isTouching = false;
    [SerializeField] float timer = 0;

    [SerializeField] Transform spawnObjects;
    [SerializeField] bool tap = false;

    //Pruebas
    [SerializeField] float timeScale = 0;
    [SerializeField] float quantityTap;
    void Update()
    {
        if (Input.touchCount > 0 && instanciaObjeto.GetComponent<SpriteRenderer>().sprite != null && instanciaObjeto.GetComponent<SpriteRenderer>().color.a != 0)
        {
            isTouching = true;
            if (timeScale == 0)
            {
                timeScale = timeScale + Time.deltaTime;
            }
        }
        else
        {
            isTouching = false;
        }

        if (isTouching)
        {
            timer = timer + Time.deltaTime;
            if (timer > 1f)
            {
                VerifyRay();
            }
            else if (timer > 0.3f && timer < 0.5f)
            {

            }
            else if (timer < 0.3f && tap == false)
            {
                tap = true;
                Instantiate(instanciaObjeto, PositionTouch(), Quaternion.identity, spawnObjects);
            }
        }
        else
        {
            timer = 0;
            tap = false;
        }


    }
    public void CambioColor(GameObject color)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().color = color.GetComponent<Image>().color;
    }
    public void CambioImagen(GameObject imagen)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().sprite = imagen.GetComponent<Image>().sprite;
    }
    void VerifyRay()
    {
        primerTouch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(primerTouch.position);
        print("Hola");
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        if (hit.collider != null)
        {
            print("ga");
            Transform otherTransfomr = hit.collider.gameObject.transform;
            otherTransfomr.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        }
    }
    Vector3 PositionTouch()
    {
        primerTouch = Input.GetTouch(0);
        touchPosition = primerTouch.position;
        positionSpanw = Camera.main.ScreenToWorldPoint(touchPosition);
        Vector3 returmPosition = new Vector3(positionSpanw.x, positionSpanw.y, 0);
        return returmPosition;
    }    */