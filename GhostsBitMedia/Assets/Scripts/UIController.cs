using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace MyGhostsGame
{
	public class UIController : MonoBehaviour
	{
		public static UIController Instance { get; private set; }

		[SerializeField]
		private Text countLabel;

		[SerializeField]
		private Text scoreLabel;

		[SerializeField]
		private MenuScript menu;

		[SerializeField]
		private GameObject[] objectsToHideAfterStart;

		[SerializeField]
		private GameObject[] objectsToShowAfterStart;

		public float Score { get; private set; }

		private GhostsGenerator ghostGenerator;

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			ghostGenerator = GhostsGenerator.Instance;

			SetActivObjects(objectsToHideAfterStart, true);
			SetActivObjects(objectsToShowAfterStart, false);

			menu.Close();
		}

		void LateUpdate()
		{
			scoreLabel.text = String.Format("Score : {0}", Score);
			countLabel.text = String.Format("Ghosts on scene : {0}/{1}", ghostGenerator.getCurrentGhostCount(), ghostGenerator.getMaxGhostCount());
		}

		public void OnOpenMenu()
		{
			menu.Open();
			ghostGenerator.SetPauseAll(true);
		}

		public void OnCloseMenu()
		{
			menu.Close();
			ghostGenerator.SetPauseAll(false);
		}

		public void OnStartGame()
		{
			ghostGenerator.startGenerate();

			SetActivObjects(objectsToHideAfterStart, false);
			SetActivObjects(objectsToShowAfterStart, true);
		}

		public void AddScore(uint score)
		{
			Score += score;
		}

		private void SetActivObjects(IEnumerable objects, bool state)
		{
			foreach (GameObject obj in objects)
			{
				obj.SetActive(state);
			}
		}

	}
}
