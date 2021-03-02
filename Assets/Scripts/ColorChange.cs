using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField]
    private GameObject helper;

    private Renderer helperRenderer;

    private BoxCollider helpColl;

    private Color newHelpColor;

    public float R, G, B;

    private float shade;

    // Start is called before the first frame update
    void Start()
    {
        helperRenderer = helper.GetComponent<Renderer>();
        helpColl = helper.GetComponent<BoxCollider>();
        GetColor();
    }

    // Update is called once per frame
    void Update()
    {
        newHelpColor = new Color(R, G, B, 1f);

        helperRenderer.material.SetColor("_Color", newHelpColor);

        if(R >= 1 && G >= 1 && B >= 1)
        {
            //Debug.Log("STOP CARING");

            helpColl.isTrigger = true;
        }
    }

    void GetColor()
    {
        R = Random.Range(0.01f, 0.9f);
        G = Random.Range(0.01f, 0.9f);
        B = Random.Range(0.01f, 0.9f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (R <= 1)
        {
            R += 0.002f;
        }

        if (G <= 1)
        {
            G += 0.002f;
        }

        if (B <= 1)
        {
            B += 0.002f;
        }
    }
}
