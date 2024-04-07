using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static Action<int> life;
    public static Action<int> deads;
    public TextMeshProUGUI textDeads;
    public TextMeshProUGUI textLife;
    private int value_deads = 0;
    private int value_life = 0;

    // Start is called before the first frame update
    void Start()
    {
        deads += setDeads;
        life += setLife;
        deads.Invoke(0);
        life.Invoke(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDeads(int value)
    {
        value_deads += value;
        textDeads.text = value_deads.ToString();
    }

    void setLife(int value)
    {
        value_life += value;
        textLife.text = value_life.ToString();
    }
}
