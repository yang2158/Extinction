using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    public bool canMove = true;
     Camera cam;
    float target;
    public float smoothness =0.2f;
    public bool lerp = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        target = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            target += Input.GetAxis("Mouse ScrollWheel")*10;
        target = Mathf.Max(1, target);
        target = Mathf.Min(25, target);
        if(!lerp)cam.orthographicSize =target;
        cam.orthographicSize = Mathf.Lerp(target , cam.orthographicSize , smoothness*Time.deltaTime);
    }
}
