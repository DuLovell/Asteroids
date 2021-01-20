using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Fields
    float magnitude = 7f;
    Vector2 direction;
    Quaternion rotation;
    Timer deathTimer;

    #endregion

    #region Properties
    public Vector2 Direction
    {
        set { direction = value; }
    }

    public Quaternion Rotation
    {
        set { rotation = value; }
    }
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * magnitude, ForceMode2D.Impulse);

        transform.rotation = rotation;

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 0.7f;
        deathTimer.Run();
    }

    void Update()
    {
        if (deathTimer.Finished)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
            Destroy(col.gameObject);

        Destroy(gameObject);
    }
    #endregion


}
