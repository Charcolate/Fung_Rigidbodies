using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9Research : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * 5f * Time.deltaTime);
    }
}
