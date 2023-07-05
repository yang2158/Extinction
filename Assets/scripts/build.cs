using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    public Transform ally;
    public GameObject hover = null;
    public GameObject enemies;
    public GameObject ene;
    public Transform bullets;
    camControl cam;
    // Start is called before the first frame update
    int clicks = 0;
    int price=int.MaxValue;
    public varables money;
    Object itm;
    public void sel(Object item, int prices , GameObject enemi)
    {
        if (hover)
        {
            GameObject.Destroy(hover);
        }
        cam.canMove = false;
        ene = enemi;
        hover = (GameObject)GameObject.Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, ally);
        hover.GetComponent<EnemyDetect>().enemies = ene;
        hover.GetComponent<EnemyDetect>().bulletLocal = bullets;
        hover.GetComponent<SpriteRenderer>().color = Color.green;
        
        clicks = 0;
        hover.GetComponent<EnemyDetect>().canShoot = false;
        price = prices;
        itm = item;
    }
    void Start()
    {
        cam = Camera.main.gameObject.GetComponent<camControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&clicks %2 == 0)
        {
            clicks++;
        }
        if (Input.GetMouseButtonUp(0) && clicks % 2 == 1)
        {
            clicks++;
        }
        if (hover)
        {
            hover.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.forward * Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Destroy(hover);
                cam.canMove = true;

            }
            if ( price<= money.money&& enemies.transform.childCount==0 && !hover.GetComponent<EnemyDetect>().intersectsOthers())
            {
                if (hover)
                {
                    hover.GetComponent<SpriteRenderer>().color = Color.green;
                    if (Input.GetMouseButtonUp(0) && clicks > 3)
                    {
                        money.money -= price;
                        money.income += hover.GetComponent<playerMove>().generateMoney;
                        hover.GetComponent<playerMove>().mon = money;
                        hover.GetComponent<EnemyDetect>().canShoot = true;
                        hover.GetComponent<SpriteRenderer>().color = Color.white;
                        hover.GetComponent<playerMove>().setSelected(false);
                        hover.GetComponent<playerMove>().target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        hover = (GameObject)GameObject.Instantiate(itm, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, ally);
                        hover.GetComponent<EnemyDetect>().enemies = ene;
                        hover.GetComponent<EnemyDetect>().bulletLocal = bullets;
                        hover.GetComponent<SpriteRenderer>().color = Color.green;
                        hover.GetComponent<EnemyDetect>().canShoot = false;
                        
                    }
                }
            }
            else
            {
                if(hover)
                    hover.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
