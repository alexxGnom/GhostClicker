using UnityEngine;
using System.Collections;

namespace MyGhostsGame
{
	public class Ghost : MonoBehaviour
	{
		[SerializeField] private uint weight = 1;

		public float Speed { private get; set; }
		public bool Pause { private get; set; }
		public float MaxY { private get; set; }

		//public float LifeTime { private get; set; }

		private Transform thisTransform;

		private GhostsGenerator ghostGenerator;

		private UIController uiController;

		void Start()
		{
			Pause = false;
			thisTransform = this.gameObject.transform;

			ghostGenerator = GhostsGenerator.Instance;
			uiController = UIController.Instance;

			//StartCoroutine(EndOfLifeTime());
		}

		// private IEnumerator EndOfLifeTime()
		// {
		// 	yield return new WaitForSeconds(LifeTime);
		// 	GhostsGenerator.Instance.Dead(this.gameObject);
		// }

		void Update()
		{
			if (Pause)
				return;

			thisTransform.Translate(Vector3.up * Time.deltaTime * Speed);

			if (thisTransform.position.y > MaxY)
				ghostGenerator.Dead(this.gameObject);
		}

		public void OnMouseDown()
		{
			if (Pause)
				return;

			uiController.AddScore(weight);
			ghostGenerator.Dead(this.gameObject);
		}

	}
}