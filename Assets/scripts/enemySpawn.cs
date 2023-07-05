using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemySpawn : MonoBehaviour
{
    public float waveLength = 20;
    public float wave = 0;
    float difficulty= 1.4f;
    public float time = 0;
    public float spawnArea = 45;
    public Transform bulletLocal;
    public GameObject enemies ;
    public GameObject template;
    public GameObject BIGBOItemplate;
    public GameObject ally;
    public Text warning;
    public varables money;
    public bool trig = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemies.transform.childCount == 0)
        {
            warning.text = "Wave " + (wave + 1) + " in " + (waveLength - time).ToString("F1") + "s";
            time += Time.deltaTime;
            if (time > waveLength || trig)
            {

                trig = false;
                time = 0;
                wave++;
                int strength = (int)(difficulty * Mathf.Pow(wave, 1.7f));

                for (int i = 0; i < strength; i++)
                {

                    float rad = (Random.Range(-spawnArea / 2f, spawnArea/2f)+ 90f) * Mathf.Deg2Rad;
                    spawnArea += 10;
                    spawnArea = Mathf.Min(spawnArea, 360);
                    EnemyDetect spawned = GameObject.Instantiate(template, new Vector3(Mathf.Cos(rad) * 200, Mathf.Sin(rad) * 200, template.transform.position.z), Quaternion.identity, enemies.transform).GetComponent<EnemyDetect>();
                    spawned.gameObject.transform.position = new Vector3(Mathf.Cos(rad) * 200, Mathf.Sin(rad) * 200, template.transform.position.z);
                    spawned.bulletLocal = bulletLocal;
                    
                    spawned.enemies = ally;
                    
                }

                for (int i = 0; i < strength/5; i++)
                {

                    float rad = (Random.Range(-spawnArea / 2f, spawnArea / 2f) + 90f) * Mathf.Deg2Rad;
                    EnemyDetect spawned = GameObject.Instantiate(BIGBOItemplate, new Vector3(Mathf.Cos(rad) * 200, Mathf.Sin(rad) * 200, template.transform.position.z), Quaternion.identity, enemies.transform).GetComponent<EnemyDetect>();
                    spawned.gameObject.transform.position = new Vector3(Mathf.Cos(rad) * 200, Mathf.Sin(rad) * 200, template.transform.position.z);
                    spawned.bulletLocal = bulletLocal;
                    
                    spawned.enemies = ally;

                }
                if (money)
                {
                    money.money += strength;
                }
            }
        }
        else
        {
            warning.text = enemies.transform.childCount + " enemies Remain";
        }
    }
}
