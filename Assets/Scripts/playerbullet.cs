using UnityEngine;

public class playerbullet : MonoBehaviour
{
    [SerializeField] private float movespeed = 25f;
    [SerializeField] private float timedestroy = 0.5f;
    [SerializeField] private float dmg = 10f;
    [SerializeField] GameObject bloodPrefabs;
    void Start()
    {
        Destroy(gameObject, timedestroy);
    }

    void Update()
    {
        movebullet();
    }
    void movebullet()
    {
        transform.Translate(Vector2.right * movespeed* Time.deltaTime) ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDmg(dmg);
                GameObject blood = Instantiate(bloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }
    }
}
