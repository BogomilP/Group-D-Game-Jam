using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;

    private NavMeshAgent agent;


    void Start ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "1")
        {
            Debug.Log("Pos2");
            agent.SetDestination(pos2.position);
        }
        if (other.tag == "2")
        {
            Debug.Log("Pos3");
            agent.SetDestination(pos3.position);
        }
        if (other.tag == "3")
        {
            Debug.Log("Pos4");
            agent.SetDestination(pos4.position);
        }
        if (other.tag == "4")
        {
            Debug.Log("Pos1");
            agent.SetDestination(pos1.position);
        }
    }
}
