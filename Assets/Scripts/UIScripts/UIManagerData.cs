
using System.Collections.Generic;
using UnityEngine;

public class UIManagerData
{
    public static Dictionary<string, GameObject> _panelType2GameObjects;
    static UIManagerData()
    {
        _panelType2GameObjects = new Dictionary<string, GameObject>();

        foreach (UIPanelInfo panelInfo in UIPanelInfoList.PanelInfoList) _panelType2GameObjects.Add(panelInfo._panelType, Resources.Load<GameObject>(panelInfo._path));
    }
}
