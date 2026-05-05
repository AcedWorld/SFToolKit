using System;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using Rewired;
using UnityEngine;

// Token: 0x02000137 RID: 311
public class RewiredController : MonoBehaviour
{
	// Token: 0x060004FD RID: 1277 RVA: 0x000226B4 File Offset: 0x000208B4
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		ReInput.ControllerConnectedEvent += this.OnControllerConnected;
		ReInput.ControllerDisconnectedEvent += this.OnControllerDisconnected;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000226EE File Offset: 0x000208EE
	private void OnDestroy()
	{
		ReInput.ControllerConnectedEvent -= this.OnControllerConnected;
		ReInput.ControllerDisconnectedEvent -= this.OnControllerDisconnected;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00022714 File Offset: 0x00020914
	private void Update()
	{
		Joystick joystick = this.AnyUnassignedJoystickPressed();
		if (!this.controllerAssigned && joystick != null)
		{
			if (this.player.controllers.joystickCount > 0)
			{
				this.RemoveCurrentlyAssignedJoystick();
			}
			this.AssignJoystickToPlayer(joystick);
			this.controllerAssigned = true;
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0002275A File Offset: 0x0002095A
	private void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		if (args.controllerType == Rewired.ControllerType.Joystick)
		{
			this.controllerAssigned = false;
		}
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x0002276C File Offset: 0x0002096C
	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		if (args.controllerType == Rewired.ControllerType.Joystick)
		{
			if (this.controllerName != "")
			{
				this.controllerName = null;
			}
			this.controllerAssigned = false;
		}
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00022798 File Offset: 0x00020998
	private Joystick AnyUnassignedJoystickPressed()
	{
		foreach (Joystick joystick in ReInput.controllers.Joysticks)
		{
			if (!ReInput.controllers.IsJoystickAssigned(joystick) && joystick.GetAnyButtonDown())
			{
				return joystick;
			}
		}
		return null;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x00022800 File Offset: 0x00020A00
	private void AssignJoystickToPlayer(Joystick joystick)
	{
		this.player.controllers.AddController(joystick, true);
		this.controllerName = joystick.name;
		this.OpenNotification("Controller Assigned: " + this.controllerName);
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00022838 File Offset: 0x00020A38
	public void RemoveCurrentlyAssignedJoystick()
	{
		List<Joystick> list = new List<Joystick>();
		foreach (Joystick item in this.player.controllers.Joysticks)
		{
			list.Add(item);
		}
		foreach (Joystick controller in list)
		{
			this.player.controllers.RemoveController(controller);
		}
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x000228E0 File Offset: 0x00020AE0
	private void OpenNotification(string message)
	{
		this.notificationManager.description = message;
		this.notificationManager.UpdateUI();
		this.notificationManager.OpenNotification();
	}

	// Token: 0x040007CF RID: 1999
	private int playerId;

	// Token: 0x040007D0 RID: 2000
	private Player player;

	// Token: 0x040007D1 RID: 2001
	public string controllerName;

	// Token: 0x040007D2 RID: 2002
	public NotificationManager notificationManager;

	// Token: 0x040007D3 RID: 2003
	private bool controllerAssigned;
}
