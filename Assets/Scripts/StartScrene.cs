using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScrene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startScrene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        AudioManager.instance.Stop("Start");
        AudioManager.instance.Play("BG");

    }
}
