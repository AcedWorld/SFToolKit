using System;
using Invector.vCharacterController;
using Invector.vCharacterController.vActions;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x0200037B RID: 891
	public static class vCharacterExtensions
	{
		// Token: 0x0600120F RID: 4623 RVA: 0x00060134 File Offset: 0x0005E334
		public static void LoadActionControllers(this vCharacter character, bool debug = false)
		{
			IActionController[] components = character.GetComponents<IActionController>();
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i].enabled)
				{
					if (components[i] is IActionListener)
					{
						IActionListener actionListener = components[i] as IActionListener;
						if (actionListener.actionEnter)
						{
							character.onActionEnter.RemoveListener(new UnityAction<Collider>(actionListener.OnActionEnter));
							character.onActionEnter.AddListener(new UnityAction<Collider>(actionListener.OnActionEnter));
							if (debug)
							{
								Debug.Log("Register Action Enter event to the " + actionListener.GetType().Name);
							}
						}
						if (actionListener.actionStay)
						{
							character.onActionStay.RemoveListener(new UnityAction<Collider>(actionListener.OnActionStay));
							character.onActionStay.AddListener(new UnityAction<Collider>(actionListener.OnActionStay));
							if (debug)
							{
								Debug.Log("Register Action Stay event to the " + actionListener.GetType().Name);
							}
						}
						if (actionListener.actionExit)
						{
							character.onActionExit.RemoveListener(new UnityAction<Collider>(actionListener.OnActionExit));
							character.onActionExit.AddListener(new UnityAction<Collider>(actionListener.OnActionExit));
							if (debug)
							{
								Debug.Log("Register action Exit event to the " + actionListener.GetType().Name);
							}
						}
					}
					else
					{
						if (components[i] is IActionEnterListener)
						{
							character.onActionEnter.RemoveListener(new UnityAction<Collider>((components[i] as IActionEnterListener).OnActionEnter));
							character.onActionEnter.AddListener(new UnityAction<Collider>((components[i] as IActionEnterListener).OnActionEnter));
							if (debug)
							{
								Debug.Log("Register Action Enter event to the " + components[i].GetType().Name);
							}
						}
						if (components[i] is IActionStayListener)
						{
							character.onActionStay.RemoveListener(new UnityAction<Collider>((components[i] as IActionStayListener).OnActionStay));
							character.onActionStay.AddListener(new UnityAction<Collider>((components[i] as IActionStayListener).OnActionStay));
							if (debug)
							{
								Debug.Log("Register Action Stay event to the " + components[i].GetType().Name);
							}
						}
						if (components[i] is IActionExitListener)
						{
							character.onActionExit.RemoveListener(new UnityAction<Collider>((components[i] as IActionExitListener).OnActionExit));
							character.onActionExit.AddListener(new UnityAction<Collider>((components[i] as IActionExitListener).OnActionExit));
							if (debug)
							{
								Debug.Log("Register Action Exit event to the " + components[i].GetType().Name);
							}
						}
					}
				}
			}
		}
	}
}
