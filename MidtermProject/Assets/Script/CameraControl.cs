using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform followObject;
    private Vector3 moveTemp;
    public float y;
    public float x;
    // Start is called before the first frame update
    void Start()
    {
        moveTemp = followObject.transform.position;
        y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveTemp = followObject.transform.position;
        //moveTemp.x -=2f;
        if (moveTemp.x < 0f) moveTemp.x = 0f;
        if (moveTemp.x > 109f) moveTemp.x = 109f;
        moveTemp.z = -1000f;
        moveTemp.y = y;
        transform.position = moveTemp;
    }
}
