using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CarSelection : MonoBehaviour
{
    public Button Next;
    public Button Previous;
    public Button Next1;
    public Button Previous1;
    int Currentcar;
    private GameObject[] Carlist;
    [Header("btn and canvas")]
    public GameObject selectioncanvas;
    public GameObject animationcanvas;
    public GameObject skipbtn;
    public GameObject playbtn;
    public GameObject camera1;
    public GameObject camera2;

    private void Awake()
    {
        ChooseCar(0);
        animationcanvas.SetActive(true);
        selectioncanvas.SetActive(false);
        playbtn.SetActive(false);   
        camera2.SetActive(false);
        skipbtn.SetActive(true);
    }
    private void Start()
    {
        Currentcar = PlayerPrefs.GetInt("CarSelected");
        Carlist=new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        
            Carlist[i]=transform.GetChild(i).gameObject;
        foreach(GameObject t in Carlist)
        {
            t.SetActive(false);

        }
        if (Carlist[Currentcar])
        {
            Carlist[Currentcar].SetActive(true);
        }
        
    }
    public void ChooseCar(int index)
    {
        Previous.interactable = (Currentcar != 0);
        Next.interactable = (Currentcar != transform.childCount - 1);
        Previous1.interactable = (Currentcar != 0);
        Next1.interactable = (Currentcar != transform.childCount - 1);
        for (int i = 0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(i==index);

        }
    }
       public void SwitchCar(int switchcars)
    {
        Currentcar+= switchcars;
        ChooseCar(Currentcar);

    }
    public void PlayGame()
    {

        PlayerPrefs.SetInt("CarSelected", Currentcar);
        SceneManager.LoadScene("Game");
        
    }
    public void Skipbtn()
    {
        selectioncanvas.SetActive(true);
        animationcanvas.SetActive(false);
        playbtn.SetActive(true);
        skipbtn.SetActive(false);
        camera2.SetActive(true);
    }
}
