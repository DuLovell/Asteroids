using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Задаем астероиду случайный по величине импульс и случайное направление
        float minImpulseForce = 3f;
        float maxImpulseForce = 5f;

        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(minImpulseForce, maxImpulseForce);
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
