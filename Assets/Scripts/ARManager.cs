
using System;
using UnityEngine;
using DG.Tweening;

public class ARManager : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    public static event Action OnTargetFound;

    private void Awake()
    {
        _target.SetActive(false);
        _target.transform.localScale = Vector3.zero;
    }

    public void EnableTarget()
    {
        _target.SetActive(true);
        _target.transform.DOScale(1, 1.5f);
        OnTargetFound?.Invoke();
        Manager.Play();
    }

    public void DisableTarget() => _target.SetActive(false);
}
