using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{
    public float healthGiven = 0.01f;

    public void onPlayerPickup()
    {
        Destroy(gameObject);
    }
    
}
