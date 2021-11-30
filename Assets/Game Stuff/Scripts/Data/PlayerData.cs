using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int health = 5;
    int charges = 0;
    int shields = 0;

    public int PlayerHealth { get { return health; } set { } }
    public int PlayerCharges { get { return charges; } set { } }
    public int PlayerShields{ get { return shields; } set { } }
}
