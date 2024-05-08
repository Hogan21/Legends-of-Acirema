using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject model;
    [SerializeField] private bool isProjectile;
    [SerializeField] private bool isEnemy;
    public bool targetHit;
    private bool groundDestroyTrigger = true;
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
        if (isEnemy)
        {
            if (other.CompareTag("Player"))
            {
                Health health = other.GetComponent<Health>();
                health.health -= damage;
                if (health.health > 0 && health.isHit == false)
                {
                    targetHit = true;
                    health.isHit = true;
                    groundDestroyTrigger = false;
                    StartCoroutine(Wait(other));
                }
            }
        }else
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponentInChildren<Renderer>().material.color = Color.red;
                Health health = other.GetComponent<Health>();
                health.health -= damage;
                if (health.health > 0 && health.isHit == false)
                {
                    targetHit = true;
                    health.isHit = true;
                    groundDestroyTrigger = false;
                    StartCoroutine(Wait(other));
                }
                if (isProjectile) { Destroy(model.gameObject); }
            }
        }

        if (other.gameObject.CompareTag("Ground") && isProjectile)
        {
            if (groundDestroyTrigger == true) { Destroy(gameObject); }
        }
    }

    IEnumerator Wait(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        other.GetComponent<Health>().isHit = false;
        other.GetComponentInChildren<Renderer>().material.color = Color.white;

        if (isProjectile) { Destroy(gameObject); }
    }
}
