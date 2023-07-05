using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    bool screenshake = false;
    Vector2 target = new Vector2(0, 0);
    float frequency = 0f;
    float time = 0.0f;
    public float magnitude = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            screenshake = true;

        }
        if(screenshake)
        {
            time += Time.deltaTime;
            if(time > frequency)
            {
                time = 0;
                target = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1))*magnitude;
            }
        }
        transform.localPosition = Vector2.Lerp(transform.localPosition , target , 0.1f);
    }
}
