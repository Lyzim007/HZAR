
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using XCharts.Runtime;

public class FocusTurnPointer : MonoBehaviour
{
    private LineChart _chart;
    private Interactable _interactable;
    private void Awake()
    {
        _chart = GetComponent<LineChart>();
        _interactable = GetComponent<Interactable>();
    }

    public void TurnToPointer()
    {
        //Debug.Log("Press");
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.button = 0;
        pointData.position = (Vector2)(Camera.main.WorldToScreenPoint(_interactable.FocusingPointers[0].Position));

        Debug.Log($"TurnToPointer{pointData.position}");
        _chart.OnPointerEnter(pointData);
    }

    public void TurnToPointer(MixedRealityPointerEventData focusEventData)
    {
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.button = 0;
        pointData.position = focusEventData.Pointer.Position;
        Debug.Log($"TurnToPointer{pointData.position}");
        _chart.OnPointerEnter(pointData);
    }
    public void TurnToPointer(FocusEventData focusEventData)
    {
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.button = 0;
        pointData.position = focusEventData.Pointer.Position;
        Debug.Log($"TurnToPointer{pointData.position}");
        _chart.OnPointerEnter(pointData);
    }
}
