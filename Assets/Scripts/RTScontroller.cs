using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTScontroller : MonoBehaviour
{
 Vector3 startPosiotion;
 Vector3 endPosition;

 public Vector3 boxRange;

private List<Transform> unitsToMove = new List<Transform>();

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
        Debug.DrawRay(startPosiotion, Vector3.down);
        Collider[] units;

        //RaycastHit[] = Physics.BoxCastAll(startPosiotion, endPosition);
      units = Physics.OverlapBox((startPosiotion+endPosition)/2, boxRange, Quaternion.identity, 6);

    int i =  0;
     while (i < units.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + units[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    //   unitsToMove = new List<Transform>();
    //     foreach (Collider c in units)
    //     {
    //         unitsToMove.Add(c.transform);
    //     }
        
    }
        }


         void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube((startPosiotion+endPosition)/2, boxRange);
    }

        
    }       
}
