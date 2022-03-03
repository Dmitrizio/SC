using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private Item item;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
public enum ItemType
{
    HealPotion = 0, 
    JumpPotion = 1
}
