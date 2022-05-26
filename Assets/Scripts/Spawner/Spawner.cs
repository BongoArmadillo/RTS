using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{
    [SerializeField] LayerMask spawnLayer;
    [SerializeField] LayerMask castleLayer;
    [SerializeField] GameObject spawnerButton;
    [SerializeField] GameObject spawnerPanel;
    [SerializeField] GameObject castleButton;
    [SerializeField] GameObject castlePanel;
    Camera mainCam;

        void Start() {
            mainCam = Camera.main;
        }

        private void Update() {
            spawnerSelect();
            castleSelect();
        }
    void spawnerSelect(){
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, spawnLayer))
            {
                spawnerButton.SetActive(true);
                spawnerPanel.SetActive(true);
                castleButton.SetActive(false);
                castlePanel.SetActive(false);
            }
        }
 
    }

    void castleSelect(){
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, castleLayer))
            {
                castleButton.SetActive(true);
                castlePanel.SetActive(true);
                spawnerButton.SetActive(false);
                spawnerPanel.SetActive(false);
            }
            
        }
 
    }

}


