using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameController.GetPlayer())
        {
            GameController.CollectCoin();
            Destroy(this.gameObject);
        }
    }
}
