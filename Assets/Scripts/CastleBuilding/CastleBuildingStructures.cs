using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBuildingStructures : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    [SerializeField] GameObject mineBuilding;
    [SerializeField] int layermask;
    

     void Start() {
        layermask = ~LayerMask.GetMask("Spawner");
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 7)))
    {
        movePoint = hit.point;
        movePoint.y += 2;
        transform.position = movePoint;
    }

    }

    void Update() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 7)))
    {
        movePoint = hit.point;
        movePoint.y += 2;
        transform.position = movePoint;
    }
    if(Input.GetMouseButtonUp(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, layermask)){
        Instantiate(mineBuilding, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    }
}
