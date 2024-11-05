using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week9 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private ForceMode2D forceMode;
    [SerializeField] private float groundCheckDistance = 5f;
    [SerializeField] private LayerMask jumpLayerMask;



    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnValidate()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, 5);
        Debug.DrawRay(transform.position, Vector2.right * 1000, Color.red);
                
        if (hitInfo.collider != null)
        {
            print(hitInfo.collider.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
        }

        if (Input.GetButtonDown("Jump"))
            body.AddForce(Vector2.up * jumpForce, forceMode);
    }
}
