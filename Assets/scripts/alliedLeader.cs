using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class alliedLeader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverScreen;
    public GameObject[] disableGameOnEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        gameOverScreen.SetActive(true);
        for( int i = 0; i < disableGameOnEnd.Length; i++)
        {
            disableGameOnEnd[i].SetActive(false);
        }
    }
}
