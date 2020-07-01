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
	[Display("SetMode", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class SetMode : TestStep
	{
		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

		private string _ModeOfInstrument = "SA";

		[DisplayAttribute("ModeOfInstrument", "", "Input Parameters", 2)]
		public string ModeOfInstrument
		{
			get
			{
				return this._ModeOfInstrument;
			}
			set
			{
				this._ModeOfInstrument = value;
			}
		}

		private String[] AvailableMode;
		// ToDo: Add property here for each parameter the end user should be able to change
		#endregion

		public SetMode()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			AvailableMode = MyInst.ScpiQuery<System.String[]>(Scpi.Format(":INSTrument:CATalog?"), true);
			MyInst.ScpiCommand(":INSTrument:SELect {0}", ModeOfInstrument);
			MyInst.ScpiCommand("*OPC");
			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
