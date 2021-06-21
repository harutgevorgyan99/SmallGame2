using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeLevel()
    {
        StartCoroutine(WaiteToEndOfParicleEffect());
    }
    IEnumerator WaiteToEndOfParicleEffect()
    {
        yield return new WaitUntil(() => !UIController.Instance.particleSystem.GetComponent<ParticleSystem>().isPlaying);
        yield return new WaitForEndOfFrame();
        if (UIController.Instance.activItmesCount + 3 < 10)
        {
            UIController.Instance.MakeRandomElemtsAndQuestions(UIController.Instance.activItmesCount + 3);
        }
        else
        {
            MakeLastScenElemetns(true);
        }
        UIController.Instance.particleSystem.SetActive(false);
    }

    public void MakeLastScenElemetns(bool isGameEnd)
    {
        UIController.Instance.lastSceneElementsParent.SetActive(isGameEnd);
        UIController.Instance.lastSceneBackground.SetActive(isGameEnd);
        if (isGameEnd)
            UIController.Instance.lastSceneBackground.GetComponent<Animator>().SetBool("FadeIn", true);

    }
    public void RestartGame()
    {
        UIController.Instance.lastSceneBackground.GetComponent<Animator>().SetBool("FadeOut", true);
        UIController.Instance.answers.Clear();
        for (int i = 0; i < UIController.Instance.elemtsParent.childCount; i++)
        {
            Destroy(UIController.Instance.elemtsParent.GetChild(i).gameObject);
        }
        UIController.Instance.question.text = "";

        StartCoroutine(StartNewGame());
    }

    IEnumerator StartNewGame()
    {
        yield return new WaitUntil(() => UIController.Instance.elemtsParent.childCount == 0);
        UIController.Instance.MakeRandomElemtsAndQuestions(3);
        UIController.Instance.lastSceneBackground.GetComponent<Animator>().SetBool("FadeOut", false);
    }
}
