using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniGame : MonoBehaviour
{
    public int HP = 5;

    public void hit()
    {
        HP--;
        if (HP == 0)
        {
            Debug.Log("Ты обосрался");
        }
    }
}
