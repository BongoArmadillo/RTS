using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mainCam;
    public GameObject groundMarker;
    public LayerMask unit;
    public LayerMask ground;

    private void Start() {
        mainCam = Camera.main;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {    
        RTSselector.instance.deselectALL();             
        }
   
   
        if(Input.GetMouseButton(1) && RTSselector.instance.unitSelected.Count >= 1)
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(true);
            }
        }
    }
}
