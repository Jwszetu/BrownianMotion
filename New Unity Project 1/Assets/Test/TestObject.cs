﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 150);
	}
}
