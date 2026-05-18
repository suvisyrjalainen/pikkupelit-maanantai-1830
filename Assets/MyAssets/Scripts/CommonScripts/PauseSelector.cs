using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PauseSelector : MonoBehaviour
{
    public TMP_Text[] items;

    public Color normalColor;
    public Color highlightColor;
    public FadeController fade;
    public GameObject pauseMenu;
    private bool isPaused = false;
    private int index = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        UpdateColors();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)ResumeGame();
            else PauseGame();
        }

        if(!isPaused) return;

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(index < items.Length - 1){
                index += 1;
                Debug.Log(index);
            }
            UpdateColors();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(index > 0){
                index -= 1;
                Debug.Log(index);
            }
            UpdateColors();
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
            ActivateItem(index);
        }
        
    }


    void UpdateColors(){
        for(int i=0; i<items.Length; i++){
            if(i==index){
                items[i].color = highlightColor;
            }
            else{
                items[i].color = normalColor;
            }
        }
    }

    public void ActivateItem(int i){

        if(items[i].text == "Resume"){
            ResumeGame();
        }
        else if(items[i].text == "Main Menu"){
            StartCoroutine(ChangeToMyScene("MainMenu"));
        }
        else if(items[i].text == "Quit"){
            Debug.Log("Lopetetaan peli");
            StartCoroutine(QuitGame());
        }

    }

    public void SetIndex(int i){
        index = i;
        UpdateColors();
    }

    private IEnumerator ChangeToMyScene(string sceneName)
    {
        Debug.Log("Test");

        fade.fadeIn();
        yield return new WaitForSecondsRealtime(fade.fadeDuration);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitGame()
    {
        fade.fadeIn();
        yield return new WaitForSecondsRealtime(fade.fadeDuration);
        Time.timeScale = 1;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void PauseGame()
    {
        isPaused = true;
        index = 0;
        pauseMenu.SetActive(true);
        UpdateColors();
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
