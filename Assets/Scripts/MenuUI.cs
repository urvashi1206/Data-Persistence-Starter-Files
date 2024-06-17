using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI NameText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Best Score : " + MainManagerUI.Instance.Name + " : 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        MainManagerUI.Instance.Name = NameText.text;
        MainManagerUI.Instance.SaveName();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void LoadSavedName()
    {
        MainManagerUI.Instance.LoadName();
        ScoreText.text = "Best Score : " + MainManagerUI.Instance.Name + " : 0";
    }
}
