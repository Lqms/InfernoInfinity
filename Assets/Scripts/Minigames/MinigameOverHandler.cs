using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameOverHandler : MonoBehaviour
{
    public static event UnityAction MinigameOvered;

    public static void GameOver(PlayerStats playerStats, float playerHealth)
    {
        MinigameOvered?.Invoke();
        playerStats.SetNewCurrentHealth(playerHealth);

        if (playerHealth > 0)
        {
            print("player won!");
        }
        else
        {
            print("player lost!");
        }
    }
}
