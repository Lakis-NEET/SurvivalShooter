using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory{get { return factory as IFactory; }}

    void Start ()
    {
        //Eksekusi fungsi spawn sesuai dengan spawn time
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //jika player telah mati maka enemy baru berhenti muncul
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //mendapatkan nilai secara random
        int spawnPointIndex = Random.Range (0,3);
        int spawnEnemy = Random.Range(0, 3);

        //Menduplikasi enemy
        Factory.FactoryMethod(spawnEnemy, spawnPointIndex);
    }
}
