using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    PlayerInventory myPlayerInventory;
private void OnTriggerEnter(Collider other) {
   myPlayerInventory=other.GetComponent<PlayerInventory>();  
   if (myPlayerInventory!=null )
    {
       
myPlayerInventory.TreasureCollected();
gameObject.SetActive(false);// hide collected diamond

    }
}
}
