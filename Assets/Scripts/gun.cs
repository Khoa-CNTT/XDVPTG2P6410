using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using TMPro;

public class gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotdelay = 0.15f;
    private float nextshot;
    [SerializeField] private int maxAmmo = 25;
    public int currentAmmo;
    [SerializeField] private TextMeshProUGUI ammoText;
    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }


    void Update()
    {
        rotategun();
        shoot();
        Reload();
        

    }
    void rotategun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotateOffset));
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else { transform.localScale = new Vector3(1, -1, 1); }
    }
    void shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextshot)
        {
            nextshot = Time.time + shotdelay;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
        }
    }
    void Reload()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
        }

    }
    private void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            if (currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Empty";
            }
        }
    }
}
