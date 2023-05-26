using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneScript : MonoBehaviour
{
    public static int Difficulty=1;
    public static bool Sounds=true;
    private bool close = false;
    public GameObject UI;
    public void ToggleEasy(bool t){
        if(t)
        Difficulty=1;
    }
    public void ToggleMedium(bool t){
        if(t)
        Difficulty=2;
    }
    public void ToggleHard(bool t){
        if(t)
        Difficulty=3;
    }
        public void ToggleMP(bool t){
        if(t)
        Difficulty=0;
    }

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void StartGame(){
        SceneManager.LoadScene("Gameplay");
    }
    public void OnlineGame(){
        Difficulty=-1;
        SceneManager.LoadScene("Lobby");
    }
    public void Sound(){
        if(Sounds){
            UI.GetComponentInChildren<TMPro.TextMeshProUGUI>().text="Sounds : Off";
            Sounds=false;
        }
        else{
            UI.GetComponentInChildren<TMPro.TextMeshProUGUI>().text="Sounds : On";
            Sounds=true;
        }
    }
    public void Exit(){
        Application.Quit();
    }    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(close)
            Exit();
            else
            StartCoroutine(Close());
        }
    }
    IEnumerator Close(){
        close = true;
        yield return new WaitForSeconds(0.2f);
        close = false;
    }
}