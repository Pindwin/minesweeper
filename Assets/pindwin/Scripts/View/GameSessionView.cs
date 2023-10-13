using pindwin.development;
using pindwin.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace pindwin.Scripts.View
{
	public class GameSessionView : MonoBehaviour
	{
		[SerializeField] private Button _restartGameButton;

		private SwitchSceneCommand _restartGameCommand;

		[Inject]
		private void Inject(SwitchSceneCommand restartGameCommand)
		{
			_restartGameCommand = restartGameCommand.AssertNotNull();
		}
		
		private void Awake()
		{
			_restartGameButton.onClick.AddListener(OnRestartGameClicked);
		}

		private void OnRestartGameClicked()
		{
			_restartGameCommand.Execute("GameScene");
		}
	}
}