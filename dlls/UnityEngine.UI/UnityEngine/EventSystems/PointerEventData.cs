using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000050 RID: 80
	public class PointerEventData : BaseEventData
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x00018109 File Offset: 0x00016309
		// (set) Token: 0x0600053C RID: 1340 RVA: 0x00018111 File Offset: 0x00016311
		public GameObject pointerEnter { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0001811A File Offset: 0x0001631A
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x00018122 File Offset: 0x00016322
		public GameObject lastPress { get; private set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0001812B File Offset: 0x0001632B
		// (set) Token: 0x06000540 RID: 1344 RVA: 0x00018133 File Offset: 0x00016333
		public GameObject rawPointerPress { get; set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x0001813C File Offset: 0x0001633C
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x00018144 File Offset: 0x00016344
		public GameObject pointerDrag { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0001814D File Offset: 0x0001634D
		// (set) Token: 0x06000544 RID: 1348 RVA: 0x00018155 File Offset: 0x00016355
		public GameObject pointerClick { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x0001815E File Offset: 0x0001635E
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x00018166 File Offset: 0x00016366
		public RaycastResult pointerCurrentRaycast { get; set; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x0001816F File Offset: 0x0001636F
		// (set) Token: 0x06000548 RID: 1352 RVA: 0x00018177 File Offset: 0x00016377
		public RaycastResult pointerPressRaycast { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x00018180 File Offset: 0x00016380
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x00018188 File Offset: 0x00016388
		public bool eligibleForClick { get; set; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x00018191 File Offset: 0x00016391
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x00018199 File Offset: 0x00016399
		public int displayIndex { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x000181A2 File Offset: 0x000163A2
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x000181AA File Offset: 0x000163AA
		public int pointerId { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x000181B3 File Offset: 0x000163B3
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x000181BB File Offset: 0x000163BB
		public Vector2 position { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x000181C4 File Offset: 0x000163C4
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x000181CC File Offset: 0x000163CC
		public Vector2 delta { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x000181D5 File Offset: 0x000163D5
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x000181DD File Offset: 0x000163DD
		public Vector2 pressPosition { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x000181E6 File Offset: 0x000163E6
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x000181EE File Offset: 0x000163EE
		[Obsolete("Use either pointerCurrentRaycast.worldPosition or pointerPressRaycast.worldPosition")]
		public Vector3 worldPosition { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x000181F7 File Offset: 0x000163F7
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x000181FF File Offset: 0x000163FF
		[Obsolete("Use either pointerCurrentRaycast.worldNormal or pointerPressRaycast.worldNormal")]
		public Vector3 worldNormal { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x00018208 File Offset: 0x00016408
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x00018210 File Offset: 0x00016410
		public float clickTime { get; set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x00018219 File Offset: 0x00016419
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x00018221 File Offset: 0x00016421
		public int clickCount { get; set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001822A File Offset: 0x0001642A
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x00018232 File Offset: 0x00016432
		public Vector2 scrollDelta { get; set; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0001823B File Offset: 0x0001643B
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x00018243 File Offset: 0x00016443
		public bool useDragThreshold { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0001824C File Offset: 0x0001644C
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x00018254 File Offset: 0x00016454
		public bool dragging { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0001825D File Offset: 0x0001645D
		// (set) Token: 0x06000564 RID: 1380 RVA: 0x00018265 File Offset: 0x00016465
		public PointerEventData.InputButton button { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0001826E File Offset: 0x0001646E
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x00018276 File Offset: 0x00016476
		public float pressure { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0001827F File Offset: 0x0001647F
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x00018287 File Offset: 0x00016487
		public float tangentialPressure { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x00018290 File Offset: 0x00016490
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x00018298 File Offset: 0x00016498
		public float altitudeAngle { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x000182A1 File Offset: 0x000164A1
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x000182A9 File Offset: 0x000164A9
		public float azimuthAngle { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x000182B2 File Offset: 0x000164B2
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x000182BA File Offset: 0x000164BA
		public float twist { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x000182C3 File Offset: 0x000164C3
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x000182CB File Offset: 0x000164CB
		public Vector2 tilt { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x000182D4 File Offset: 0x000164D4
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x000182DC File Offset: 0x000164DC
		public PenStatus penStatus { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x000182E5 File Offset: 0x000164E5
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x000182ED File Offset: 0x000164ED
		public Vector2 radius { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x000182F6 File Offset: 0x000164F6
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x000182FE File Offset: 0x000164FE
		public Vector2 radiusVariance { get; set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x00018307 File Offset: 0x00016507
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x0001830F File Offset: 0x0001650F
		public bool fullyExited { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00018318 File Offset: 0x00016518
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00018320 File Offset: 0x00016520
		public bool reentered { get; set; }

		// Token: 0x0600057B RID: 1403 RVA: 0x0001832C File Offset: 0x0001652C
		public PointerEventData(EventSystem eventSystem) : base(eventSystem)
		{
			this.eligibleForClick = false;
			this.displayIndex = 0;
			this.pointerId = -1;
			this.position = Vector2.zero;
			this.delta = Vector2.zero;
			this.pressPosition = Vector2.zero;
			this.clickTime = 0f;
			this.clickCount = 0;
			this.scrollDelta = Vector2.zero;
			this.useDragThreshold = true;
			this.dragging = false;
			this.button = PointerEventData.InputButton.Left;
			this.pressure = 0f;
			this.tangentialPressure = 0f;
			this.altitudeAngle = 0f;
			this.azimuthAngle = 0f;
			this.twist = 0f;
			this.tilt = new Vector2(0f, 0f);
			this.penStatus = PenStatus.None;
			this.radius = Vector2.zero;
			this.radiusVariance = Vector2.zero;
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001841C File Offset: 0x0001661C
		public bool IsPointerMoving()
		{
			return this.delta.sqrMagnitude > 0f;
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00018440 File Offset: 0x00016640
		public bool IsScrolling()
		{
			return this.scrollDelta.sqrMagnitude > 0f;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00018462 File Offset: 0x00016662
		public Camera enterEventCamera
		{
			get
			{
				if (!(this.pointerCurrentRaycast.module == null))
				{
					return this.pointerCurrentRaycast.module.eventCamera;
				}
				return null;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00018489 File Offset: 0x00016689
		public Camera pressEventCamera
		{
			get
			{
				if (!(this.pointerPressRaycast.module == null))
				{
					return this.pointerPressRaycast.module.eventCamera;
				}
				return null;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x000184B0 File Offset: 0x000166B0
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x000184B8 File Offset: 0x000166B8
		public GameObject pointerPress
		{
			get
			{
				return this.m_PointerPress;
			}
			set
			{
				if (this.m_PointerPress == value)
				{
					return;
				}
				this.lastPress = this.m_PointerPress;
				this.m_PointerPress = value;
			}
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x000184DC File Offset: 0x000166DC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<b>Position</b>: " + this.position.ToString());
			stringBuilder.AppendLine("<b>delta</b>: " + this.delta.ToString());
			stringBuilder.AppendLine("<b>eligibleForClick</b>: " + this.eligibleForClick.ToString());
			string str = "<b>pointerEnter</b>: ";
			GameObject pointerEnter = this.pointerEnter;
			stringBuilder.AppendLine(str + ((pointerEnter != null) ? pointerEnter.ToString() : null));
			string str2 = "<b>pointerPress</b>: ";
			GameObject pointerPress = this.pointerPress;
			stringBuilder.AppendLine(str2 + ((pointerPress != null) ? pointerPress.ToString() : null));
			string str3 = "<b>lastPointerPress</b>: ";
			GameObject lastPress = this.lastPress;
			stringBuilder.AppendLine(str3 + ((lastPress != null) ? lastPress.ToString() : null));
			string str4 = "<b>pointerDrag</b>: ";
			GameObject pointerDrag = this.pointerDrag;
			stringBuilder.AppendLine(str4 + ((pointerDrag != null) ? pointerDrag.ToString() : null));
			stringBuilder.AppendLine("<b>Use Drag Threshold</b>: " + this.useDragThreshold.ToString());
			stringBuilder.AppendLine("<b>Current Raycast:</b>");
			stringBuilder.AppendLine(this.pointerCurrentRaycast.ToString());
			stringBuilder.AppendLine("<b>Press Raycast:</b>");
			stringBuilder.AppendLine(this.pointerPressRaycast.ToString());
			stringBuilder.AppendLine("<b>Display Index:</b>");
			stringBuilder.AppendLine(this.displayIndex.ToString());
			stringBuilder.AppendLine("<b>pressure</b>: " + this.pressure.ToString());
			stringBuilder.AppendLine("<b>tangentialPressure</b>: " + this.tangentialPressure.ToString());
			stringBuilder.AppendLine("<b>altitudeAngle</b>: " + this.altitudeAngle.ToString());
			stringBuilder.AppendLine("<b>azimuthAngle</b>: " + this.azimuthAngle.ToString());
			stringBuilder.AppendLine("<b>twist</b>: " + this.twist.ToString());
			stringBuilder.AppendLine("<b>tilt</b>: " + this.tilt.ToString());
			stringBuilder.AppendLine("<b>penStatus</b>: " + this.penStatus.ToString());
			stringBuilder.AppendLine("<b>radius</b>: " + this.radius.ToString());
			stringBuilder.AppendLine("<b>radiusVariance</b>: " + this.radiusVariance.ToString());
			return stringBuilder.ToString();
		}

		// Token: 0x040001B1 RID: 433
		private GameObject m_PointerPress;

		// Token: 0x040001B8 RID: 440
		public List<GameObject> hovered = new List<GameObject>();

		// Token: 0x020000C0 RID: 192
		public enum InputButton
		{
			// Token: 0x04000347 RID: 839
			Left,
			// Token: 0x04000348 RID: 840
			Right,
			// Token: 0x04000349 RID: 841
			Middle
		}

		// Token: 0x020000C1 RID: 193
		public enum FramePressState
		{
			// Token: 0x0400034B RID: 843
			Pressed,
			// Token: 0x0400034C RID: 844
			Released,
			// Token: 0x0400034D RID: 845
			PressedAndReleased,
			// Token: 0x0400034E RID: 846
			NotChanged
		}
	}
}
