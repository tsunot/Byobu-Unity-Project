using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Contrller : MonoBehaviour {

	SteamVR_TrackedObject trackObj;
	//public GameObject fire;
	public Transform target;
	public ParticleSystem fire;
	public ParticleSystem ps;
	// Use this for initialization
	void Start () {
		trackObj = GetComponent<SteamVR_TrackedObject>();
		GameObject fire = GameObject.FindWithTag("Fire");
		target = fire.transform;
		ps = fire.GetComponent<ParticleSystem> ();
		//print (ps.startColor);
		ps.startColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackObj.index);
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
		{
			//GameObject fireObj = Instantiate(fire, transform.position, Quaternion.identity) as GameObject;
			target.position = transform.position + new Vector3(0.0f,0.07f,0.0f);
			//ps.velocityOverLifetime = device.velocity;
		}

		Vector2 pos = device.GetAxis();
		if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			ps.startColor += new Color(-pos.x/500.0f, 0, pos.x/500.0f, 0);
			if(ps.startColor[2] < 0.0f)
			{
				ps.startColor = new Color (ps.startColor[0], ps.startColor[1], 0.0f, ps.startColor[3]);
			}
			else if(ps.startColor[2] > 1.0f)
			{
				ps.startColor = new Color (ps.startColor[0], ps.startColor[1], 1.0f, ps.startColor[3]);
			}
			if(ps.startColor[0] < 0.0f)
			{
				ps.startColor = new Color (0.0f, ps.startColor[1], ps.startColor[2], ps.startColor[3]);
			}
			else if(ps.startColor[0] > 1.0f)
			{
				ps.startColor = new Color (1.0f, ps.startColor[1], ps.startColor[2], ps.startColor[3]);
			}

			print (ps.startColor);
			ps.startLifetime += pos.y/20.0f;
			//print (pos.y);
		}
	}
}