using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject Wallme;
    public bool collisionCheck;
    public bool isDown;
    public float timer;
    private float changeSpeed;

    private bool wallclear;
    public float walldowncheck;

    public GameObject playerCube;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        isDown = true;
        changeSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + changeSpeed);

        timer += Time.deltaTime;

        if (transform.localScale.z >= 0f)
        {
            Debug.Log("Down bad");
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
            transform.position = new Vector3(transform.localScale.x, 0, transform.localScale.z);
            wallgobye();
        }

        if (isDown == false)
        {
            changeSpeed = 0.001F;
        }

        if (isDown == true)
        {
            if (transform.localScale.z >= -6.5)
            {
                changeSpeed = -0.001F;
            }

            else
            {
                changeSpeed = 0F;
            }
        }

        if(wallclear == true)
        {
            walldowncheck += 1;
            wallclear = false;
        }

        if(walldowncheck >= 2)
        {
            playerCube.SetActive(false);
            heart.SetActive(true);
        }

        if (walldowncheck >= 3)
        {
            //victory
        }

        if(PlayerScript.finish == true)
        {
            walldowncheck = 2;
            isDown = false;
        }

        //if(collisionCheck == true)
        //{
        //    isDown = false;

        //    if (timer >= 3)
        //    {
        //        isDown = true;
        //        collisionCheck = false;
        //        //Debug.Log("TIMES UP");
        //    }
        //}

        //Vector3 scale = transform.localScale;
        //scale.y = -12f; // your new value
        //transform.localScale = scale;
    }
                                                            //NOTES

    //Make it so when touching helper wall goes down, but when not, wall goes up
    //add colors to helper cubes
    //change cube once walls are up
    //add music

    void wallgobye()
    {
        if(wallclear == false)
        {
            wallclear = true;
        }
    }

    void theOneHasCome()
    {
        PlayerScript.finish = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Helper")
        {
            isDown = false;

            //timer = 0;
            //collisionCheck = true;

            //gameObject.GetComponent<MeshCollider>().enabled = false;
            //Debug.Log("Collide");
        }

        if (collision.collider.name == "theOne")
        {
            PlayerScript.staticSpeed = 0;
            PlayerScript.staticSpeed2 = 0;
            Debug.Log("STOP");
            theOneHasCome();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Helper")
        {
            isDown = true;
        }
    }
}
