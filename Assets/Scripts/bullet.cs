using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float movespeed = 10f;
    [SerializeField] private float timeDestroy = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        movebullet();
    }
    void movebullet()
    {
        transform.Translate(Vector2.right * movespeed * Time.deltaTime);
    }
}
