using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class playButton : MonoBehaviour
{
    // Start is called before the first frame update
    bool start = false;
    public Image blinds;
    float opacity = 0;
    public float seconds = 0.5f;
    public AudioSource theme;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(click);
    }

    // Update is called once per frame
    void Update()
    {
        if (blinds)
        {
            if (start)
                opacity += 1f / seconds * Time.deltaTime;

            blinds.color = new Color(0f, 0f, 0f, opacity);
            theme.volume = 1 - opacity;

            if (blinds.color.a >= 0.98f)
                SceneManager.LoadScene("game", LoadSceneMode.Single);
        }
    }
    void click()
    {
        if (!blinds)
        {
            SceneManager.LoadScene("game", LoadSceneMode.Single);
        }
        else
        {
            start = true;

            blinds.gameObject.SetActive(true);
        }
    }
     
}
