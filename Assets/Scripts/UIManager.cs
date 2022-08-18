using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public string turn_text;
    public Text turn;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        GameEvents.instance.updateUserInterface += setTurn;
    }

    public void setTurn()
    {
        turn.text = turn_text;
    }
}
