using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "ScriptableObjects/PowerUp")]
public class PowerUp : ScriptableObject
{
    public float duration = 0;

    public float bonusMoveSpeed = 0;

}
