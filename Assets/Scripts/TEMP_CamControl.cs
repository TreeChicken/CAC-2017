﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_CamControl : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.up, Input.GetAxis ("Horizontal"));
	
	}
}
