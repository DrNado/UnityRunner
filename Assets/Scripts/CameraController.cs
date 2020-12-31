using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform LookAt;
    private Vector3 OffsetCamera;
    private Vector3 CameraMove;
    void Start()
    {
        LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        OffsetCamera = transform.position - LookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove = LookAt.position + OffsetCamera;

        //x
        CameraMove.x = 0;
        //Y
        CameraMove.y = Mathf.Clamp(CameraMove.y, 3, 5);

        transform.position = CameraMove;
    }
}
