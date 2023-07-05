using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class menuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(click);
    }

    // Update is called once per frame
    
    void click()
    {
        Debug.Log("Click");
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        
    }
     
}
