using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float timerValue;
    [SerializeField] GameObject playerRef;
    void Update()
    {

        if (playerRef.GetComponent<PlayerMovement>().g_win == true) {
            
            return;
        }
        timerValue += Time.deltaTime;
        timerText.text = timerValue.ToString();
    }
}
    