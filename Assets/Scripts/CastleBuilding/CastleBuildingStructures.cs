using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleBuildingStructures : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public int isBuildable = 0;
    [SerializeField] GameObject mineBuilding;
    [SerializeField] Material validBuildingPlaceMaterial;
    [SerializeField] Material unvalidBuildingPlaceMaterial;
    

     void Start() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 7)))
    {
        movePoint = hit.point;
        movePoint.y += 2;
        transform.position = movePoint;
    }

    }

    void Update() {
    placeBuildings();
    unvalidBuildingPlace();

    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Ground"){
            isBuildable++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag != "Ground"){
            isBuildable--;
        }
    }

    void placeBuildings(){
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 14)))
    {
        movePoint = hit.point;
        movePoint.y += 2.33f;
        transform.position = movePoint;
    }
    
    if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 7))){

        if(Input.GetMouseButtonUp(0) && isBuildable <= 0){
            Instantiate(mineBuilding, transform.position,transform.rotation);
            GameObject.FindGameObjectWithTag("BuildingPlace").SetActive(false);
            Destroy(gameObject);
        }

    }

    else if(Input.GetMouseButtonUp(0) && isBuildable > 0){
        Debug.LogError("Cant build it here");
    }
    }

    void unvalidBuildingPlace(){
        
            if(isBuildable > 0)
            gameObject.GetComponent<MeshRenderer>().material = unvalidBuildingPlaceMaterial;
            
            else
            gameObject.GetComponent<MeshRenderer>().material = validBuildingPlaceMaterial;
        
    }
}
