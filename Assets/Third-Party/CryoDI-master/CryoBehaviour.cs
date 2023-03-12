#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace CryoDI
{
	public class CryoBehaviour : MonoBehaviour
	{
		private static CryoContainer _rootContainer;

		public bool BuiltUp { get; private set; }

		protected virtual void Awake()
		{
			BuildUp();
		}

		public void BuildUp()
		{
			if (!BuiltUp)
			{
				BuiltUp = true;
				EnsureContainerExists();
				_rootContainer.BuildUp(this);
			}
		}

		private static void EnsureContainerExists()
		{
			if (_rootContainer == null)
				((IInternalContainerBuidler) UnityStarter.Instance).CreateRootContainer();
		}

		public static void SetRootContainer(CryoContainer container)
		{

			_rootContainer = container;
		}
	}
}
#endif