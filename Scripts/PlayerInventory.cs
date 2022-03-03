using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    private int diamondCount;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DeathDiamond"))
        {  
            Destroy(gameObject);
            gameOverCanvas.SetActive(true);
        }
        if (other.gameObject.CompareTag("Diamond"))
        {
            diamondCount++;
            Destroy(other.gameObject);

        }
    }
    

}
