using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject[] hazardPrefabs;
    public float interval;

    //private List<GameObject> activeHazards;
    private float timer;
    private bool odd;

	// Use this for initialization
	void Start ()
    {
        timer = 0;
        odd = true;
        if (interval <= 0)
        {
            throw new System.Exception("Something cannot every at or less than every 0 seconds. Change interval in the GameManager Prefab");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
		if (timer >= interval)
        {
            timer -= interval;
            GameObject nextHazard = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];
            Vector3 nextHazardPosition;
            Quaternion nextHazardRotation;

            if (odd)
            {
                nextHazardPosition = nextHazard.GetComponent<Hazard>().GetImplementLoc1();
                nextHazardRotation = nextHazard.GetComponent<Hazard>().GetImplementRot1();
            }
            else
            {
                nextHazardPosition = nextHazard.GetComponent<Hazard>().GetImplementLoc2();
                nextHazardRotation = nextHazard.GetComponent<Hazard>().GetImplementRot2();
            }
            odd = !odd;

            Instantiate(nextHazard, nextHazardPosition, nextHazardRotation);
        }
	}
}
