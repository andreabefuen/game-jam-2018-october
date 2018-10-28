using UnityEngine;

public class Level : MonoBehaviour
{
    public int numberOfEnemies;
    public int levelSeconds;

    void Start()
    {
        GameManager.instance.directionalLightRGBAnimation.Stop();
        GameManager.instance.directionalLightRGBAnimation.GetComponent<Light>().color = new Color32(130, 130, 130, 255);
        GameManager.instance.numberOfTotalEnemies = numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void OnDestroy()
    {
        numberOfEnemies = 0;
    }
}
