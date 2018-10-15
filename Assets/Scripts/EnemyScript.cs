using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Hazard {

    public float moveMag;
    public float pursuitMag;
    public float timer;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, GetComponent<Rigidbody>().velocity.y, 0.0f);

        Pursue(player);

        GetComponent<Rigidbody>().velocity = new Vector3(
            GetComponent<Rigidbody>().velocity.normalized.x * moveMag * Time.deltaTime,
            0,
            GetComponent<Rigidbody>().velocity.normalized.z * moveMag * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    private void Pursue(GameObject target)
    {
        if (player)
        {
            GetComponent<Rigidbody>().velocity += ((target.transform.position + (target.GetComponent<Rigidbody>().velocity * Time.deltaTime * pursuitMag)) - transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Hazard"))
        {
            gameObject.SetActive(false);
        }
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
            throw new System.Exception("invalid gameobject 'Ground' in EnemyScript");
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
