using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camSpeed = 20f;
    public float borThickness;
    public Vector2 borLimit;
    public float heightLimitmax;
    public float heightLimitmin;
    public float scrollSpeed;
    float x;
    float y;
    float rotationSpeed = 100f;

    void Update() {
        Vector3 position = transform.position;
        Quaternion rotation =  Quaternion.Euler(50,0,transform.rotation.z  * Time.deltaTime);

        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - borThickness)
        {
           position.z += camSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= borThickness)
        {
           position.z -= camSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - borThickness)
        {
           position.x += camSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <=  borThickness)
        {
           position.x -= camSpeed * Time.deltaTime;
        }

         if(Input.GetKey(KeyCode.Q))
        {
           transform.rotation = rotation;
        }

        position.x = Mathf.Clamp(position.x, -borLimit.x, borLimit.x);
        position.z = Mathf.Clamp(position.z, -borLimit.y, borLimit.y);
        position.y = Mathf.Clamp(position.y, heightLimitmin, heightLimitmax);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y += scroll * scrollSpeed * 100f * Time.deltaTime;

        transform.position = position;

    }
}
