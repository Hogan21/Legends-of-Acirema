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
            other.GetComponent<Renderer>().material.color = Color.red;
            other.GetComponent<Health>().health -= damage;
            if (other.GetComponent<Health>().health > 0)
            {
                StartCoroutine(Wait(other));
            }
        }
    }

    IEnumerator Wait(Collider other)
    {
        yield return new WaitForSeconds(0.3f);

        other.GetComponent<Renderer>().material.color = Color.white;
    }
}
