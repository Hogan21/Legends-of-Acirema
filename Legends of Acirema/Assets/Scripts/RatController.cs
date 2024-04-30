using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        agent.SetDestination(transform.position + new Vector3(Random.Range(-0.2f,0.2f),0, Random.Range(-0.2f, 0.2f)));
    }
    void Attack()
    {
        agent.SetDestination(player.transform.position);
    }
}
