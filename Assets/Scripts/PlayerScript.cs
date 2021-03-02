using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float autoSpeed;
    public static float staticSpeed;
    public static float staticSpeed2;

    public static bool finish;

    // Start is called before the first frame update
    void Start()
    {
        staticSpeed = 0.005f;
        staticSpeed2 = 0.001f;

        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = staticSpeed;
        autoSpeed = staticSpeed2;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + autoSpeed);

        if (Input.GetKey (KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
        }

        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed);
        //}

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        }
    }
}
