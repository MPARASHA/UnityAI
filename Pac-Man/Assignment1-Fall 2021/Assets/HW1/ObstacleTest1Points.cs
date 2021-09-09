using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTest1Points : ObstacleDefiner
{

	
	public override Vector2[][] GetObstaclePoints()
	{
		Vector2[] obstacles1 = new Vector2[] { new Vector2(1f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0.5f) };
		Vector2[] obstacles2 = new Vector2[] { new Vector2(-1f, -1f), new Vector2(-1f, -0.5f), new Vector2(-1.5f, -0.5f), new Vector2(-1.5f, -1f) };

		Vector2[][] arrayOfObstaclePoints = new Vector2[][] { obstacles1, obstacles2 };

		xBound = 2;
		yBound = 1;

		return arrayOfObstaclePoints;
	}
}
