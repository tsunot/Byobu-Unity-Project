using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour {
    System.Random r = new System.Random(1);
    private int init_rad = 270;
    private float randx = 0;
    private float randy = 0;
    private float ac_rad = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        randx = r.Next(-3, 3);
        randy = r.Next(-3, 3);
        var rot = transform.rotation * Quaternion.Euler(randx, randy, 0);
        transform.rotation = rot;
    }
}
