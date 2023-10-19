using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject[] hintText;
    public bool swapHint = false;
    public int hintNum;

    void Update()
    {
        if (swapHint == false)
        {
            swapHint = true;
            StartCoroutine(SwapHintMessage());
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator SwapHintMessage()
    {
        hintNum = Random.Range(0, 6);
        hintText[hintNum].gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        hintText[hintNum].gameObject.SetActive(false);
        swapHint = false;
    }
}
