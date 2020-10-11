using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{

    public Text loadingText;
    void Start()
    {
        StartCoroutine(LoadScene(2));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadScene(float duration)
    {
        yield return null;

        string nextScene = PlayerPrefs.GetString("nextScene");
        PlayerPrefs.DeleteKey("nextScene");
        PlayerPrefs.Save();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene);

        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                loadingText.text = "Press the space bar to continue";
                if (Input.GetKeyDown(KeyCode.Space))
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
