using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject messageUI;
    private bool _isActivated = false;
    public void Activate()
    {
        _isActivated = true;
        messageUI.SetActive(false);
    }
    public void finishLevel()
    {
        if (_isActivated)
        {
            gameObject.SetActive(false);
        }
        else
        {
            messageUI.SetActive(true);
        }

       
    }
}
