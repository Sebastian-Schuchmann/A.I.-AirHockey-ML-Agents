using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Puck : MonoBehaviour
{
    public AirhockeyAgent redAgent;
    public AirhockeyAgent blueAgent;
    public Scorekeeper scorekeeper;

    private Vector3 startPosition;
    private Rigidbody rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedGoal"))
        {
            Respawn();
            blueAgent?.AddReward(1.0f);
            redAgent.AddReward(-1.0f);
            scorekeeper.AddBlueScore();

            blueAgent?.EndEpisode();
            redAgent.EndEpisode();
        }
        else if (collision.gameObject.CompareTag("BlueGoal"))
        {
            Respawn();
            redAgent.AddReward(1.0f);
            blueAgent?.AddReward(-1.0f);
            scorekeeper.AddRedScore();

            blueAgent?.EndEpisode();
            redAgent.EndEpisode();
        }
    }

    private void Respawn()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        rb.velocity = Vector3.zero;
    }
}
