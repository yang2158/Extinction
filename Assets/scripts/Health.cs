using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathAni;
    public int health = 1;
    public int maxHealth = 1;
    void Start()
    {
        maxHealth = health;
    }
    int getHealth()
    {
        return maxHealth;
    }
    public bool canHeal()
    {
        return maxHealth>health;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        health = Mathf.Min(health, maxHealth);
        if(health <= 0)
        {
            if (deathAni.GetComponent<Animator>())
            {
                GameObject ob = GameObject.Instantiate(deathAni, transform.position, Quaternion.identity,gameObject.transform);
                ob.transform.localScale = Vector3.one*7f;
                ob.transform.SetParent(null, true);
            }
            GameObject.Destroy(gameObject);
        }
    }
}
