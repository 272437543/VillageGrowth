using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {
    public LineRenderer lineRenderer;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static Vector3 bezier_interpolation_func_2(float t, Vector3[] points, int count)
    {
        if (points.Length < 1)  // 一个点都没有  
            throw new System.Exception();

        if (count == 1)
            return points[0];
        else
        {
            Vector3[] tmp_points = new Vector3[count];
            for (int i = 1; i < count; i++)
            {
                tmp_points[i - 1].x = (float)(points[i - 1].x * t + points[i].x * (1 - t));
                tmp_points[i - 1].z = (float)(points[i - 1].z * t + points[i].z * (1 - t));
            }
            return bezier_interpolation_func_2(t, tmp_points, count - 1);
        }
    }
    /// <summary>  
    /// 绘制n阶贝塞尔曲线路径  
    /// </summary>  
    /// <param name="points">输入点</param>  
    /// <param name="count">点数(n+1)</param>  
    /// <param name="step">步长,步长越小，轨迹点越密集</param>  
    /// <returns></returns>  
    public static Vector3[] draw_bezier_curves(Vector3[] points, int count, float step)
    {
        List<Vector3> bezier_curves_points = new List<Vector3>();
        float t = 0F;
        do
        {
            Vector3 temp_point = bezier_interpolation_func_2(t, points, count);    // 计算插值点  
            t += step;
            bezier_curves_points.Add(temp_point);
        }
        while (t <= 1 && count > 1);    // 一个点的情况直接跳出.  
        return bezier_curves_points.ToArray();  // 曲线轨迹上的所有坐标点  
    }
    /// <summary>  
    /// n阶贝塞尔曲线插值计算函数  
    /// 根据起点，n个控制点，终点 计算贝塞尔曲线插值  
    /// </summary>  
    /// <param name="t">当前插值位置0~1 ，0为起点，1为终点</param>  
    /// <param name="points">起点，n-1个控制点，终点</param>  
    /// <param name="count">n+1个点</param>  
    /// <returns></returns>  
    private Vector3 bezier_interpolation_func(float t, Vector3[] points, int count)
    {
        Vector3 vector3 = new Vector3();
        float[] part = new float[count];
        float sum_x = 0, sum_y = 0;
        for (int i = 0; i < count; i++)
        {
            ulong tmp;
            int n_order = count - 1;    // 阶数  
            tmp = calc_combination_number(n_order, i);
            sum_x += (tmp * points[i].x * Mathf.Pow((1 - t), n_order - i) * Mathf.Pow(t, i));
            sum_y += (tmp * points[i].z * Mathf.Pow((1 - t), n_order - i) * Mathf.Pow(t, i));
        }
        vector3.x = sum_x;
        vector3.z = sum_y;
        return vector3;
    }
    /// <summary>  
    /// 计算组合数公式  
    /// </summary>  
    /// <param name="n"></param>  
    /// <param name="k"></param>  
    /// <returns></returns>  
    private ulong calc_combination_number(int n, int k)
    {
        ulong[] result = new ulong[n + 1];
        for (int i = 1; i <= n; i++)
        {
            result[i] = 1;
            for (int j = i - 1; j >= 1; j--)
                result[j] += result[j - 1];
            result[0] = 1;
        }
        return result[k];
    }
}
