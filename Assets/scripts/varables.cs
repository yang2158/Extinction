using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class varables : MonoBehaviour
{
    public int money= 0 ;
    public int income=3;
    public Transform enemies;
    public float delay;
    public Text txt;
    float time = 1;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time> delay &&enemies.childCount==0 ) {
            time %= delay;
            money += income;
            txt.text = money + "     +" + income;
            
        }
    }
}
