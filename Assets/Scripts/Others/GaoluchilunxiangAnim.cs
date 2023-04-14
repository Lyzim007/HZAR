
using UnityEngine;

public class GaoluchilunxiangAnim : MonoBehaviour
{
    [SerializeField] private GameObject _lineChart;
    public void ExitThisObj()
    {
        _lineChart.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
