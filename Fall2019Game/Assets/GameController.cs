using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController _instance;

    public GameObject player;

    private int coins = 0;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void CollectCoin()
    {
        _instance.coins = _instance.coins + 1;
        Debug.Log("Collected coin!");
        Debug.Log("Coins collected: " + _instance.coins);
    }

    public static GameObject GetPlayer()
    {
        return _instance.player;
    }

    public static int GetCoins()
    {
        return _instance.coins;
    }
}
