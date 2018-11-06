using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic{
    public GameObject obj;
    // 这一点应该生成的东西，路？建筑？农田？
    public Vector3 position, normal;
    public Vec2 pos;
    // 基于地形的位置和基于地图的位置
    public float height, angle, angleValue, water, graphical, social, worship;
    // 海拔、坡度、植被、水源丰富度、相对周围的高度
    public bool isWater, isBuilding, isRoad, exist, isSite, ignore;
    // 是否为河湖和建筑
    public List<Vec2> buildingArea;
    // 如果是建筑点，那么把所有适合的地方放入这个链表
    public int type, houseType;//建筑点类型
    
    public Basic()
    {
        pos = new Vec2();
        position = new Vector3();
    }
	// Use this for initialization

    public override string ToString()
    {
        return "Exist: " + exist + " OnMap: " +pos+ " graph: " + graphical + " angle: " + angle + " isWater: " + isWater + " water: " + water;
    }
}
