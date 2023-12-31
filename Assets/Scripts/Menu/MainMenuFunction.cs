using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AdsInitializer))]
public class MainMenuFunction : MonoBehaviour, IDataPersistance
{
    [Header("Advertisements")]
    private AdsInitializer adsInit;
    private InterstitialAds interstitialAd;
    private RewardedAds rewardAd;
    public int interAdCounter = 0;

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
    public GameObject levels;
    public GameObject skins;
    public GameObject mountainsUnlocked;
    public GameObject forestUnlocked;
    public Button buyMountains;
    public Button buyForest;
    public Button forest;
    public Button mountains;
    public Button desert;
    public static int levelSelect = 1;
    public bool[] levelsUnlocked = new bool[3] { true, false, false };
    public static int coinWallet;

    public void LoadData(GameData data)
    {
        coinWallet = data.coinWallet;
        levelsUnlocked = data.levelsUnlocked;
    }

    public void SaveData(ref GameData data)
    {
        data.coinWallet = coinWallet;
        data.levelsUnlocked = levelsUnlocked;
    }

    private void Start()
    {
        adsInit = GetComponent<AdsInitializer>();
    }

    void Update()
    {
        if (swapHint == false)
        {
            swapHint = true;
            StartCoroutine(SwapHintMessage());
        }

        coinWalletDisplay.GetComponent<Text>().text = "" + coinWallet;

        if (storeMenu.activeInHierarchy == true)
        {
            if (levels.activeInHierarchy == true)
            {
                if (levelsUnlocked[1] == false)
                {
                    buyMountains.interactable = (coinWallet >= 1000);

                    if (buyMountains.interactable == false)
                    {
                        buyMountains.GetComponentInChildren<Text>().color = Color.red;
                    }
                    else
                    {
                        buyMountains.GetComponentInChildren<Text>().color = Color.green;
                    }
                }

                if (levelsUnlocked[2] == false)
                {
                    buyForest.interactable = (coinWallet >= 2500);

                    if (buyForest.interactable == false)
                    {
                        buyForest.GetComponentInChildren<Text>().color = Color.red;
                    }
                    else
                    {
                        buyForest.GetComponentInChildren<Text>().color = Color.green;
                    }
                }
            }
        }
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(levelSelect);

        if (interAdCounter < 3)
        {
            interAdCounter += 1;
        }
        else if (interAdCounter >= 3)
        {
            interstitialAd.ShowAd();
        }
    }

    public void DisplayStoreMenu()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void DisplayMainMenu()
    {
        if (storeMenu.activeInHierarchy == true)
        {
            storeMenu.SetActive(false);
        }
        else if (achievementMenu.activeInHierarchy == true)
        {
            achievementMenu.SetActive(false);
        }
        else if (creditsMenu.activeInHierarchy == true)
        {
            creditsMenu.SetActive(false);
        }

        mainMenu.SetActive(true);
    }

    public void BuyLevel()
    {
        string level;
        level = EventSystem.current.currentSelectedGameObject.name;

        if (level == "Buy(Mountains)")
        {
            coinWallet -= 1000;
            levelsUnlocked[1] = true;
            buyMountains.gameObject.SetActive(false);
            mountainsUnlocked.SetActive(true);
        }
        else if (level == "Buy(Forest)")
        {
            coinWallet -= 2500;
            levelsUnlocked[2] = true;
            buyForest.gameObject.SetActive(false);
            forestUnlocked.SetActive(true);
        }
    }

    public void LevelSelect()
    {
        string level;
        level = EventSystem.current.currentSelectedGameObject.name;
        
        if (level == "DesertLevel")
        {
            levelSelect = 1;
        }
        else if (level == "MountainLevel")
        {
            if (levelsUnlocked[1] == true)
            {
                levelSelect = 2;
            }
            else
            {
                levelSelect = 1;
            }
        }
        else if (level == "ForestLevel")
        {
            if (levelsUnlocked[2] == true)
            {
                levelSelect = 3;
            }
            else
            {
                levelSelect = 1;
            }
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
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
