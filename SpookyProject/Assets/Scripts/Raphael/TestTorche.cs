using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTorche : MonoBehaviour
{
    public Material torcheMaterial;
    public bool isLit = false;

   
    void Update()
    {
        if (isLit)
        {
            torcheMaterial.color = Color.red;
        }
        else
        {
            torcheMaterial.color = Color.black;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLit)
        {
            if (other.GetComponent<TestInvisibleInk>())
            {
                other.GetComponent<TestInvisibleInk>().mesh.enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isLit)
        {
            if (other.GetComponent<TestInvisibleInk>())
            {
                other.GetComponent<TestInvisibleInk>().mesh.enabled = false;
            }
        }
    }
}
