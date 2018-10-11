using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : Hazard {

    public float timerLimit;
    public float deathRange;
    public Color startColor;
    public Color endColor;

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
        }
        GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, endColor, timer / timerLimit);
	}

    public override void Implement()
    {

    }
}
