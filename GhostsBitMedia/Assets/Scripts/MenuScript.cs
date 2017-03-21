using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MyGhostsGame
{
	public class MenuScript : MonoBehaviour
	{

		public void Open()
		{
			this.gameObject.SetActive(true);
		}

		public void Close()
		{
			this.gameObject.SetActive(false);
		}

		public void ExitApplication()
		{
			Application.Quit(); 
		}

		public void RestartApplication()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}