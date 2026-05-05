using System;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003C6 RID: 966
	[CustomObfuscation(rename = false)]
	internal enum SteamControllerActionOrigin
	{
		// Token: 0x040015F6 RID: 5622
		None,
		// Token: 0x040015F7 RID: 5623
		A,
		// Token: 0x040015F8 RID: 5624
		B,
		// Token: 0x040015F9 RID: 5625
		X,
		// Token: 0x040015FA RID: 5626
		Y,
		// Token: 0x040015FB RID: 5627
		LeftBumper,
		// Token: 0x040015FC RID: 5628
		RightBumper,
		// Token: 0x040015FD RID: 5629
		LeftGrip,
		// Token: 0x040015FE RID: 5630
		RightGrip,
		// Token: 0x040015FF RID: 5631
		Start,
		// Token: 0x04001600 RID: 5632
		Back,
		// Token: 0x04001601 RID: 5633
		LeftPad_Touch,
		// Token: 0x04001602 RID: 5634
		LeftPad_Swipe,
		// Token: 0x04001603 RID: 5635
		LeftPad_Click,
		// Token: 0x04001604 RID: 5636
		LeftPad_DPadNorth,
		// Token: 0x04001605 RID: 5637
		LeftPad_DPadSouth,
		// Token: 0x04001606 RID: 5638
		LeftPad_DPadWest,
		// Token: 0x04001607 RID: 5639
		LeftPad_DPadEast,
		// Token: 0x04001608 RID: 5640
		RightPad_Touch,
		// Token: 0x04001609 RID: 5641
		RightPad_Swipe,
		// Token: 0x0400160A RID: 5642
		RightPad_Click,
		// Token: 0x0400160B RID: 5643
		RightPad_DPadNorth,
		// Token: 0x0400160C RID: 5644
		RightPad_DPadSouth,
		// Token: 0x0400160D RID: 5645
		RightPad_DPadWest,
		// Token: 0x0400160E RID: 5646
		RightPad_DPadEast,
		// Token: 0x0400160F RID: 5647
		LeftTrigger_Pull,
		// Token: 0x04001610 RID: 5648
		LeftTrigger_Click,
		// Token: 0x04001611 RID: 5649
		RightTrigger_Pull,
		// Token: 0x04001612 RID: 5650
		RightTrigger_Click,
		// Token: 0x04001613 RID: 5651
		LeftStick_Move,
		// Token: 0x04001614 RID: 5652
		LeftStick_Click,
		// Token: 0x04001615 RID: 5653
		LeftStick_DPadNorth,
		// Token: 0x04001616 RID: 5654
		LeftStick_DPadSouth,
		// Token: 0x04001617 RID: 5655
		LeftStick_DPadWest,
		// Token: 0x04001618 RID: 5656
		LeftStick_DPadEast,
		// Token: 0x04001619 RID: 5657
		Gyro_Move,
		// Token: 0x0400161A RID: 5658
		Gyro_Pitch,
		// Token: 0x0400161B RID: 5659
		Gyro_Yaw,
		// Token: 0x0400161C RID: 5660
		Gyro_Roll,
		// Token: 0x0400161D RID: 5661
		PS4_X,
		// Token: 0x0400161E RID: 5662
		PS4_Circle,
		// Token: 0x0400161F RID: 5663
		PS4_Triangle,
		// Token: 0x04001620 RID: 5664
		PS4_Square,
		// Token: 0x04001621 RID: 5665
		PS4_LeftBumper,
		// Token: 0x04001622 RID: 5666
		PS4_RightBumper,
		// Token: 0x04001623 RID: 5667
		PS4_Options,
		// Token: 0x04001624 RID: 5668
		PS4_Share,
		// Token: 0x04001625 RID: 5669
		PS4_LeftPad_Touch,
		// Token: 0x04001626 RID: 5670
		PS4_LeftPad_Swipe,
		// Token: 0x04001627 RID: 5671
		PS4_LeftPad_Click,
		// Token: 0x04001628 RID: 5672
		PS4_LeftPad_DPadNorth,
		// Token: 0x04001629 RID: 5673
		PS4_LeftPad_DPadSouth,
		// Token: 0x0400162A RID: 5674
		PS4_LeftPad_DPadWest,
		// Token: 0x0400162B RID: 5675
		PS4_LeftPad_DPadEast,
		// Token: 0x0400162C RID: 5676
		PS4_RightPad_Touch,
		// Token: 0x0400162D RID: 5677
		PS4_RightPad_Swipe,
		// Token: 0x0400162E RID: 5678
		PS4_RightPad_Click,
		// Token: 0x0400162F RID: 5679
		PS4_RightPad_DPadNorth,
		// Token: 0x04001630 RID: 5680
		PS4_RightPad_DPadSouth,
		// Token: 0x04001631 RID: 5681
		PS4_RightPad_DPadWest,
		// Token: 0x04001632 RID: 5682
		PS4_RightPad_DPadEast,
		// Token: 0x04001633 RID: 5683
		PS4_CenterPad_Touch,
		// Token: 0x04001634 RID: 5684
		PS4_CenterPad_Swipe,
		// Token: 0x04001635 RID: 5685
		PS4_CenterPad_Click,
		// Token: 0x04001636 RID: 5686
		PS4_CenterPad_DPadNorth,
		// Token: 0x04001637 RID: 5687
		PS4_CenterPad_DPadSouth,
		// Token: 0x04001638 RID: 5688
		PS4_CenterPad_DPadWest,
		// Token: 0x04001639 RID: 5689
		PS4_CenterPad_DPadEast,
		// Token: 0x0400163A RID: 5690
		PS4_LeftTrigger_Pull,
		// Token: 0x0400163B RID: 5691
		PS4_LeftTrigger_Click,
		// Token: 0x0400163C RID: 5692
		PS4_RightTrigger_Pull,
		// Token: 0x0400163D RID: 5693
		PS4_RightTrigger_Click,
		// Token: 0x0400163E RID: 5694
		PS4_LeftStick_Move,
		// Token: 0x0400163F RID: 5695
		PS4_LeftStick_Click,
		// Token: 0x04001640 RID: 5696
		PS4_LeftStick_DPadNorth,
		// Token: 0x04001641 RID: 5697
		PS4_LeftStick_DPadSouth,
		// Token: 0x04001642 RID: 5698
		PS4_LeftStick_DPadWest,
		// Token: 0x04001643 RID: 5699
		PS4_LeftStick_DPadEast,
		// Token: 0x04001644 RID: 5700
		PS4_RightStick_Move,
		// Token: 0x04001645 RID: 5701
		PS4_RightStick_Click,
		// Token: 0x04001646 RID: 5702
		PS4_RightStick_DPadNorth,
		// Token: 0x04001647 RID: 5703
		PS4_RightStick_DPadSouth,
		// Token: 0x04001648 RID: 5704
		PS4_RightStick_DPadWest,
		// Token: 0x04001649 RID: 5705
		PS4_RightStick_DPadEast,
		// Token: 0x0400164A RID: 5706
		PS4_DPad_North,
		// Token: 0x0400164B RID: 5707
		PS4_DPad_South,
		// Token: 0x0400164C RID: 5708
		PS4_DPad_West,
		// Token: 0x0400164D RID: 5709
		PS4_DPad_East,
		// Token: 0x0400164E RID: 5710
		PS4_Gyro_Move,
		// Token: 0x0400164F RID: 5711
		PS4_Gyro_Pitch,
		// Token: 0x04001650 RID: 5712
		PS4_Gyro_Yaw,
		// Token: 0x04001651 RID: 5713
		PS4_Gyro_Roll,
		// Token: 0x04001652 RID: 5714
		XBoxOne_A,
		// Token: 0x04001653 RID: 5715
		XBoxOne_B,
		// Token: 0x04001654 RID: 5716
		XBoxOne_X,
		// Token: 0x04001655 RID: 5717
		XBoxOne_Y,
		// Token: 0x04001656 RID: 5718
		XBoxOne_LeftBumper,
		// Token: 0x04001657 RID: 5719
		XBoxOne_RightBumper,
		// Token: 0x04001658 RID: 5720
		XBoxOne_Menu,
		// Token: 0x04001659 RID: 5721
		XBoxOne_View,
		// Token: 0x0400165A RID: 5722
		XBoxOne_LeftTrigger_Pull,
		// Token: 0x0400165B RID: 5723
		XBoxOne_LeftTrigger_Click,
		// Token: 0x0400165C RID: 5724
		XBoxOne_RightTrigger_Pull,
		// Token: 0x0400165D RID: 5725
		XBoxOne_RightTrigger_Click,
		// Token: 0x0400165E RID: 5726
		XBoxOne_LeftStick_Move,
		// Token: 0x0400165F RID: 5727
		XBoxOne_LeftStick_Click,
		// Token: 0x04001660 RID: 5728
		XBoxOne_LeftStick_DPadNorth,
		// Token: 0x04001661 RID: 5729
		XBoxOne_LeftStick_DPadSouth,
		// Token: 0x04001662 RID: 5730
		XBoxOne_LeftStick_DPadWest,
		// Token: 0x04001663 RID: 5731
		XBoxOne_LeftStick_DPadEast,
		// Token: 0x04001664 RID: 5732
		XBoxOne_RightStick_Move,
		// Token: 0x04001665 RID: 5733
		XBoxOne_RightStick_Click,
		// Token: 0x04001666 RID: 5734
		XBoxOne_RightStick_DPadNorth,
		// Token: 0x04001667 RID: 5735
		XBoxOne_RightStick_DPadSouth,
		// Token: 0x04001668 RID: 5736
		XBoxOne_RightStick_DPadWest,
		// Token: 0x04001669 RID: 5737
		XBoxOne_RightStick_DPadEast,
		// Token: 0x0400166A RID: 5738
		XBoxOne_DPad_North,
		// Token: 0x0400166B RID: 5739
		XBoxOne_DPad_South,
		// Token: 0x0400166C RID: 5740
		XBoxOne_DPad_West,
		// Token: 0x0400166D RID: 5741
		XBoxOne_DPad_East,
		// Token: 0x0400166E RID: 5742
		XBox360_A,
		// Token: 0x0400166F RID: 5743
		XBox360_B,
		// Token: 0x04001670 RID: 5744
		XBox360_X,
		// Token: 0x04001671 RID: 5745
		XBox360_Y,
		// Token: 0x04001672 RID: 5746
		XBox360_LeftBumper,
		// Token: 0x04001673 RID: 5747
		XBox360_RightBumper,
		// Token: 0x04001674 RID: 5748
		XBox360_Start,
		// Token: 0x04001675 RID: 5749
		XBox360_Back,
		// Token: 0x04001676 RID: 5750
		XBox360_LeftTrigger_Pull,
		// Token: 0x04001677 RID: 5751
		XBox360_LeftTrigger_Click,
		// Token: 0x04001678 RID: 5752
		XBox360_RightTrigger_Pull,
		// Token: 0x04001679 RID: 5753
		XBox360_RightTrigger_Click,
		// Token: 0x0400167A RID: 5754
		XBox360_LeftStick_Move,
		// Token: 0x0400167B RID: 5755
		XBox360_LeftStick_Click,
		// Token: 0x0400167C RID: 5756
		XBox360_LeftStick_DPadNorth,
		// Token: 0x0400167D RID: 5757
		XBox360_LeftStick_DPadSouth,
		// Token: 0x0400167E RID: 5758
		XBox360_LeftStick_DPadWest,
		// Token: 0x0400167F RID: 5759
		XBox360_LeftStick_DPadEast,
		// Token: 0x04001680 RID: 5760
		XBox360_RightStick_Move,
		// Token: 0x04001681 RID: 5761
		XBox360_RightStick_Click,
		// Token: 0x04001682 RID: 5762
		XBox360_RightStick_DPadNorth,
		// Token: 0x04001683 RID: 5763
		XBox360_RightStick_DPadSouth,
		// Token: 0x04001684 RID: 5764
		XBox360_RightStick_DPadWest,
		// Token: 0x04001685 RID: 5765
		XBox360_RightStick_DPadEast,
		// Token: 0x04001686 RID: 5766
		XBox360_DPad_North,
		// Token: 0x04001687 RID: 5767
		XBox360_DPad_South,
		// Token: 0x04001688 RID: 5768
		XBox360_DPad_West,
		// Token: 0x04001689 RID: 5769
		XBox360_DPad_East,
		// Token: 0x0400168A RID: 5770
		SteamV2_A,
		// Token: 0x0400168B RID: 5771
		SteamV2_B,
		// Token: 0x0400168C RID: 5772
		SteamV2_X,
		// Token: 0x0400168D RID: 5773
		SteamV2_Y,
		// Token: 0x0400168E RID: 5774
		SteamV2_LeftBumper,
		// Token: 0x0400168F RID: 5775
		SteamV2_RightBumper,
		// Token: 0x04001690 RID: 5776
		SteamV2_LeftGrip,
		// Token: 0x04001691 RID: 5777
		SteamV2_RightGrip,
		// Token: 0x04001692 RID: 5778
		SteamV2_LeftGrip_Upper,
		// Token: 0x04001693 RID: 5779
		SteamV2_RightGrip_Upper,
		// Token: 0x04001694 RID: 5780
		SteamV2_LeftBumper_Pressure,
		// Token: 0x04001695 RID: 5781
		SteamV2_RightBumper_Pressure,
		// Token: 0x04001696 RID: 5782
		SteamV2_LeftGrip_Pressure,
		// Token: 0x04001697 RID: 5783
		SteamV2_RightGrip_Pressure,
		// Token: 0x04001698 RID: 5784
		SteamV2_LeftGrip_Upper_Pressure,
		// Token: 0x04001699 RID: 5785
		SteamV2_RightGrip_Upper_Pressure,
		// Token: 0x0400169A RID: 5786
		SteamV2_Start,
		// Token: 0x0400169B RID: 5787
		SteamV2_Back,
		// Token: 0x0400169C RID: 5788
		SteamV2_LeftPad_Touch,
		// Token: 0x0400169D RID: 5789
		SteamV2_LeftPad_Swipe,
		// Token: 0x0400169E RID: 5790
		SteamV2_LeftPad_Click,
		// Token: 0x0400169F RID: 5791
		SteamV2_LeftPad_Pressure,
		// Token: 0x040016A0 RID: 5792
		SteamV2_LeftPad_DPadNorth,
		// Token: 0x040016A1 RID: 5793
		SteamV2_LeftPad_DPadSouth,
		// Token: 0x040016A2 RID: 5794
		SteamV2_LeftPad_DPadWest,
		// Token: 0x040016A3 RID: 5795
		SteamV2_LeftPad_DPadEast,
		// Token: 0x040016A4 RID: 5796
		SteamV2_RightPad_Touch,
		// Token: 0x040016A5 RID: 5797
		SteamV2_RightPad_Swipe,
		// Token: 0x040016A6 RID: 5798
		SteamV2_RightPad_Click,
		// Token: 0x040016A7 RID: 5799
		SteamV2_RightPad_Pressure,
		// Token: 0x040016A8 RID: 5800
		SteamV2_RightPad_DPadNorth,
		// Token: 0x040016A9 RID: 5801
		SteamV2_RightPad_DPadSouth,
		// Token: 0x040016AA RID: 5802
		SteamV2_RightPad_DPadWest,
		// Token: 0x040016AB RID: 5803
		SteamV2_RightPad_DPadEast,
		// Token: 0x040016AC RID: 5804
		SteamV2_LeftTrigger_Pull,
		// Token: 0x040016AD RID: 5805
		SteamV2_LeftTrigger_Click,
		// Token: 0x040016AE RID: 5806
		SteamV2_RightTrigger_Pull,
		// Token: 0x040016AF RID: 5807
		SteamV2_RightTrigger_Click,
		// Token: 0x040016B0 RID: 5808
		SteamV2_LeftStick_Move,
		// Token: 0x040016B1 RID: 5809
		SteamV2_LeftStick_Click,
		// Token: 0x040016B2 RID: 5810
		SteamV2_LeftStick_DPadNorth,
		// Token: 0x040016B3 RID: 5811
		SteamV2_LeftStick_DPadSouth,
		// Token: 0x040016B4 RID: 5812
		SteamV2_LeftStick_DPadWest,
		// Token: 0x040016B5 RID: 5813
		SteamV2_LeftStick_DPadEast,
		// Token: 0x040016B6 RID: 5814
		SteamV2_Gyro_Move,
		// Token: 0x040016B7 RID: 5815
		SteamV2_Gyro_Pitch,
		// Token: 0x040016B8 RID: 5816
		SteamV2_Gyro_Yaw,
		// Token: 0x040016B9 RID: 5817
		SteamV2_Gyro_Roll,
		// Token: 0x040016BA RID: 5818
		Count
	}
}
