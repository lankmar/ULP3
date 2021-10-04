using UnityEngine;

namespace Assets.Scripts
{
	public class Main : Singleton<Main>
	{
		protected Main() { }

		public void NameMethod()
		{
			Debug.Log(1);
		}
	}
}