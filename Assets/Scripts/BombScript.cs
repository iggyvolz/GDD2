using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : Hazard {

    public float timerLimit;
    public float deathRange;
    public Color startColor;
    public Color endColor;

    //Explosion prefab holder
    public GameObject explosion;

    private GameObject player;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= timerLimit)
        {
            timer = timerLimit;
            if (player && (player.transform.position - transform.position).magnitude <= deathRange)
            {
                Destroy(player);
            }
            Destroy(gameObject);
            GameObject explosionSpawn = Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
        GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, endColor, timer / timerLimit);
	}

    public override Vector3 GetImplementLoc1()
    {
        GameObject ground = GameObject.Find("Ground");
        if (ground)
        {
            return new Vector3(
                Random.Range(ground.transform.position.x - (ground.transform.localScale.x / 2), ground.transform.position.x + (ground.transform.localScale.x / 2)),
                1.5f,
                Random.Range(ground.transform.position.z - (ground.transform.localScale.z / 2), ground.transform.position.z + (ground.transform.localScale.z / 2)));
        }
        else
        {
            throw new System.Exception("invalid gameobject 'Ground' in BombScript");
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
