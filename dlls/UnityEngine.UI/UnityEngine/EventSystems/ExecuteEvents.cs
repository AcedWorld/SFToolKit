using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000068 RID: 104
	public static class ExecuteEvents
	{
		// Token: 0x060005D2 RID: 1490 RVA: 0x00019213 File Offset: 0x00017413
		public static T ValidateEventData<T>(BaseEventData data) where T : class
		{
			if (!(data is T))
			{
				throw new ArgumentException(string.Format("Invalid type: {0} passed to event expecting {1}", data.GetType(), typeof(T)));
			}
			return data as T;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00019252 File Offset: 0x00017452
		private static void Execute(IPointerMoveHandler handler, BaseEventData eventData)
		{
			handler.OnPointerMove(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00019260 File Offset: 0x00017460
		private static void Execute(IPointerEnterHandler handler, BaseEventData eventData)
		{
			handler.OnPointerEnter(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001926E File Offset: 0x0001746E
		private static void Execute(IPointerExitHandler handler, BaseEventData eventData)
		{
			handler.OnPointerExit(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001927C File Offset: 0x0001747C
		private static void Execute(IPointerDownHandler handler, BaseEventData eventData)
		{
			handler.OnPointerDown(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001928A File Offset: 0x0001748A
		private static void Execute(IPointerUpHandler handler, BaseEventData eventData)
		{
			handler.OnPointerUp(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00019298 File Offset: 0x00017498
		private static void Execute(IPointerClickHandler handler, BaseEventData eventData)
		{
			handler.OnPointerClick(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x000192A6 File Offset: 0x000174A6
		private static void Execute(IInitializePotentialDragHandler handler, BaseEventData eventData)
		{
			handler.OnInitializePotentialDrag(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x000192B4 File Offset: 0x000174B4
		private static void Execute(IBeginDragHandler handler, BaseEventData eventData)
		{
			handler.OnBeginDrag(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x000192C2 File Offset: 0x000174C2
		private static void Execute(IDragHandler handler, BaseEventData eventData)
		{
			handler.OnDrag(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000192D0 File Offset: 0x000174D0
		private static void Execute(IEndDragHandler handler, BaseEventData eventData)
		{
			handler.OnEndDrag(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000192DE File Offset: 0x000174DE
		private static void Execute(IDropHandler handler, BaseEventData eventData)
		{
			handler.OnDrop(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000192EC File Offset: 0x000174EC
		private static void Execute(IScrollHandler handler, BaseEventData eventData)
		{
			handler.OnScroll(ExecuteEvents.ValidateEventData<PointerEventData>(eventData));
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x000192FA File Offset: 0x000174FA
		private static void Execute(IUpdateSelectedHandler handler, BaseEventData eventData)
		{
			handler.OnUpdateSelected(eventData);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00019303 File Offset: 0x00017503
		private static void Execute(ISelectHandler handler, BaseEventData eventData)
		{
			handler.OnSelect(eventData);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001930C File Offset: 0x0001750C
		private static void Execute(IDeselectHandler handler, BaseEventData eventData)
		{
			handler.OnDeselect(eventData);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00019315 File Offset: 0x00017515
		private static void Execute(IMoveHandler handler, BaseEventData eventData)
		{
			handler.OnMove(ExecuteEvents.ValidateEventData<AxisEventData>(eventData));
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00019323 File Offset: 0x00017523
		private static void Execute(ISubmitHandler handler, BaseEventData eventData)
		{
			handler.OnSubmit(eventData);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001932C File Offset: 0x0001752C
		private static void Execute(ICancelHandler handler, BaseEventData eventData)
		{
			handler.OnCancel(eventData);
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x00019335 File Offset: 0x00017535
		public static ExecuteEvents.EventFunction<IPointerMoveHandler> pointerMoveHandler
		{
			get
			{
				return ExecuteEvents.s_PointerMoveHandler;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0001933C File Offset: 0x0001753C
		public static ExecuteEvents.EventFunction<IPointerEnterHandler> pointerEnterHandler
		{
			get
			{
				return ExecuteEvents.s_PointerEnterHandler;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00019343 File Offset: 0x00017543
		public static ExecuteEvents.EventFunction<IPointerExitHandler> pointerExitHandler
		{
			get
			{
				return ExecuteEvents.s_PointerExitHandler;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0001934A File Offset: 0x0001754A
		public static ExecuteEvents.EventFunction<IPointerDownHandler> pointerDownHandler
		{
			get
			{
				return ExecuteEvents.s_PointerDownHandler;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00019351 File Offset: 0x00017551
		public static ExecuteEvents.EventFunction<IPointerUpHandler> pointerUpHandler
		{
			get
			{
				return ExecuteEvents.s_PointerUpHandler;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00019358 File Offset: 0x00017558
		public static ExecuteEvents.EventFunction<IPointerClickHandler> pointerClickHandler
		{
			get
			{
				return ExecuteEvents.s_PointerClickHandler;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0001935F File Offset: 0x0001755F
		public static ExecuteEvents.EventFunction<IInitializePotentialDragHandler> initializePotentialDrag
		{
			get
			{
				return ExecuteEvents.s_InitializePotentialDragHandler;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00019366 File Offset: 0x00017566
		public static ExecuteEvents.EventFunction<IBeginDragHandler> beginDragHandler
		{
			get
			{
				return ExecuteEvents.s_BeginDragHandler;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0001936D File Offset: 0x0001756D
		public static ExecuteEvents.EventFunction<IDragHandler> dragHandler
		{
			get
			{
				return ExecuteEvents.s_DragHandler;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00019374 File Offset: 0x00017574
		public static ExecuteEvents.EventFunction<IEndDragHandler> endDragHandler
		{
			get
			{
				return ExecuteEvents.s_EndDragHandler;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001937B File Offset: 0x0001757B
		public static ExecuteEvents.EventFunction<IDropHandler> dropHandler
		{
			get
			{
				return ExecuteEvents.s_DropHandler;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00019382 File Offset: 0x00017582
		public static ExecuteEvents.EventFunction<IScrollHandler> scrollHandler
		{
			get
			{
				return ExecuteEvents.s_ScrollHandler;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00019389 File Offset: 0x00017589
		public static ExecuteEvents.EventFunction<IUpdateSelectedHandler> updateSelectedHandler
		{
			get
			{
				return ExecuteEvents.s_UpdateSelectedHandler;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00019390 File Offset: 0x00017590
		public static ExecuteEvents.EventFunction<ISelectHandler> selectHandler
		{
			get
			{
				return ExecuteEvents.s_SelectHandler;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x00019397 File Offset: 0x00017597
		public static ExecuteEvents.EventFunction<IDeselectHandler> deselectHandler
		{
			get
			{
				return ExecuteEvents.s_DeselectHandler;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0001939E File Offset: 0x0001759E
		public static ExecuteEvents.EventFunction<IMoveHandler> moveHandler
		{
			get
			{
				return ExecuteEvents.s_MoveHandler;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x000193A5 File Offset: 0x000175A5
		public static ExecuteEvents.EventFunction<ISubmitHandler> submitHandler
		{
			get
			{
				return ExecuteEvents.s_SubmitHandler;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x000193AC File Offset: 0x000175AC
		public static ExecuteEvents.EventFunction<ICancelHandler> cancelHandler
		{
			get
			{
				return ExecuteEvents.s_CancelHandler;
			}
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000193B4 File Offset: 0x000175B4
		private static void GetEventChain(GameObject root, IList<Transform> eventChain)
		{
			eventChain.Clear();
			if (root == null)
			{
				return;
			}
			Transform transform = root.transform;
			while (transform != null)
			{
				eventChain.Add(transform);
				transform = transform.parent;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000193F4 File Offset: 0x000175F4
		public static bool Execute<T>(GameObject target, BaseEventData eventData, ExecuteEvents.EventFunction<T> functor) where T : IEventSystemHandler
		{
			List<IEventSystemHandler> list = CollectionPool<List<IEventSystemHandler>, IEventSystemHandler>.Get();
			ExecuteEvents.GetEventList<T>(target, list);
			int count = list.Count;
			int i = 0;
			while (i < count)
			{
				T handler;
				try
				{
					handler = (T)((object)list[i]);
				}
				catch (Exception innerException)
				{
					IEventSystemHandler eventSystemHandler = list[i];
					Debug.LogException(new Exception(string.Format("Type {0} expected {1} received.", typeof(T).Name, eventSystemHandler.GetType().Name), innerException));
					goto IL_78;
				}
				goto IL_66;
				IL_78:
				i++;
				continue;
				IL_66:
				try
				{
					functor(handler, eventData);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				goto IL_78;
			}
			int count2 = list.Count;
			CollectionPool<List<IEventSystemHandler>, IEventSystemHandler>.Release(list);
			return count2 > 0;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x000194AC File Offset: 0x000176AC
		public static GameObject ExecuteHierarchy<T>(GameObject root, BaseEventData eventData, ExecuteEvents.EventFunction<T> callbackFunction) where T : IEventSystemHandler
		{
			ExecuteEvents.GetEventChain(root, ExecuteEvents.s_InternalTransformList);
			int count = ExecuteEvents.s_InternalTransformList.Count;
			for (int i = 0; i < count; i++)
			{
				Transform transform = ExecuteEvents.s_InternalTransformList[i];
				if (ExecuteEvents.Execute<T>(transform.gameObject, eventData, callbackFunction))
				{
					return transform.gameObject;
				}
			}
			return null;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00019500 File Offset: 0x00017700
		private static bool ShouldSendToComponent<T>(Component component) where T : IEventSystemHandler
		{
			if (!(component is T))
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			return !(behaviour != null) || behaviour.isActiveAndEnabled;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00019534 File Offset: 0x00017734
		private static void GetEventList<T>(GameObject go, IList<IEventSystemHandler> results) where T : IEventSystemHandler
		{
			if (results == null)
			{
				throw new ArgumentException("Results array is null", "results");
			}
			if (go == null || !go.activeInHierarchy)
			{
				return;
			}
			List<Component> list = CollectionPool<List<Component>, Component>.Get();
			go.GetComponents<Component>(list);
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (ExecuteEvents.ShouldSendToComponent<T>(list[i]))
				{
					results.Add(list[i] as IEventSystemHandler);
				}
			}
			CollectionPool<List<Component>, Component>.Release(list);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x000195AC File Offset: 0x000177AC
		public static bool CanHandleEvent<T>(GameObject go) where T : IEventSystemHandler
		{
			List<IEventSystemHandler> list = CollectionPool<List<IEventSystemHandler>, IEventSystemHandler>.Get();
			ExecuteEvents.GetEventList<T>(go, list);
			int count = list.Count;
			CollectionPool<List<IEventSystemHandler>, IEventSystemHandler>.Release(list);
			return count != 0;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x000195D8 File Offset: 0x000177D8
		public static GameObject GetEventHandler<T>(GameObject root) where T : IEventSystemHandler
		{
			if (root == null)
			{
				return null;
			}
			Transform transform = root.transform;
			while (transform != null)
			{
				if (ExecuteEvents.CanHandleEvent<T>(transform.gameObject))
				{
					return transform.gameObject;
				}
				transform = transform.parent;
			}
			return null;
		}

		// Token: 0x040001F6 RID: 502
		private static readonly ExecuteEvents.EventFunction<IPointerMoveHandler> s_PointerMoveHandler = new ExecuteEvents.EventFunction<IPointerMoveHandler>(ExecuteEvents.Execute);

		// Token: 0x040001F7 RID: 503
		private static readonly ExecuteEvents.EventFunction<IPointerEnterHandler> s_PointerEnterHandler = new ExecuteEvents.EventFunction<IPointerEnterHandler>(ExecuteEvents.Execute);

		// Token: 0x040001F8 RID: 504
		private static readonly ExecuteEvents.EventFunction<IPointerExitHandler> s_PointerExitHandler = new ExecuteEvents.EventFunction<IPointerExitHandler>(ExecuteEvents.Execute);

		// Token: 0x040001F9 RID: 505
		private static readonly ExecuteEvents.EventFunction<IPointerDownHandler> s_PointerDownHandler = new ExecuteEvents.EventFunction<IPointerDownHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FA RID: 506
		private static readonly ExecuteEvents.EventFunction<IPointerUpHandler> s_PointerUpHandler = new ExecuteEvents.EventFunction<IPointerUpHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FB RID: 507
		private static readonly ExecuteEvents.EventFunction<IPointerClickHandler> s_PointerClickHandler = new ExecuteEvents.EventFunction<IPointerClickHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FC RID: 508
		private static readonly ExecuteEvents.EventFunction<IInitializePotentialDragHandler> s_InitializePotentialDragHandler = new ExecuteEvents.EventFunction<IInitializePotentialDragHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FD RID: 509
		private static readonly ExecuteEvents.EventFunction<IBeginDragHandler> s_BeginDragHandler = new ExecuteEvents.EventFunction<IBeginDragHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FE RID: 510
		private static readonly ExecuteEvents.EventFunction<IDragHandler> s_DragHandler = new ExecuteEvents.EventFunction<IDragHandler>(ExecuteEvents.Execute);

		// Token: 0x040001FF RID: 511
		private static readonly ExecuteEvents.EventFunction<IEndDragHandler> s_EndDragHandler = new ExecuteEvents.EventFunction<IEndDragHandler>(ExecuteEvents.Execute);

		// Token: 0x04000200 RID: 512
		private static readonly ExecuteEvents.EventFunction<IDropHandler> s_DropHandler = new ExecuteEvents.EventFunction<IDropHandler>(ExecuteEvents.Execute);

		// Token: 0x04000201 RID: 513
		private static readonly ExecuteEvents.EventFunction<IScrollHandler> s_ScrollHandler = new ExecuteEvents.EventFunction<IScrollHandler>(ExecuteEvents.Execute);

		// Token: 0x04000202 RID: 514
		private static readonly ExecuteEvents.EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler = new ExecuteEvents.EventFunction<IUpdateSelectedHandler>(ExecuteEvents.Execute);

		// Token: 0x04000203 RID: 515
		private static readonly ExecuteEvents.EventFunction<ISelectHandler> s_SelectHandler = new ExecuteEvents.EventFunction<ISelectHandler>(ExecuteEvents.Execute);

		// Token: 0x04000204 RID: 516
		private static readonly ExecuteEvents.EventFunction<IDeselectHandler> s_DeselectHandler = new ExecuteEvents.EventFunction<IDeselectHandler>(ExecuteEvents.Execute);

		// Token: 0x04000205 RID: 517
		private static readonly ExecuteEvents.EventFunction<IMoveHandler> s_MoveHandler = new ExecuteEvents.EventFunction<IMoveHandler>(ExecuteEvents.Execute);

		// Token: 0x04000206 RID: 518
		private static readonly ExecuteEvents.EventFunction<ISubmitHandler> s_SubmitHandler = new ExecuteEvents.EventFunction<ISubmitHandler>(ExecuteEvents.Execute);

		// Token: 0x04000207 RID: 519
		private static readonly ExecuteEvents.EventFunction<ICancelHandler> s_CancelHandler = new ExecuteEvents.EventFunction<ICancelHandler>(ExecuteEvents.Execute);

		// Token: 0x04000208 RID: 520
		private static readonly List<Transform> s_InternalTransformList = new List<Transform>(30);

		// Token: 0x020000C6 RID: 198
		// (Invoke) Token: 0x0600075A RID: 1882
		public delegate void EventFunction<T1>(T1 handler, BaseEventData eventData);
	}
}
