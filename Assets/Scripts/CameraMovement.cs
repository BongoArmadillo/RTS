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

    void Update() {
        Vector3 position = transform.position;

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

        position.x = Mathf.Clamp(position.x, -borLimit.x, borLimit.x);
        position.z = Mathf.Clamp(position.z, -borLimit.y, borLimit.y);
        position.y = Mathf.Clamp(position.y, heightLimitmin, heightLimitmax);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y += scroll * scrollSpeed * 100f * Time.deltaTime;

        transform.position = position;

    }
}
