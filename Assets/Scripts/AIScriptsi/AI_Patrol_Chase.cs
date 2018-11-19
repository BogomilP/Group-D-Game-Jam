using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Patrol_Chase : MonoBehaviour {

    public Vector3[] nodes;
    public int nextTarget;

    NavMeshAgent agent;
    LineRenderer line;

    const string Action_P1 = "P1";
    const string Action_P2 = "P2";
    const string Action_Patrol = "patrol";

    Transform target;

    

    void Start()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.startColor = Color.yellow;
        line.endColor = Color.yellow;

        agent = this.GetComponent<NavMeshAgent>();

        if (nodes.Length > 0)
        {
            this.transform.position = nodes[nextTarget];

            nextTarget = (nextTarget + 1) % nodes.Length;
            agent.SetDestination(nodes[nextTarget]);
        }
    }

    void Update()
    {
        if(nextTarget == 3)
        {
            nextTarget = 0;
        }

        switch (DecideWhatToDo())
        {
            case Action_P1:
                {
                    agent.SetDestination(GameObject.Find("Player1").transform.position);
                }
                break;

            case Action_P2:
                {
                    Debug.Log("P222");
                    agent.SetDestination(GameObject.Find("Player2").transform.position);
                }
                break;

            case Action_Patrol:
                {
                    if (nodes.Length > 0)
                    {
                        if (!agent.pathPending)
                        {
                            if (agent.remainingDistance <= agent.stoppingDistance)
                            {
                                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                                {
                                    nextTarget = (nextTarget + 1) % nodes.Length;
                                    agent.SetDestination(nodes[nextTarget]);
                                }
                            }
                        }

                        DrawRoutePath();
                    }
                }
                break;
        }
    }


    void DrawRoutePath()
    {
        var path = agent.path;

        line.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
    }

    string DecideWhatToDo()
    {
        var dir = GameObject.Find("Player1").transform.position - transform.position;
        dir.Normalize();
        RaycastHit hit;

        Physics.Raycast(transform.position, dir, out hit);

        var dir2 = GameObject.Find("Player2").transform.position - transform.position;
        dir2.Normalize();
        RaycastHit hit2;

        Physics.Raycast(transform.position, dir2, out hit2);

        if (hit.collider != null)
        {
            Debug.Log("collider");
            if (hit.collider.gameObject.name.ToLower().Contains("player1") == true && FOVDetection.instance.isInFOV == true)
            {
                Debug.Log("player1");
                return Action_P1;
            }

            if (hit2.collider.gameObject.name.ToLower().Contains("player2") == true && FOVDetection2.instance.isInFOV == true)
            {
                Debug.Log("player2");
                return Action_P2;
            }
        }

        return Action_Patrol;
    }
}
