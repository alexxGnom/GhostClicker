using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyGhostsGame
{
	public class GhostsGenerator : MonoBehaviour
	{
		public static GhostsGenerator Instance { get; private set; }

		[SerializeField]
		private uint unitsCount;

		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private float minSpeed = 0.0f;

		[SerializeField]
		private float maxSpeed = 0.0f;

		[SerializeField]
		private float rangeRandompositionHorisotal = 0.0f;

		[SerializeField]
		private float positionVerticalStart = 0.0f;

		[SerializeField]
		private float maxVerticalPosition = 0.0f;

		[SerializeField]
		private float timeCheck;

		private bool generate = false;

		private List<GameObject> ghosts = new List<GameObject>();


		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			InvokeRepeating("CheckObjects", 0, timeCheck);
		}

		private void CheckObjects()
		{
			if (!generate)
				return;

			if (ghosts.Count < unitsCount)
			{
				GameObject obj = Instantiate(prefab) as GameObject;

				Vector3 position = Utils.get2DRandomPos(rangeRandompositionHorisotal);
				position.y = positionVerticalStart;
				position.z = 0.0f;
				obj.transform.position = position;
				Ghost ghostComp = obj.GetComponent<Ghost>();
				ghostComp.Speed = Random.Range(minSpeed, maxSpeed);
				ghostComp.MaxY = maxVerticalPosition;
				ghosts.Add(obj);
			}
		}

		public void Dead(GameObject ghost)
		{
			ghosts.Remove(ghost);
			Destroy(ghost);
		}

		public int getCurrentGhostCount()
		{
			return ghosts.Count;
		}

		public int getMaxGhostCount()
		{
			return (int) unitsCount;
		}

		public void startGenerate()
		{
			generate = true;

		}

		public void SetPauseAll(bool state)
		{
			generate = !state;
			foreach (GameObject ghost in ghosts)
			{
				ghost.GetComponent<Ghost>().Pause = state;
			} 
		}
	}
}
