using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public Transform wheel;
    public Transform pushers;

    [SerializeField] private float maxSpeed;
    [Range(0,10)]
    [SerializeField] private float maxForce;

    Rigidbody rb;

    Vector3 desired;

    Vector3 pushVector;

    [SerializeField] float slowDownDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //ConsiderPushers();
        SeekWheel();
    }

    void SeekWheel()
    {
        desired = wheel.position - transform.position;
        desired.y = 0;

        float distance = desired.magnitude;
        desired.Normalize();

        if(distance < slowDownDistance)
        {
            float m = Mathf.Lerp(0, maxSpeed, distance / slowDownDistance);
            Debug.Log(m);

            desired *= m;
        }
        else
        {
            desired *= maxSpeed;
        }

        Vector3 steer = desired - rb.velocity;
        var clampedSteer = Vector3.ClampMagnitude(steer, maxForce);

        rb.AddForce(clampedSteer, ForceMode.VelocityChange);

        Debug.DrawRay(transform.position, rb.velocity, Color.blue);
        Debug.DrawRay(transform.position, desired, Color.magenta);
        Debug.DrawRay(transform.position, clampedSteer, Color.red);
    }



    void Arrive()
    {

    }

    void ConsiderPushers()
    {
        var allPushers = pushers.GetComponentsInChildren<Pusher>();

        pushVector = Vector3.zero;

        foreach(var pusher in allPushers)
        {
            Vector3 desired = (transform.position - pusher.transform.position);
            desired.y = 0;
            float distance = desired.magnitude;
            desired.Normalize();
            desired *= (1 / distance);

            pushVector += desired;
        }
    }
}
