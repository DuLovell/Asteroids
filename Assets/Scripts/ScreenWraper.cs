using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWraper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Vector3 position = transform.position;
        if (position.y > ScreenUtils.ScreenTop || position.y < ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        if (position.x < ScreenUtils.ScreenLeft || position.x > ScreenUtils.ScreenRight)
        {
            position.x = -position.x;
        }
        transform.position = position;
    }
}
