using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJoint : MonoBehaviour
{
    public float cameraHeight;
    private float ZPos;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = 12;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(0, cameraHeight, ZPos);

        //playerTransform.transform.position.z + 3.5f;

        //transform.position = new Vector3(0, cameraHeight, ZPos);
        //transform.position = new Vector3(0, cameraHeight, transform.position.z);

        //ZPos = Mathf.Clamp((playerTransform.transform.position.z ) - gameObject.transform.position.z, -20f, 20f);

        //ZPos += playerTransform.transform.position.z + PlayerScript.moveSpeed;

        if (playerTransform.transform.position.z - gameObject.transform.position.z >= 1f)
        {
            ZPos += PlayerScript.staticSpeed;
        }

        if (playerTransform.transform.position.z - gameObject.transform.position.z <= -4.5f)
        {
            ZPos -= PlayerScript.staticSpeed;
        }

        //Debug.Log(playerTransform.transform.position.z - gameObject.transform.position.z);
    }
}
