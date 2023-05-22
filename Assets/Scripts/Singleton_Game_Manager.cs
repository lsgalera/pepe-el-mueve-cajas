using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Game_Manager : MonoBehaviour
{
    //MODIFICAR POR UN SISTEMA DE EVENTOS
    public static Singleton_Game_Manager Instance { get; private set; }
    int successfulGoals = 0, currentGoals = 2;
    bool win = false;

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

    private void Start()
    {
        Singleton_UI_Manager.Instance.UpdateGoalCounterUI(0, 2);
    }

    private void Update()
    {
        Singleton_UI_Manager.Instance.UpdateGoalCounterUI(successfulGoals, 2);
        CheckWin();
    }

    public void UpdateGoal(int number)
    {
        successfulGoals += number;
    }

    void CheckWin()
    {
        if ((successfulGoals >= currentGoals) && !win)
        {
            Debug.Log("Ganaste!!");
            win = !win;
        }
    }


}
