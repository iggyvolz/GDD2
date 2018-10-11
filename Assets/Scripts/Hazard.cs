using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour {

    public int score;

    public abstract void Implement();
    public void Score()
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().AddScore(score);
    }
}
