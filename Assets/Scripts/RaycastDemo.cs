using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDemo : MonoBehaviour
{
    public LayerMask mask;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Debug.DrawRay(player.transform.position, transform.forward * 10, Color.green);
            if(Physics.Raycast(player.transform.position, transform.forward, out hit, 10, mask))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
