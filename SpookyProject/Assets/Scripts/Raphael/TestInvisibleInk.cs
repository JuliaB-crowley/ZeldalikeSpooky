using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInvisibleInk : MonoBehaviour
{
    public MeshRenderer mesh;
    public bool hasBeenFlashed = false;
   
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

   
    void Update()
    {
        if (hasBeenFlashed)
        {
            StartCoroutine(InkAppear());
        }
    }

    IEnumerator InkAppear()
    {
        hasBeenFlashed = false;
        mesh.enabled = true;
        yield return new WaitForSeconds(2f);
        mesh.enabled = false;
    }
}
