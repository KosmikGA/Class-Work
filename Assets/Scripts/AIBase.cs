using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBase : MonoBehaviour
{
    //AI
    GameObject targetPoint = null;

    //raycast
    public float dist = 10;
    public LayerMask mask;
    private GameObject player;

    Animator animCtrl;
    NavMeshAgent agent = null;

    //Line of Sight
    float playerDist;
    float minDetectRange = 10;
    [SerializeField] float attackRange;
    float baseAttackRange;
    [SerializeField] float fovRange = 75;
    bool brokenLos;
    public Vector3 travelTo;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDir = player.transform.position - transform.position;
        Debug.DrawRay(player.transform.position, rayDir, Color.green);
        if (Physics.Raycast(transform.position, rayDir, out hit))
        {
            if ((hit.transform.tag == "Player") && (playerDist <= minDetectRange && playerDist >= attackRange))
            {
                Debug.DrawRay(transform.position, rayDir, Color.yellow);
                //animCtrl.SetInteger("ActState", 2);
                //animCtrl.SetBool("Patrolling", false);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, rayDir * minDetectRange, Color.magenta);
            }
        }
        if (Vector3.Angle(rayDir, transform.forward) < fovRange)
        {
            if (Physics.Raycast(transform.position, rayDir, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.DrawRay(transform.position, rayDir, Color.green);
                    //animCtrl.SetInteger("ActState", 2);
                    //animCtrl.SetBool("Patrolling", false);
                    return true;
                }

                else
                {
                    //animCtrl.SetInteger("ActState", 1);
                    //animCtrl.SetBool("Patrolling", true);
                    return false;
                }
            }
        }
        Debug.DrawRay(transform.position, rayDir, Color.black);
        return false;
    }

    private void Update()
    {
        playerDist = Vector3.Distance(player.transform.position, transform.position);

        if (CanSeePlayer() == true)
        {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                if (animCtrl.GetInteger("ActState") == 2)
                {
                    animCtrl.SetInteger("ActState", 3);
                }
                else if (animCtrl.GetInteger("ActState") == 1)
                {
                    animCtrl.SetBool("Patrolling", true);
                }
            }
        }
    }

