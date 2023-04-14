
using System;
using System.Collections;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public static event Action OnPlay;

    [SerializeField] private GameObject GaoluchilunxiangAnim;
    IEnumerator PlayGaoluchilunxiangAnim()
    {
        yield return new WaitForSeconds(5);
        GaoluchilunxiangAnim.SetActive(true);
    }

    public override void DidAwake()
    {
        base.DidAwake();
        StartCoroutine(PlayGaoluchilunxiangAnim());
    }

    public static void Play()
    {
        OnPlay?.Invoke();
    }

    public void QuitThisApplication()
    {
        Application.Quit();
    }
}
