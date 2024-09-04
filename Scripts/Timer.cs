using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Scripts playercar1;
    public Scripts playercar2;  
    public Scripts playercar3;

    public OponentCar oponentCar1;
    public OponentCar oponentCar2;
    public OponentCar oponentCar3;
    public OponentCar oponentCar4;
    public OponentCar oponentCar5;
    public OponentCar oponentCar6;
    public float Countdown_timer = 5f;
    public TMP_Text Countdowntext;
    private void Awake()
    {
        //playerscripts = GetComponent<Scripts>();
    }
    private void Start()
    {
        StartCoroutine(Timercount());
    }
    private void Update()
    {
        
        if(Countdown_timer>1)
        {
            playercar1.Acceleration = 0f;
            playercar2.Acceleration = 0f;
            playercar3.Acceleration = 0f;
            oponentCar1.Movingspeed = 0f;
            oponentCar2.Movingspeed = 0f;
            oponentCar3.Movingspeed = 0f;
            oponentCar4.Movingspeed = 0f;
            oponentCar5.Movingspeed = 0f;
            oponentCar6.Movingspeed = 0f;  


        }
        else if(Countdown_timer==0)
        {
            playercar1.Acceleration = 300f;
            playercar2.Acceleration = 300f;
            playercar3.Acceleration = 300f;
            oponentCar1.Movingspeed = 11f;
            oponentCar2.Movingspeed = 12f;
            oponentCar3.Movingspeed = 14f;
            oponentCar4.Movingspeed = 10f;
            oponentCar5.Movingspeed = 13f;
            oponentCar6.Movingspeed = 12f;
        }
    }

    IEnumerator Timercount()
    {
        while(Countdown_timer>0)
        {
            Countdowntext.text = Countdown_timer.ToString();
            yield return new WaitForSeconds(1f);
            Countdown_timer--;
        }
        Countdowntext.text = "GO";
        yield return new WaitForSeconds(1f);
        Countdowntext.gameObject.SetActive(false);
    }
}
