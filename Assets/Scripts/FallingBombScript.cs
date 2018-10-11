using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBombScript : Hazard {
    
    public float deathRange;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if ((player.transform.position - transform.position).magnitude <= deathRange)
            {
                Destroy(player);
            }
            Destroy(gameObject);
        }
    }

    public override void Implement()
    {

    }
}
