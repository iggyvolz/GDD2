using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBombScript : Hazard {
    
    public float deathRange;
    public float fallHeight;

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

    public override Vector3 GetImplementLoc1()
    {
        GameObject ground = GameObject.Find("Ground");
        if (ground)
        {
            return new Vector3(
                Random.Range(ground.transform.position.x - (ground.transform.localScale.x / 2), ground.transform.position.x + (ground.transform.localScale.x / 2)),
                fallHeight,
                Random.Range(ground.transform.position.z - (ground.transform.localScale.z / 2), ground.transform.position.z + (ground.transform.localScale.z / 2)));
        }
        else
        {
            throw new System.Exception("invalid gameobject 'Ground' in FallingBombScript");
        }
    }

    public override Vector3 GetImplementLoc2()
    {
        return GetImplementLoc1();
    }

    public override Quaternion GetImplementRot1()
    {
        return Quaternion.identity;
    }

    public override Quaternion GetImplementRot2()
    {
        return Quaternion.identity;
    }
}
