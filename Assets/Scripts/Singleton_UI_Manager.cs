using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Singleton_UI_Manager : MonoBehaviour
{
    [SerializeField] TMP_Text goalCounter;

    public static Singleton_UI_Manager Instance { get; private set; }


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateGoalCounterUI(int successfulGoals=0, int currentGoals=0)
    {
        goalCounter.text = $"Goal(s): {successfulGoals}/{currentGoals}";
    }
}
