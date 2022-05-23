using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerTimer : MonoBehaviour
{
float cooldownTimer = 10;
[SerializeField] Text cooldownText;
[SerializeField] Button timerButton;

private void Start() {
    
}
public void Update() {
    timerButton.onClick.AddListener(Update);

    
    if(cooldownTimer >= 0){
        cooldownTimer -= Time.deltaTime;
        cooldownText.text = Mathf.RoundToInt(cooldownTimer).ToString();
        }

    else{
            cooldownText.text = "Create";
        }
    }
}
