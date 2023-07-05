using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 target = new Vector3(0,0,0);
    public float speed = 0.3f;
    public GameObject cameraObj;
    public Vector2 cameraOffset;
    public bool canMove = true;
    public bool selected = false;
    public int generateMoney = 0;
    public varables mon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            if(selected&&canMove)
            target= Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        }
        


    }
    private void Awake()
    {
        target = transform.position;
    }
    private void FixedUpdate()
    {
       
        // moves the spaceship to the target (mouse click position)
        moveToTarget();
        if (!cameraObj)
        {
            cameraObj = Camera.main.gameObject;
        }
        if(Camera.main.gameObject.GetComponent<camControl>().canMove)
        cameraObj.transform.localPosition = new Vector3(Mathf.Lerp(cameraObj.transform.localPosition.x, transform.localPosition.x, speed), Mathf.Lerp(cameraObj.transform.localPosition.y, transform.localPosition.y-cameraOffset.y, speed), -10);


    }
    public void moveToTarget()
    {
        
        transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, target.x, speed), Mathf.Lerp(transform.localPosition.y, target.y, speed), 0);
    }
    public bool isIntersectPoint(Vector2 point)
    {
        Vector3 topLeft = transform.position -transform.lossyScale/2;
        if (point.x >= topLeft.x &&  point.x <= (transform.lossyScale.x + topLeft.x) && point.y >= topLeft.y && point.y <= topLeft.y+ transform.lossyScale.y)
        {
            
            return true;
            
        }
        return false;
    }
    public void setSelected(bool val)
    { 
        selected = val;
    }
    private void OnDestroy()
    {
        if(generateMoney>0&& mon)
        {
            mon.income -= generateMoney;
        }
    }
}
