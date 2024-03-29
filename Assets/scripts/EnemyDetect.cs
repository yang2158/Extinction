using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public GameObject enemies;
    float lastCheck = 0f;
    public Transform bulletLocal;
    public Object bulletTemplate;
    public GameObject Target;
    [Tooltip("Number less than 0 for no AI Movement")]
    public float range = 5f;
    public float sightRange = 100f;
    public float speed = 0.1f;
    public bool turn = false;
    public bool canMove = false;
    public bool canShoot = true;
    public float fireRate = 2;
    public bool heals = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Target)
        {
          
            if(turn ) face();
        }

    }
     void FixedUpdate()
    {
        if (Target)
        {
            Vector3 dis = (Target.transform.position - transform.position);
            float dist = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
            if (Target && range >= 0&&canMove)
            {


                if (dist > range && dist < sightRange)
                {
                    transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, Target.transform.localPosition.x, speed), Mathf.Lerp(transform.localPosition.y, Target.transform.localPosition.y, speed), transform.localPosition.z);

                }

            }
            if (dist - range < 1&& lastCheck%(1f/fireRate)<Time.deltaTime/2 && canShoot) {
                GameObject bullet = (GameObject) GameObject.Instantiate(bulletTemplate,transform.position, transform.rotation , bulletLocal);
                bullet.transform.position = transform.position;
                bullet.GetComponent<bullet>().target = Target;
                
            }
        }
        lastCheck += Time.deltaTime;
        
        if (lastCheck > 1 + Random.Range(0,0.6f))
        {
            lastCheck = 0;
            refresh();
        }
    }
    
    protected void face()
    {
        
        float angle = inverseTan(transform.position, Target.transform.position);
        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,0.5f);

    }
    float inverseTan(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg-270;
    }
    public void refresh()
    {
        if (enemies.transform.childCount > 0)
        {
            Transform closestOBJ = null;
            float objDist = float.MaxValue;
            foreach (Transform child in enemies.transform)
            {
                if (child != gameObject.transform) { 
                    Vector3 dis = (child.position - transform.position);
                    float dist = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
                    if (dist < sightRange && child.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        if (objDist > dist && !heals)
                        {
                            closestOBJ = child;
                            objDist = dist;
                        } else if (heals)
                        {
                            if (objDist > child.gameObject.GetComponent<Health>().health && child.gameObject.GetComponent<Health>().canHeal())
                            {
                                closestOBJ = child;
                                objDist = child.gameObject.GetComponent<Health>().health;
                            }
                        }
                    }
            
            }
            }
            if (heals && !closestOBJ) Target = null;
            if (closestOBJ)
                Target = closestOBJ.gameObject;
        }
    }
    public float closestDist()
    {
        float objDist = float.MaxValue;
        foreach (Transform child in transform.parent)
        {
            if (child != transform) {
                Vector3 dis = (child.position - transform.position);
                float dist = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
                if (dist < objDist)
                {
                    objDist = dist;
                } }
        }
        return objDist;
    }
    public bool intersectsOthers()
    {
        float objDist = float.MaxValue;
        Transform clos = null;
        foreach (Transform child in transform.parent)
        {
            if (child != transform)
            {
                Vector3 dis = (child.position - transform.position);
                float dist = Mathf.Sqrt(Mathf.Pow(dis.x, 2) + Mathf.Pow(dis.y, 2));
                if (dist < objDist|| !clos)
                {
                    if( dist -transform.lossyScale.x/2 - child.lossyScale.x/2 - Mathf.Min(transform.lossyScale.x / 2 , child.lossyScale.x / 2) <= 0)
                    {
                        return true;
                    }
                    
                }
            }
        }

        return false;
    }
}
