using UnityEngine;

public class Level : MonoBehaviour
{
    public float numberOfEnemies;
    public int levelSeconds;

    // Descomenta esto cuando pongas los enemigos dentro del nivel
    void Start()
    {
        numberOfEnemies = GameManager.instance.numberOfTotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
