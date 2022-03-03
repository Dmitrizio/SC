using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    public ItemBase itemDataBase;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseHandler();
        }
    }
    public void pauseHandler()
    {
        
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        
        
    }
}
