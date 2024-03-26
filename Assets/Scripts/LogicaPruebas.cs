using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class LogicaPruebas : MonoBehaviour
{
    [SerializeField] int cantidadTouch = 0;
    bool isTouch;
    [SerializeField] float time;
    [SerializeField] float timeTouch;
    [SerializeField] GameObject instanciaObjeto;
    [SerializeField] Transform spawnObjects;

    //Position Spanw    and touch
    [SerializeField] Vector3 touchPosition;
    [SerializeField] Vector2 positionSpanw;

    [SerializeField] Touch touch;
    [SerializeField] GameObject touchTarjet; 

    [Header("Pruebas para Distance")]
    [SerializeField] float distanceAB;
    [SerializeField] float gaa;



    private void Awake()
    {
        isTouch = false;
        time= 0;
        timeTouch= 0;

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Moved)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isTouch = true;
                    if (timeTouch == 0)
                    {
                        timeTouch = time;
                    }
                }
                if (isTouch && touch.phase == TouchPhase.Ended)
                {
                    isTouch = false;
                    cantidadTouch++;
                }
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                MovedObject();
            }
        }

        touchPosition = touch.position;
        positionSpanw = Camera.main.ScreenToWorldPoint(touchPosition);

        time += Time.deltaTime;
        if (timeTouch != 0)
        {
            gaa = time - timeTouch;
        }
        if (gaa >= 0.29f && gaa <= 0.31f)
        {
            Debug.Log("tiempo");
            if (cantidadTouch == 2)
            {
                DeleteObject();
                cantidadTouch = 0;
                timeTouch = 0;
            }
            else if (cantidadTouch == 1)
            {
                Instantiate(instanciaObjeto, new Vector3(positionSpanw.x, positionSpanw.y, 0), Quaternion.identity, spawnObjects);
                cantidadTouch = 0;
                timeTouch = 0;
            }
        }
        if(gaa >= 0.32f)
        {
            cantidadTouch = 0;
            timeTouch = 0;
        }
        if (Input.touchCount > 0)
        {
            Vector2 swipeDirection = Input.GetTouch(0).deltaPosition;

            RaycastHit2D hit = Physics2D.Raycast(positionSpanw, Vector2.zero);
            
            if (swipeDirection.magnitude > 0 && hit.collider == null )
            {
                EliminarTodosLosHijos();
            }
        }
    }
    void DeleteObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(positionSpanw, Vector2.zero);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
    void MovedObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(positionSpanw, Vector2.zero);
        if (hit.collider != null)
        {
            hit.collider.transform.position = positionSpanw;
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
    void EliminarTodosLosHijos()
    {
        GameObject trailRenderer = Instantiate(touchTarjet, Vector3.zero, Quaternion.identity);
        trailRenderer.GetComponent<TrailRenderer>().startColor = UnityEngine.Color.blue;
        trailRenderer.GetComponent<TrailRenderer>().endColor = UnityEngine.Color.red;
        trailRenderer.GetComponent<TrailRenderer>().Clear();
        foreach (Transform child in spawnObjects)
        {
            Destroy(child.gameObject);
        }
    }

}
