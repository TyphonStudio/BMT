using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOnClick : MonoBehaviour {

    [SerializeField]
    private LayerMask floorLayer;

    public Transform aimTransform;

    NavMeshAgent agent;

    Vector3 aimOnGround;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, floorLayer))
            {
                aimOnGround = new Vector3(hit.point.x, 0, hit.point.z);

                aimTransform.position = aimOnGround;
                agent.SetDestination(aimOnGround);
            }
        }
    }
}
