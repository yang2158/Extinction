using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ally;
    public playerMove selected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             selected = null;
            
           foreach ( Transform child in ally)
            {
                child.GetComponent<playerMove>().selected = false;

                if (child.GetComponent<playerMove>().isIntersectPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    selected = child.GetComponent<playerMove>();

                }
            }

            if (selected)
                selected.setSelected(true);
        }
    }
}
