using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            continueHandler();
        }
    }
    public void continueHandler()
    {
        
            gameObject.SetActive(false);
            Time.timeScale = 1f;
       
    }
}
