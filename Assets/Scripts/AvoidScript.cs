using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidScript : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public bool collisonCheck;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        thrust = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(collisonCheck == true)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            rb.AddForce(transform.up * thrust);
            rb.AddForce(transform.forward * thrust);

            if(timer >= 0.2f)
            {
                collisonCheck = false;
            }
        }

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Wall1")
        {
            collisonCheck = true;
            timer = 0;
        }
    }
}
