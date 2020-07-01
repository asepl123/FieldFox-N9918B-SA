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
	[Display("Amplitude", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Amplitude : TestStep
	{
		#region enum
        public enum EUnits { DBM, DBMV, DBUV, DBMA, DBUA, W, V, A }
		#endregion enum

		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

        private string _Scale = "LOG";

        [DisplayAttribute("Scale", "Choose from: 1. LOG -units in dB; 2. LIN - units in mV", "Input Parameters", 2)]
        public string Scale
        {
            get
            {
                return this._Scale;
            }
            set
            {
                this._Scale = value;
            }
        }

        private EUnits _Units = EUnits.DBM;

        [DisplayAttribute("Units", "{ DBMV, DBUV, DBMA, DBUA, V, A }\r\nDBMV - dB milliVolts\r\nDBUV - dB microvolts\r\nDBM" +
            "A - dB milliAmps\r\nDBUA - dB microAmps\r\nV - volts\r\nA  - amps", "Input Parameters", 2)]
        public EUnits Units
        {
            get
            {
                return this._Units;
            }
            set
            {
                this._Units = value;
            }
        }

        #endregion

        public Amplitude()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:AMPLitude:SCALe {0}", Scale);
            MyInst.ScpiCommand(":SENSe:AMPLitude:UNIT {0}", Units);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
