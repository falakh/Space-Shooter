using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLimiter : MonoBehaviour {
    public float maxX, minX, maxY, minY;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
    }
}
