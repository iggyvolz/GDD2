﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject[] hazardPrefabs;

    private List<GameObject> activeHazards;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
