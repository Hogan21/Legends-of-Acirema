using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private Collider hitBox;
    [SerializeField] private float patrolInterval;
    [SerializeField] private GameObject biteVfx;
    [SerializeField] private GameObject bitePoint;
    private float patrolTime;
    private bool canAttack;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        hitBox.enabled = true;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > 30)
        {
            Patrol();
        } else
        {
            Attack();
        }
    }

    void Patrol()
    {
        //if (Vector3.Distance(agent.destination, player.transform.position) >)
        patrolTime += Time.deltaTime;
        if (patrolTime > patrolInterval)
        {
            agent.SetDestination(transform.position + new Vector3(Random.Range(-1f, 1f), transform.position.y, Random.Range(-1f, 1f)));
            patrolTime = 0;
        }
    }
    void Attack()
    {
        agent.SetDestination(player.transform.position);

        if (hitBox.GetComponent<Hitbox>().targetHit == true)
        {
            hitBox.GetComponent<Hitbox>().targetHit = false;
            hitBox.enabled = false;
            GameObject fangs = Instantiate(biteVfx,bitePoint.transform,false);
            StartCoroutine(VFX(fangs));
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(1);
        hitBox.enabled = true;
    }
    IEnumerator VFX(GameObject fangs)
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(fangs);
    }
}
