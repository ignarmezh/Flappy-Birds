using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGroundSvroll : MonoBehaviour {


    public float speed = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed*0.1f, 0f);
	}
}
