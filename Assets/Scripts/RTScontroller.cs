using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTScontroller : MonoBehaviour
{
 Vector3 startPosiotion;
 Vector3 endPosition;

Plane plane = new Plane(Vector3.up, 0);
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (plane.Raycast(ray, out distance))
    {
        startPosiotion = ray.GetPoint(distance);
    }
        }


        if(Input.GetMouseButtonUp(0))
        {
           float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (plane.Raycast(ray, out distance))
    {
        endPosition = ray.GetPoint(distance);
        Debug.LogError("Pozycja startowa" + startPosiotion + "Pozycja koncowa" + endPosition);


       // RaycastHit[] = Physics.BoxCastAll(startPosiotion, endPosition);
        Debug.Log("########");
        
    }
        }


        

        
    }       
}
