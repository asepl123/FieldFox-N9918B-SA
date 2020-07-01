// Author: MyName
// Copyright:   Copyright 2020 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace FieldFox.SA.N9918B
{
	[Display("Burst", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Burst : TestStep
	{
		#region enum
		public enum EBurstAlignmentState { AUTO, HOLD, OFF }
		#endregion enum

		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

		private EBurstAlignmentState _BurstAlignmentState = EBurstAlignmentState.AUTO;

		[DisplayAttribute("BurstAlignmentState", "{ AUTO, HOLD, OFF }", "Input Parameters", 2)]
		public EBurstAlignmentState BurstAlignmentState
		{
			get
			{
				return this._BurstAlignmentState;
			}
			set
			{
				this._BurstAlignmentState = value;
			}
		}

		#endregion

		public Burst()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			MyInst.ScpiCommand(":SENSe:ALIGnment:BURSt:STATe {0}", BurstAlignmentState);

			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
