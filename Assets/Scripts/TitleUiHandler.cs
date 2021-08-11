using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleUiHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    void Start()
    {
        if (GameManager.Instance.playerName != null) {
            playerNameInput.text = GameManager.Instance.playerName;
        }
    }

    public void OnStartButtonClicked()
    {
        SaveName();

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveName();

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    void SaveName()
    {
        if (playerNameInput.text != null) {
            GameManager.Instance.playerName = playerNameInput.text;
            GameManager.Instance.SaveName();
        }
    }
}
