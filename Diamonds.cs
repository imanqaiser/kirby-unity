using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    PlayerInventory myPlayerInventory;
private void OnTriggerEnter(Collider other) {
   myPlayerInventory=other.GetComponent<PlayerInventory>();  
   if (myPlayerInventory!=null )
    {
       
myPlayerInventory.DiamondCollected();
gameObject.SetActive(false);// hide collected diamond
    }
}
}
