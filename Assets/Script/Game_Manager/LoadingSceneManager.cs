using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Analytics;

public class LoadingSceneManager : MonoBehaviour {
    public static string nextScene;
    [SerializeField] Image progressBar;
    public TextMeshProUGUI progressText;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName) {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene() {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone) {
            yield return null;
            timer += (Time.deltaTime/5);
            if (op.progress < 0.9f) {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress) {
                    timer = 0.0f;
                }
            } else {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount >= 1.0f) {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {
        progressText.text = string.Format("{0:N1}",progressBar.fillAmount*100)+"%";//N의 오른쪽 자릿수까지 잘라 출력하기
    }
}
