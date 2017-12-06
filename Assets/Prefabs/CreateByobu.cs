using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CreateByobu : MonoBehaviour {


    public Material attach_material;
    public GameObject[] one_bricks; //= new GameObject("Byobu");
    public Sprite[] image;
    public GameObject[] one_brick = new GameObject[8];
	public GameObject[] one_cover = new GameObject[8];
	private float angle = 45.0f;
	private int sign = 0;
	private float pos = Mathf.Sqrt(2.0f);
	private bool flag = false;
	private static float rate = 1.4f;
    private float width = 0.75f*rate;
	private float height = 0.69f*rate;
	private Transform[] cover_trans = new Transform[8];
	private Transform[] brick_trans = new Transform[8];
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 8; i++)
        {
            if(i%2 == 0)
            {
                sign = -1;
            }
            else
            {
                sign = 1;
            }
            
            //one_bricks[i].AddComponent<SpriteRenderer>().sprite = image[i];
            //one_bricks[i].GetComponent<SpriteRenderer>().material = attach_material;
            one_cover[i] = Instantiate(one_bricks[i], new Vector3(i * width / pos - 2.0f*rate, height, 0), Quaternion.Euler(0, sign * 45, 0));
            one_brick[i] = Instantiate(one_bricks[i], new Vector3(i * width / pos - 2.0f*rate, height, 0.01f), Quaternion.Euler(0, sign * 45, 0));
            //one_bricks[i].transform.position = new Vector3(i * width / pos - 2, 1.6f, 0);
            //one_bricks[i].transform.rotation = Quaternion.Euler(0, sign * 45, 0);
            one_cover[i].GetComponent<SpriteRenderer>().sprite = image[i];
            one_cover[i].GetComponent<SpriteRenderer>().material = attach_material;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		//int sign = 0;

		if (Input.GetKey ("a")) {
			angle += 0.5f;
			flag = true;
		}
		else if(Input.GetKey ("s"))
		{
			angle -= 0.5f;
			flag = true;
		}
		if(flag)
		{
			for (int i = 0; i < 8; i++) {
				if(i%2 == 0)
				{
					sign = -1;
				}
				else
				{
					sign = 1;
				}
				one_cover[i].transform.rotation = Quaternion.Euler(0, sign * angle, 0);
				one_brick[i].transform.rotation = Quaternion.Euler(0, sign * angle, 0);
				one_cover[i].transform.position = new Vector3(pos*Mathf.Cos(angle*(Mathf.PI/180.0f))*(i * width / pos - 2.0f*rate), height, 0);
				one_brick[i].transform.position = new Vector3(pos*Mathf.Cos(angle*(Mathf.PI/180.0f))*(i * width / pos - 2.0f*rate), height, 0.01f);
			}
			flag = false;
		}
			/*for (int i = 0; i < 8; i++) {
				if (i % 2 == 0) {
					sign = -1;
				} else {
					sign = 1;
				}

				float pos = Mathf.Sqrt (2.0f);
				//one_bricks[i].AddComponent<SpriteRenderer>().sprite = image[i];
				//one_bricks[i].GetComponent<SpriteRenderer>().material = attach_material;
				Instantiate (one_bricks [i], new Vector3 (i * width / pos - 2, 1.6f, 0), Quaternion.Euler (0, sign * angle, 0));
				one_brick [i] = Instantiate (one_bricks [i], new Vector3 (i * width / pos - 2, 1.6f, -0.01f), Quaternion.Euler (0, sign * angle, 0));
				//one_bricks[i].transform.position = new Vector3(i * width / pos - 2, 1.6f, 0);
				//one_bricks[i].transform.rotation = Quaternion.Euler(0, sign * 45, 0);
				one_brick [i].GetComponent<SpriteRenderer> ().sprite = image [i];
				one_brick [i].GetComponent<SpriteRenderer> ().material = attach_material;
			}*/
		
	}
}
