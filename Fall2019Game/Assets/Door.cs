using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private const int RequiredCoins = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameController.GetPlayer() && GameController.GetCoins() >= RequiredCoins)
        {
            // Destroy(this.gameObject);
            SceneManager.LoadScene("Scene2");
        }
    }
}
