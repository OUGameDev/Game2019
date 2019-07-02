using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    public PowerUp power;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1), Space.Self);
    }

    public PowerUp GetPowerUp()
    {
        return power;
    }
}
