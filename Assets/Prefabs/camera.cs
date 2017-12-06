using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, DisallowMultipleComponent]
public class camera : MonoBehaviour
{
    public Transform target;

    float t = 0.0f;



    //public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    [SerializeField]
    private float distance = 4.0f; // distance from following object
    [SerializeField]
    private float polarAngle = 45.0f; // angle with y-axis
    [SerializeField]
    private float azimuthalAngle = 45.0f; // angle with x-axis

    [SerializeField]
    private float minDistance = 1.0f;
    [SerializeField]
    private float maxDistance = 7.0f;
    [SerializeField]
    private float minPolarAngle = 5.0f;
    [SerializeField]
    private float maxPolarAngle = 75.0f;
    [SerializeField]
    private float mouseXSensitivity = 5.0f;
    [SerializeField]
    private float mouseYSensitivity = 5.0f;
    [SerializeField]
    private float scrollSensitivity = 5.0f;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    void updateAngle(float x, float y)
    {
        x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);

        y = polarAngle + y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}
// Use this for initialization
/*
void Start()
{
    target = GameObject.FindWithTag("Player").transform;

    Target = GetComponent<Camera>() as Camera;
    _state = new IdleState(7f);
    Enabled = true;
}

// Update is called once per frame
void Update()
{

    transform.position = target.position + new Vector3(-2.5f * Mathf.Sin(t * (Mathf.PI / 180)), 1.2f, -2.5f * Mathf.Cos(t * (Mathf.PI / 180)));
    if (Input.GetKey("a"))
    {
        t += 2.5f;
        transform.Rotate(new Vector3(0, 1.0f, 0), 2.5f);
    }
    else if (Input.GetKey("s"))
    {
        t -= 2.5f;
        transform.Rotate(new Vector3(0, 1.0f, 0), -2.5f);
    }


}
}   */
