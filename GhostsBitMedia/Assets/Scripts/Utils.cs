using UnityEngine;

namespace MyGhostsGame
{
	public static class Utils
	{
		public static Vector3 get2DRandomPos(float rangeX = 0.0f, float rangeY = 0.0f)
		{
			return new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY), 0.0f);
		}
	}
}
