using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour {

    public int score;

    public abstract Vector3 GetImplementLoc1();
    public abstract Vector3 GetImplementLoc2();
    public abstract Quaternion GetImplementRot1();
    public abstract Quaternion GetImplementRot2();

    public void Score()
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().AddScore(score);
    }
}
