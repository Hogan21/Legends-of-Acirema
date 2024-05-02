using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponentInChildren<Renderer>().material.color = Color.red;
            Health health = other.GetComponent<Health>();
            health.health -= damage;
            if (health.health > 0 && health.isHit == false)
            {
                health.isHit = true;
                StartCoroutine(Wait(other));
            }
        }
    }

    IEnumerator Wait(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        other.GetComponent<Health>().isHit = false;
        other.GetComponentInChildren<Renderer>().material.color = Color.white;
    }
}
