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

        SpriteRenderer sprite = asteroidPrefab.GetComponent<SpriteRenderer>();

        float spriteRightSide = sprite.bounds.extents.x + (float)0.5; //Distance to the right side, from your center point
        float spriteLeftSide = -sprite.bounds.extents.x - (float)0.5; //Distance to the left side
        float spriteTopSide = sprite.bounds.extents.y + (float)0.5; //Distance to the top
        float spriteBottomeSide = -sprite.bounds.extents.y - (float)0.5; //Distance to the bottom

        Vector2 position1 = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 3, ScreenUtils.ScreenRight - 3), ScreenUtils.ScreenTop + spriteTopSide);
        Vector2 position2 = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 3, ScreenUtils.ScreenRight - 3), ScreenUtils.ScreenBottom + spriteBottomeSide);
        Vector2 position3 = new Vector2(ScreenUtils.ScreenLeft + spriteLeftSide, Random.Range(ScreenUtils.ScreenBottom + 3, ScreenUtils.ScreenTop - 3));
        Vector2 position4 = new Vector2(ScreenUtils.ScreenRight + spriteRightSide, Random.Range(ScreenUtils.ScreenBottom + 3, ScreenUtils.ScreenTop - 3));

        

        GameObject asteroid1 = Instantiate(asteroidPrefab, position1, Quaternion.identity);
        GenerateSprite(asteroid1);

        GameObject asteroid2 = Instantiate(asteroidPrefab, position2, Quaternion.identity);
        GenerateSprite(asteroid2);

        GameObject asteroid3 = Instantiate(asteroidPrefab, position3, Quaternion.identity);
        GenerateSprite(asteroid3);

        GameObject asteroid4 = Instantiate(asteroidPrefab, position4, Quaternion.identity);
        GenerateSprite(asteroid4);
    }

    // Update is called once per frame
    void Update()
    {
        //if (asteroidSpawnTimer.Finished)
        //{
        //    ScreenUtils.Initialize();
        //    Vector3 position = new Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), 
        //        Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop), 0);

        //    GameObject asteroid =  Instantiate(asteroidPrefab, position, Quaternion.identity);
        //    SpriteRenderer asteroidSpriteRenderer = asteroid.GetComponent<SpriteRenderer>();
        //    asteroidSpriteRenderer.sprite = GenerateSprite();

        //    asteroidSpawnTimer.Run();
        //}

        


    }

    void GenerateSprite(GameObject asteroid)
    {
        SpriteRenderer asteroidSpriteRenderer = asteroid.GetComponent<SpriteRenderer>();
        asteroidSpriteRenderer.sprite = asteroidSprites[Random.Range(0, 3)];
    }
}
