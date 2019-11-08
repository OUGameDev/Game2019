using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI coinsText;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + GameController.GetCoins();
    }
}
