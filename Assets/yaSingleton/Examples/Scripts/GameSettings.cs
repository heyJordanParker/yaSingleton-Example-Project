using UnityEngine;

namespace yaSingleton.Examples {
	[CreateAssetMenuAttribute(fileName = "Game Settings", menuName = "Singletons/Game Settings")]
	public class GameSettings : LazySingleton<GameSettings> {

		[SerializeField]
		private int _gameVersion = 0;

		[SerializeField]
		private string _welcomeLabel = "";

		public static int GameVersion {
			get { return Instance._gameVersion; }
		}

		public static string WelcomeLabel {
			get { return Instance._welcomeLabel; }
		}
	}
}
