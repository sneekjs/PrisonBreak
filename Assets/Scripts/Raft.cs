using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raft : MonoBehaviour
{
    public static Raft Instance;

    [SerializeField]
    private int _requiredParts = 4;

    [SerializeField]
    private GameObject _fpsController;

    private Animator _anime;

    private int _completedParts;

    private void Start()
    {
        _anime = GetComponent<Animator>();
    }

    public void PartCompleted()
    {
        _completedParts++;
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (_completedParts == _requiredParts)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _fpsController.SetActive(false);
        _anime.Play("Finish");
        SwitchScene();
    }

    public void SwitchScene()
    {
        StartCoroutine(LoadNewScene());
    }

    public IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("GameOverScene");
        while (!async.isDone)
        {
            yield return null;
        }

    }
}
