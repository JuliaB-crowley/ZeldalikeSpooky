using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_MaeveCollisionDetector : MonoBehaviour
{
    public float radius = 0.05f;
    public LayerMask blocksPlayer;
    public bool isCollision;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collision = Physics2D.OverlapCircleAll(transform.position, radius, blocksPlayer);
        isCollision = false;
        foreach(Collider2D col in collision)
        {
            isCollision = true;
        }
    }
}
