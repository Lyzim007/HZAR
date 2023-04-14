
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class UIManager : Singleton<UIManager>
{
    public Camera UICamera;

    [SerializeField] private Transform _panelsTran;

    private Dictionary<string, BasePanel> _panelType2Panel;

    private Stack<BasePanel> _panelStack;

    public bool HasPanel => _panelStack.Count > 0;

    private float _cursorDisableUntil;

    public override void DidAwake()
    {
        base.DidAwake();

        _panelType2Panel = new Dictionary<string, BasePanel>();

        _panelStack = new Stack<BasePanel>();

        GetComponent<Canvas>().sortingOrder = 1;
    }

    public void PushPanel(string panelType)
    {
        if (panelType.Equals(UIPanelType.TipPanel)) return;

        BasePanel panel = GetPanel(panelType);
        panel.transform.SetAsFirstSibling();

        if (HasPanel)
        {
            if (panel == _panelStack.Peek())
            {
                PopPanel();
                return;
            }

            _panelStack.Peek().OnPanelClose();
        }

        OpenPanel(panel);
    }

    public void PopPanel()
    {
        if (!HasPanel) return;

        if (_panelStack.Count == 1)
        {
            _panelStack.Pop().OnPanelClose();
        }
        else
        {
            _panelStack.Pop().OnPanelClose();
            _panelStack.Peek().OnPanelOpen();
        }
    }

    public void ClearPanel(Action callBack = null)
    {
        if (!HasPanel) return;

        if (_panelStack.Count == 1)
        {
            _panelStack.Pop().OnPanelClose();
            callBack?.Invoke();
        }
        else
        {
            foreach (var panel in _panelStack) panel.OnPanelClose();

            _panelStack.Clear();
        }
    }

    private void OpenPanel(BasePanel panel)
    {
        _panelStack.Push(panel);
        panel.OnPanelOpen();
    }

    private BasePanel GetPanel(string panelType)
    {
        _panelType2Panel.TryGetValue(panelType, out BasePanel panel);

        if (panel == null)
        {
            panel = Instantiate(UIManagerData._panelType2GameObjects[panelType], _panelsTran, false).GetComponent<BasePanel>();
            panel.gameObject.SetActive(false);
            _panelType2Panel.Add(panelType, panel);
        }

        return panel;
    }
}