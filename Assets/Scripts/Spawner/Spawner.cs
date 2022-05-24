using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] LayerMask spawnLayer;
    [SerializeField] GameObject button;
    [SerializeField] GameObject panel;
    Camera mainCam;

        void Start() {
            mainCam = Camera.main;
        }

        private void Update() {
            spawnerSelect();
        }
    void spawnerSelect(){
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, spawnLayer))
            {
                button.SetActive(true);
                panel.SetActive(true);
            }
        }
 
    }

}


