using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{

    public GameObject plane;
    Collider2D planeCollider;
    public static bool canLand;


    // Start is called before the first frame update
    void Start()
    {
        planeCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (planeCollider.OverlapPoint(Vector2.zero))
        {
            plane.canLand = true;
        }
    }

}
