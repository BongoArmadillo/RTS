using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] GameObject groundMarker;
    [SerializeField] LayerMask unit;
    [SerializeField] LayerMask ground;

    private void Start() {
        mainCam = Camera.main;
    }

    private async void Update() {
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
                await groundMarkerTimer();
            }
        }
    }

    async Task groundMarkerTimer(){
        groundMarker.SetActive(true);
        await Task.Delay(2000);
        groundMarker.SetActive(false);
    }
}
