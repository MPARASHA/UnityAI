using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
    public PelletHandler pelletHandler;

    void Start()
    {

        HW3NavigationHandler.Instance.Init();

        List<GraphNode> corners = new List<GraphNode>();

        Vector3[] cornerVecs = new Vector3[] { new Vector3(ObstacleHandler.Instance.XBound, ObstacleHandler.Instance.YBound), new Vector3(-1*ObstacleHandler.Instance.XBound, ObstacleHandler.Instance.YBound), new Vector3(ObstacleHandler.Instance.XBound, -1*ObstacleHandler.Instance.YBound), new Vector3(-1*ObstacleHandler.Instance.XBound, -1*ObstacleHandler.Instance.YBound) };

        foreach(Vector3 pos in cornerVecs)
        {
            GraphNode g = HW3NavigationHandler.Instance.NodeHandler.ClosestNode(pos);
            corners.Add(g);
        }

        for (float x = ObstacleHandler.Instance.XBound * -1; x <= ObstacleHandler.Instance.XBound + 0.2f; x += 0.1f)
        {
            for (float y = ObstacleHandler.Instance.YBound * -1; y <= ObstacleHandler.Instance.YBound; y += 0.1f)
            {
                GraphNode g = HW3NavigationHandler.Instance.NodeHandler.ClosestNode(new Vector3(x, y));
                if (corners.Contains(g))
                {
                    pelletHandler.AddPellet(g.Location, true);
                }
                else
                {
                    pelletHandler.AddPellet(g.Location);
                }
                

            }
        }
    }
}
