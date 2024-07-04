using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    public TMP_InputField userNameField;

    public void ClickStart()
    {
        SceneManager.LoadScene(1);
        ScoreManager.Instance.playingUser = userNameField.text;
    }

    public void ClickQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
