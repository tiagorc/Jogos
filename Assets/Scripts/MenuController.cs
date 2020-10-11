using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text tipText;
    public Text tipTextShadow;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit()
#endif
    }

    public void showTip(string tip)
    {
        tipText.text = tip;
        tipTextShadow.text = tip;
    }
}
