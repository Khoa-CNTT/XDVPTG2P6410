using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedbullet=20f;
    [SerializeField] private float speedspecial = 5f;
    [SerializeField] private float healhp = 50f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillcooldown = 1f;
    private float skilltime = 0f;
    [SerializeField] private GameObject usbPrefabs;
    protected override void Update()
    {
        base.Update();
        if(Time.time >= skilltime)
        {
            Skill();
        }
    }
    protected override void die()
    {
        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.die();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            player.takedmg(enterdmg);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.takedmg(staydmg);
        }
    }
    private void normalshot()
    {
        if (player != null)
        {   Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet=bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedspecial);
        }
    }
    private void specialshot()
    {
         const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i<bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle), Mathf.Sin(Mathf.Deg2Rad*angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedbullet);
        }
    }
    private void mini()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }
    private void warp()
    {
        if(player != null)
        {
            transform.position= player.transform.position;
        }
    }
    private void randomskill()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                normalshot();
                break;
            case 1:
                specialshot();
                break;
            case 2:
                mini();
                break;
            case 3:
                warp();
                break;
        }
    }
    private void Skill() 
    { 
        skilltime = Time.time + skillcooldown;
        randomskill();
    }
}
