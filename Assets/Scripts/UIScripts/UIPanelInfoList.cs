
using System.Collections.Generic;

public class UIPanelInfoList
{
    public static List<UIPanelInfo> PanelInfoList;
    static UIPanelInfoList()
    {
        PanelInfoList = new List<UIPanelInfo>()
        {
            new UIPanelInfo("MainPanel","UIPanel/MainPanel"),
        };
    }
}