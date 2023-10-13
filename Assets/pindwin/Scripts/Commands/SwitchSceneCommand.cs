using pindwin.umvr.Command;
using UnityEngine.SceneManagement;

namespace pindwin.Scripts.Commands
{
	public class SwitchSceneCommand : ICommand<string>
	{
		public void Execute(string param)
		{
			SceneManager.LoadScene(param);
		}
	}
}