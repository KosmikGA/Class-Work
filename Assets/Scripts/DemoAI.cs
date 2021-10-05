using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemoAI : MonoBehaviour
{

    //AI
    NavMeshAgent agent = null;
    GameObject targetPoint = null;

    //raycast
    public float dist = 10;
    public LayerMask mask;
    public GameObject player;

    GameObject hitTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPoint = new GameObject("TargetPoint");
        hitTarget = targetPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = new Vector3(Mathf.Sin(Time.time), 0, 1);
        //agent.Move(direction * Time.deltaTime * 5);

        Vector3 dir = player.transform.position - transform.position;


        RaycastHit hit;
        Debug.DrawRay(player.transform.position, dir, Color.green);
        if (Physics.Raycast(transform.position, dir, out hit, dist, mask))
        {
            hitTarget = hit.transform.gameObject;
        }
        agent.SetDestination(hitTarget.transform.position);

    }
}  
