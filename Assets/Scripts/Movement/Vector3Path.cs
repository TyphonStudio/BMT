using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Path {

    public static Vector3Path CreateFromHexPath(List<HexCell> hexPath)
    {
        Vector3Path vectorPath = new Vector3Path();

        //foreach (HexCell cell in hexPath)
        //{
        //    vectorPath.points.Add(cell.Position);
        //}

        vectorPath.points.Add(hexPath[0].Position);

        for(int i = 0; i < hexPath.Count - 1; i++)
        {
            Vector3 betweenEdges = (hexPath[i].Position + hexPath[i + 1].Position) * 0.5f;
            vectorPath.points.Add(betweenEdges);
        }
        vectorPath.points.Add(hexPath[hexPath.Count - 1].Position);

        return vectorPath;
    }

    public List<Vector3> points = new List<Vector3>();
}