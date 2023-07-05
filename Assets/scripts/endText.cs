using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class endText : MonoBehaviour
{
    public GameObject enemi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "You've gone Extinct!\nWave "+ enemi.GetComponent<enemySpawn>().wave;
    }
}
