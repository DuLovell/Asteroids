using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidMiniPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Задаем астероиду случайный по величине импульс и случайное направление
        float minImpulseForce = 3f;
        float maxImpulseForce = 5f;

        //float angle = Random.Range(0, 2 * Mathf.PI);
        //Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        //float magnitude = Random.Range(minImpulseForce, maxImpulseForce);

        //-----------------------------
        Vector2 centerScreenPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 centerWorldPoint = Camera.main.ScreenToWorldPoint(centerScreenPoint);

        float angleFromSelfPositionToCenter = Mathf.Atan2(centerWorldPoint.y - transform.position.y, centerWorldPoint.x - transform.position.x);
        float angleRandom = Random.Range(angleFromSelfPositionToCenter - Mathf.PI / 4, angleFromSelfPositionToCenter + Mathf.PI / 4);
        Vector2 direction = new Vector2(Mathf.Cos(angleRandom), Mathf.Sin(angleRandom));
        direction.Normalize();
        float magnitude = Random.Range(minImpulseForce, maxImpulseForce);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        rb.AddTorque(0.15f, ForceMode2D.Impulse);

        // Ignore other asteroid's colliders on the "Asteroids"  layer
        Physics2D.IgnoreLayerCollision(8, 8, true); // 8 is "Asteroids" layer

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SpaceShip")
           col.gameObject.GetComponent<SpaceShip>().Destroy();

        if (col.gameObject.tag == "Bullet")
        {
            for (int i = 0; i < 2; i++)
                Instantiate(asteroidMiniPrefab, transform.position, Quaternion.identity);
        }
    }
}
