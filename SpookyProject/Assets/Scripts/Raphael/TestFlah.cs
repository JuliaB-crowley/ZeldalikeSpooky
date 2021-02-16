using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlah : MonoBehaviour
{
    public Transform flashTransform;
    public float flashRange;
    [SerializeField] LayerMask affectedLayers;
    public bool hasFlashed = false;

    void Start()
    {
        flashTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        Collider[] objects = Physics.OverlapSphere(flashTransform.position, flashRange, affectedLayers);

        if (hasFlashed)
        {
            foreach (Collider obj in objects)
            {
                if (obj.GetComponent<TestInvisibleInk>())
                {
                    obj.GetComponent<TestInvisibleInk>().hasBeenFlashed = true;
                }
            }
            hasFlashed = false;
        }        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(flashTransform.position, flashRange);
    }
}
