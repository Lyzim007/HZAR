
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public abstract class BasePanel : MonoBehaviour
{
    protected RectTransform _transform;

    [HideInInspector] public CanvasGroup _canvasGroup;

    public Dictionary<int, Action> _actionDict;

    public abstract void OnPanelOpen();
    public abstract void OnPanelClose();
    public abstract void ImmediateOpen();
    public abstract void ImmediateClose();

    protected virtual void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
}
