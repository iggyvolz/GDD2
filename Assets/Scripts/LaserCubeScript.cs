using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCubeScript : Hazard {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override Vector3 GetImplementLoc1()
    {
        GameObject ground = GameObject.Find("Ground");
        if (ground)
        {
            return new Vector3(
                ground.transform.position.x + (ground.transform.localScale.x / 2) + 5,
                ground.transform.position.y + 1,
                ground.transform.position.z + (ground.transform.localScale.z / 2) + 1);
        }
        else
        {
            throw new System.Exception("invalid gameobject 'Ground' in LaserCubeScript");
        }
    }

    public override Vector3 GetImplementRot1()
    {
        return Vector3.zero;
    }

    public override Vector3 GetImplementLoc2()
    {
        GameObject ground = GameObject.Find("Ground");
        if (ground)
        {
            return new Vector3(
                ground.transform.position.x + (ground.transform.localScale.x / 2) + 1,
                ground.transform.position.y + 1,
                ground.transform.position.z + (ground.transform.localScale.z / 2) + 5);
        }
        else
        {
            throw new System.Exception("invalid gameobject 'Ground' in LaserCubeScript");
        }
    }

    public override Vector3 GetImplementRot2()
    {
        return new Vector3(0, -90, 0);
    }
}
