using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Timer;
    public GameObject finishUI;
    public GameObject Playercar;
    public TMP_Text status;
    public GameObject Pausemenu;
    public GameObject pausebtn;
    public GameObject steering;
    public GameObject movekeys;
    public GameObject Breakbtn;
    private void Start()
    {
        //    winpanel.SetActive(false);
        //    losepanel.SetActive(false);
        StartCoroutine(Waitforfinish());
        pausebtn.SetActive(true);
        steering.SetActive(true);
        movekeys.SetActive(true);
        Breakbtn.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
       if( other.gameObject.tag=="Player")
        {
            //winpanel.SetActive(true);
            StartCoroutine(FinishUI());
            pausebtn.SetActive(false);
            steering.SetActive(false);
            movekeys.SetActive(false);
            Breakbtn.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Win";
            status.color = Color.red;
        }
       else if( other.gameObject.tag=="Oponentcar")
        {
            //losepanel.SetActive(true);
            StartCoroutine(FinishUI());
            pausebtn.SetActive(false);      
            steering.SetActive(false);  
            movekeys.SetActive(false);
            Breakbtn.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Lose";
            status.color = Color.red;
        }
    }
    IEnumerator Waitforfinish()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator FinishUI()
    
    {
        finishUI.SetActive(true);
        Timer.SetActive(false);
        Playercar.SetActive(false);
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        status.text = "Paused";
        status.color = Color.red;
        Pausemenu.SetActive(true);
        pausebtn.SetActive(false);
        steering.SetActive(false);
        movekeys.SetActive(false);
        Breakbtn.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Pausemenu.SetActive(false );
        pausebtn.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    public void Restrart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
}
