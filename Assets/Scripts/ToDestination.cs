using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToDestination : MonoBehaviour
{

    public Transform target;    //목표 지점

    NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
