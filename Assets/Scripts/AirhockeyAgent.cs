using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class AirhockeyAgent : Agent
{
    public float speed = 4f;
    private Rigidbody rb;
    public Transform puck;
    private Vector3 startPosition;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rb.velocity / speed);
        sensor.AddObservation((transform.position - puck.position)/15f);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        //rb.AddForce(vectorAction[0], 0f, vectorAction[1]);
        rb.velocity = new Vector3(vectorAction[0], 0f, vectorAction[1]);

        AddReward(-1f / MaxStep);
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = -Input.GetAxis("Vertical") * speed;
        actionsOut[1] = Input.GetAxis("Horizontal") * speed;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(startPosition.x + Random.Range(-2f, 2f), startPosition.y, startPosition.z + Random.Range(-1f, 1f));
        rb.velocity = Vector3.zero;
    }
}
