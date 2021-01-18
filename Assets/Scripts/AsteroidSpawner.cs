using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    Sprite[] asteroidSprites = new Sprite[3];

    Timer asteroidSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        asteroidSpawnTimer = gameObject.AddComponent<Timer>();
        asteroidSpawnTimer.Duration = 1;
        asteroidSpawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidSpawnTimer.Finished)
        {
            Vector3 position = new Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), 
                Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop), 0);

            GameObject asteroid =  Instantiate(asteroidPrefab, position, Quaternion.identity);
            SpriteRenderer asteroidSpriteRenderer = asteroid.GetComponent<SpriteRenderer>();
            asteroidSpriteRenderer.sprite = GenerateSprite();

            asteroidSpawnTimer.Run();
        }
    }

    Sprite GenerateSprite()
    {
        return asteroidSprites[Random.Range(0, 3)];
    }
}
