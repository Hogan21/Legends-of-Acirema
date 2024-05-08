using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public bool isHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }else if (health <= 0 && gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
        }
    }
}
