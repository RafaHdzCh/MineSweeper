using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject victory;

    private int tiempo = 0;

    public void Start()
    {
        InvokeRepeating(nameof(Cronometro), 0f, 1f);
    }

    private void Cronometro()
    {
        if (victory.active == true) return;

        timer.text = tiempo.ToString();
        tiempo++;
    }
}
