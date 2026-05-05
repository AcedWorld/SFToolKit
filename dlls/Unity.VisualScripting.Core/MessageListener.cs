using System;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000084 RID: 132
	[DisableAnnotation]
	[AddComponentMenu("")]
	[IncludeInSettings(false)]
	public abstract class MessageListener : MonoBehaviour
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x000095C0 File Offset: 0x000077C0
		[Obsolete("listenerTypes is deprecated", false)]
		public static Type[] listenerTypes
		{
			get
			{
				if (MessageListener._listenerTypes == null)
				{
					MessageListener._listenerTypes = (from t in RuntimeCodebase.types
					where typeof(MessageListener).IsAssignableFrom(t) && t.IsConcrete() && !Attribute.IsDefined(t, typeof(ObsoleteAttribute))
					select t).ToArray<Type>();
				}
				return MessageListener._listenerTypes;
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000960C File Offset: 0x0000780C
		[Obsolete("Use the overload with a messageListenerType parameter instead", false)]
		public static void AddTo(GameObject gameObject)
		{
			foreach (Type type in MessageListener.listenerTypes)
			{
				if (gameObject.GetComponent(type) == null)
				{
					gameObject.AddComponent(type);
				}
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00009648 File Offset: 0x00007848
		public static void AddTo(Type messageListenerType, GameObject gameObject)
		{
			Component component;
			if (!gameObject.TryGetComponent(messageListenerType, out component))
			{
				gameObject.AddComponent(messageListenerType);
			}
		}

		// Token: 0x040000F8 RID: 248
		private static Type[] _listenerTypes;
	}
}
