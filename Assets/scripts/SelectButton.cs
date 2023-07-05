using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectButton : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update

    public GameObject carrier;
    public Object prefabObj;
    public int price = 1;
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // OnMouseOver
        if (Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.gameObject == gameObject)
            {
                transform.GetChild(0).GetComponent<Text>().enabled = true;

            }
            else
            {
                transform.GetChild(0).GetComponent<Text>().enabled = false;
            }
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        carrier.GetComponent<build>().sel(prefabObj , price, enemy);
       
    }
     void OnMouseEnter()
    {
            transform.GetChild(0).GetComponent<Text>().enabled = true;
        
    }
      void OnMouseExit()
    {
            transform.GetChild(0).GetComponent<Text>().enabled = false;
        
    }
    private void OnMouseOver()
    {
        transform.GetChild(0).GetComponent<Text>().enabled = false;
    }
}
