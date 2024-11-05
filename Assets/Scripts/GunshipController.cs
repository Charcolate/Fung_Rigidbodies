using UnityEngine;

public class GunshipController : MonoBehaviour
{
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;

    public GameObject cannonballPrefab;
    public float cannonballForce = 150f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 leftDirection = AimCannon(mousePosition, leftCannon);
        Vector3 rightDirection = AimCannon(mousePosition, rightCannon);

        if (Input.GetButtonDown("Fire1"))
            FireCannonball(leftDirection, leftCannon);

        if (Input.GetButtonDown("Fire2"))
            FireCannonball(rightDirection, rightCannon);
    }

    private Vector3 AimCannon(Vector3 target, Transform cannon)
    {
        Vector3 direction = target - cannon.position;
        direction.z = 0;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        cannon.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        return direction;
    }

    private void FireCannonball(Vector3 direction, Transform cannon)
    {
        GameObject cannonball = Instantiate(cannonballPrefab, cannon.position + cannon.right, Quaternion.identity);
        cannonball.GetComponent<Rigidbody2D>().AddForce(direction.normalized * cannonballForce);

    }
}
