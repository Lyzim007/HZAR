
using System.Collections;
using UnityEngine;
using XCharts.Runtime;

public class ChartRefresh : MonoBehaviour
{
    private LineChart _chart;

    private void Awake()
    {
        _chart = this.GetComponent<LineChart>();
        var xAxis = _chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = 2000;
        xAxis.boundaryGap = true;
        xAxis.type = Axis.AxisType.Category;
    }

    private void Start()
    {
        StartCoroutine(RefreshChartData());
    }

    IEnumerator RefreshChartData()
    {
        _chart.RemoveData();

        _chart.AddSerie<Line>("line");

        for (int i = 0; i < 2000; i++)
        {
            _chart.AddXAxisData(i.ToString());
            _chart.AddData(0, Random.Range(10, 20));
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(RefreshChartData());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
