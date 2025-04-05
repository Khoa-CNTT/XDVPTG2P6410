using UnityEngine;

public class gun : MonoBehaviour
{
    private float rotateoffset = 180f;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotdelay = 0.15f;
    private float nextshot;
    [SerializeField] private int maxammo = 25;
    public int currentammo;

    void Start()
    {
        currentammo = maxammo;
    }

    // Update is called once per frame
    void Update()
    {
        rotateGun();
        shoot();
        reload();
    }
    void rotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacment = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacment.y, displacment.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateoffset);
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > nextshot && currentammo > 0)
        {
            nextshot = Time.time + shotdelay;
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            currentammo--;
        }
    }
    void reload()
    {
        if (Input.GetMouseButton(1) && currentammo < maxammo)
        {
            currentammo = maxammo;
        }
    }
}
