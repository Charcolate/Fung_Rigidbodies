using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9Research : MonoBehaviour
{
    //interpertation 
    private Rigidbody2D rb;
    public Transform target;

    //localtoworldmatrix
    public GameObject prefab;
    public Vector3 localOffset = new Vector3(1, 1, 0);

    //totalforce
    private Vector2 totalForce;

    // Start is called before the first frame update
    void Start()
    {
        //interpertation 
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        //localtoworldmatrix
        //none

        //totalforce
        //none
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //interpertation 
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * 5f * Time.deltaTime);

        //localtoworldmatrix
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 locatiPosition = localOffset;
            Vector3 worldPosition = transform.localToWorldMatrix.MultiplyPoint(locatiPosition);

            Debug.Log("local Position: " + locatiPosition + "; World Position: " + worldPosition);
            Instantiate(prefab, worldPosition, Quaternion.identity);
        }

        //totalforce
       
    }
}
