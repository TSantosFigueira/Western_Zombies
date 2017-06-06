using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour {

    float count;

	// Use this for initialization
	void Start () {
        count = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > count + 2) { Destroy(this.gameObject); }
	}
}
