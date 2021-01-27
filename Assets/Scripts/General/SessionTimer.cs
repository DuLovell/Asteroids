using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionTimer : MonoBehaviour
{
    #region Fields
    Text hudText;
    float totalSeconds = 0;
    int hours, minutes, seconds;
    bool running = true;
    #endregion

    #region Properties

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        hudText = GameObject.FindGameObjectWithTag("SessionTimer").GetComponent<Text>();
        ManageTotalSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
            totalSeconds += Time.deltaTime;
        
        ManageTotalSeconds();
    }

    public void Stop()
    {
        running = false;
    }

    void ManageTotalSeconds()
    {
        hours = (int)totalSeconds / 3600;
        minutes = (int)totalSeconds % 3600 / 60;
        seconds = (int)totalSeconds % 60;
        hudText.text = $"Current Session: {hours}h {minutes}m {seconds}s";
    }
    #endregion

}
