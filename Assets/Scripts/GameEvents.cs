using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public event Action updateUserInterface;
    public event Action onDiceRolled;

    public void DiceRolled()
    {
        if (onDiceRolled != null)
        {
            onDiceRolled();
        }
    }
    public void UpdateUI()
    {
        if (updateUserInterface != null)
        {
            updateUserInterface();
        }
    }
}
