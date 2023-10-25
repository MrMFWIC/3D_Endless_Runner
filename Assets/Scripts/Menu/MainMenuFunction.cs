using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject achievementMenu;
    public GameObject creditsMenu;

    [Header("Main Menu")]
    public GameObject[] hintText;
    public bool swapHint = false;
    public int hintNum;

    [Header("Store Menu")]
    public GameObject coinWalletDisplay;
    public static int coinWallet;

    void Update()
    {
        if (swapHint == false)
        {
            swapHint = true;
            StartCoroutine(SwapHintMessage());
        }

        coinWalletDisplay.GetComponent<Text>().text = "" + coinWallet;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void DisplayStoreMenu()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
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
