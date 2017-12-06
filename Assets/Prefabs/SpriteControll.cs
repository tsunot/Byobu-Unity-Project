using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControll : MonoBehaviour
{
    public Material next_material;
    public Sprite image;
    private SpriteRenderer srenderer;

    // Use this for initialization
    void Start()
    {
        var _spriteRenderer = GetComponent<SpriteRenderer>();
        var _m = _spriteRenderer.localToWorldMatrix;
        var _sprite = _spriteRenderer.sprite;
        var _halfX = _sprite.bounds.extents.x;  //bounds.extents:half of size
        var _halfY = _sprite.bounds.extents.y;
        var _vec = new Vector3(-_halfX, _halfY, 0f);
        var _pos = _m.MultiplyPoint3x4(_vec);
        var cover_pos = _m.MultiplyPoint3x4(new Vector3(0,0,0));
        Debug.Log("1 : " + _pos);
        Debug.Log(_m);
        GameObject obj = new GameObject();
        GameObject cover = Instantiate(obj, cover_pos, Quaternion.identity) as GameObject;
        //cover.GetComponent<SpriteRenderer>().material = next_material;
        cover.AddComponent<SpriteRenderer>().sprite = image;
        cover.GetComponent<SpriteRenderer>().material = next_material;
        //Debug.Log("2 : " + GetSpriteTopLeftPosition());
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (Input.GetKey("f"))
        {
            //srenderer.material = Resources.GetBuiltinResource<Material>("origin.mat");
            this.GetComponent<SpriteRenderer>().material = next_material;
            //go.AddComponent<SpriteRenderer>().sprite = image;
        }*/
    }
}
