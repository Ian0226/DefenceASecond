using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapCameraController : MonoBehaviour
{
    
    public float MaxPosRight;
    public float MaxPosLeft;
    Vector2 mouseStart;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mouseStart = Camera.main.ScreenToWorldPoint(mouseStart);
            //mouseStart.z = transform.position.z;

        }
        else if (Input.GetMouseButton(0))
        {
            var MouseMove = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            //MouseMove.z = transform.position.z;
            transform.position = new Vector3(transform.position.x - (MouseMove - mouseStart).x, transform.position.y,-10);
            if(transform.position.x <= MaxPosRight)
            {
                transform.position = new Vector3(MaxPosRight, transform.position.y, -10);
            }
            else if(transform.position.x >= MaxPosLeft)
            {
                transform.position = new Vector3(MaxPosLeft, transform.position.y, -10);
            }
        }
        
    }
}
