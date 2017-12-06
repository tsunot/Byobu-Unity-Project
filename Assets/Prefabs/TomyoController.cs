using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomyoController : MonoBehaviour {
    System.Random r = new System.Random(1);
    private int init_rad = 270;
    private float randx = 0;
    private float randy = 0;
    private float ac_rad = 0;
	public static Vector3 screenPos = new Vector3 (0,0,0);
	public Camera camera;
    //ParticleSystem ps = GetComponent<ParticleSystem>();
    // Use this for initialization
    void Start () {
        ac_rad = init_rad;
    }

    // Update is called once per frame
    void Update () {

		screenPos = camera.WorldToScreenPoint (transform.position);
		print (screenPos);
		//print (Screen.width);
		//print (Screen.height);
		//Vortex.setFirePos(screenPos);

        ParticleSystem ps = GetComponent<ParticleSystem>();
        randx = r.Next(-3, 3);
        //ps.gravityModifier = new Vector3(0.0f,-1.0f,0.0f);
        ps.gravityModifier = randx/3000.0f;
        if ((ac_rad + randx > 190)&&(ac_rad + randx < 350))
        {
            ac_rad = ac_rad + randx;
            randx = randx;
        }
        else
        {
            ac_rad = ac_rad - randx;
            randx = -randx;
        }
        
        randy = r.Next(-3,3);
        //var rot = transform.rotation * Quaternion.Euler(randx,randy,0);
        //transform.rotation = rot;

        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(0.05f,0,0);

        }

        else if (Input.GetKey("left"))
        {
            transform.position += new Vector3(-0.05f,0,0);
        }
        else if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, 0, 0.05f);
        }
        else if (Input.GetKey("down"))
        {
            transform.position += new Vector3(0, 0, -0.05f);
        }
        else if (Input.GetKey("r"))
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
        else if (Input.GetKey("f"))
        {
            transform.position += new Vector3(0, -0.05f, 0);
        }
        

    }
}
