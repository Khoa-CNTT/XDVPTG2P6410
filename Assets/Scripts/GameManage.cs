using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int currentEnergry;
    [SerializeField] private int energryThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemyspawner;

    private bool bossSpawned = false;
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addEnergry()
    {
        if (bossSpawned=true) { return; }
        currentEnergry += 1;
        if(currentEnergry == energryThreshold)
        {
            callboss();
        }
    }
    private void callboss()
    {
        bossSpawned = true;
        boss.SetActive(true);
        enemyspawner.SetActive(false);

    }
}

