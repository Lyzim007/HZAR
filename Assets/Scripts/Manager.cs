
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System;
using System.Collections;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public static event Action OnPlay;

    [SerializeField] private GameObject GaoluchilunxiangAnim;
    [SerializeField] private GameObject Chart;
    [SerializeField] private RadialView _canvasRadiaView;
    [SerializeField] private Billboard _canvasBillboard;
    [SerializeField] private RadialView _targetRadiaView;
    [SerializeField] private Billboard _targetBillboard;

    private bool _isFollow;
    private bool _chartEnable;
    private bool _gaoluAnimEnable;

    public override void DidAwake()
    {
        base.DidAwake();
        _isFollow = true;
        _chartEnable = false;
        _gaoluAnimEnable = false;
    }

    public static void Play()
    {
        OnPlay?.Invoke();
    }

    public void QuitThisApplication()
    {
        Application.Quit();
    }

    public void EnableFollowView()
    {
        Debug.Log($"Follow=>{_isFollow}");
        if (_isFollow)
        {
            _canvasRadiaView.enabled = false;
            _canvasBillboard.enabled = false;
            _targetRadiaView.enabled = false;
            _targetBillboard.enabled = false;
        }
        else
        {
            _canvasRadiaView.enabled = true;
            _canvasBillboard.enabled = true;
            _targetRadiaView.enabled = true;
            _targetBillboard.enabled = true;
        }
        _isFollow = !_isFollow;
    }

    public void PlayGaoluAnim()
    {
        GaoluchilunxiangAnim.SetActive(!_gaoluAnimEnable);
        _gaoluAnimEnable = !_gaoluAnimEnable;
    }

    public void EnableChart()
    {
        Chart.SetActive(!_chartEnable);
        _chartEnable = !_chartEnable;
    }
}
