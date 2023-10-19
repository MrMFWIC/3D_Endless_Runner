using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    public GameObject fadeIn;

    public AudioSource readyFX;
    public AudioSource goFX;

    void Start()
    {
        CollectibleControl.coinCount = 0;
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        PlayerMove.canMove = false;
        yield return new WaitForSeconds(1);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(true);
        goFX.Play();
        PlayerMove.canMove = true;
    }
}
