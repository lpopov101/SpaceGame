using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Global {
	public static int Score = 0;
	public static int Health = 100;

	public static void endGame() {
		SceneManager.LoadScene (0);
	}
}
