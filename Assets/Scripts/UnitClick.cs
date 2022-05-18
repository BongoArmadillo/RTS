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
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, unit))
            {

                if(Input.GetKey(KeyCode.LeftShift))
                {
                    RTSselector.instance.shiftclickSelect(hit.collider.gameObject);
                }
                else
                {
                    RTSselector.instance.clickSelect(hit.collider.gameObject);
                }

            }
            else
            {
                if(!Input.GetKeyDown(KeyCode.LeftShift))
                {
                    RTSselector.instance.deselectALL();
                }
            }
        }
   
   
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }
    }
}
