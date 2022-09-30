using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBike : MonoBehaviour {
    public float total;
	// Use this for initialization
	void Start () {
        total = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (total <= 90.0f)
        {
            transform.RotateAround(transform.position, Vector3.forward, 80 * Time.deltaTime);
            total = total + 80 * Time.deltaTime;

        }

    }
}
