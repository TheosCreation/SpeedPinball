using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float timerValue;
    void Update()
    {
        timerValue += Time.deltaTime;
        timerText.text = timerValue.ToString();
    }
}
