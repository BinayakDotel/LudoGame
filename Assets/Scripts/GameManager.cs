using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;

    public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public DetermineDiceFace determineDiceFace;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public void GetFaceValue()
    {
        //determineDiceFace.getFaceValue();
    }
}
