using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Singleton_UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text RaycastHitName;

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

    public void SetText(string newText)
    {
        RaycastHitName.text = newText;
    }
}
