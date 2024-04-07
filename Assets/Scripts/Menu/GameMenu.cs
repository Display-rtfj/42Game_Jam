using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static Action<int> life;
    public static Action<int> setLife;
    public static Action<int> lifeMax;
    public static Action<int> deads;
    public static Action<int> score;
    public TextMeshProUGUI textDeads;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textLife;
    public GameObject menu;

    private int value_deads = 0;
    private int value_life = 0;
    private int value_score = 0;
    private int value_life_max;

    // Start is called before the first frame update
    void Start()
    {
        deads += SetDeads;
        life += SetLife;
        lifeMax += SetLifeMax;
        score += SetScore;
        deads.Invoke(0);
        life.Invoke(0);
        setLife += (value) =>
        {
            value_life = value;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScore(int value)
    {
        value_score += value;
        textScore.text = value_score.ToString();
    }

    void SetDeads(int value)
    {
        value_deads += value;
        textDeads.text = value_deads.ToString();
    }

    void SetLife(int value)
    {
        value_life += value;
        textLife.text = value_life.ToString() + " / " + value_life_max.ToString();
    }

    void SetLifeMax(int value)
    {
        value_life_max += value;
        textLife.text = value_life.ToString() + " / " + value_life_max.ToString();
    }

}
