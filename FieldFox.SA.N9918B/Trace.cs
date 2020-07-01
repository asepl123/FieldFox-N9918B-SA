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
	[Display("Trace", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Trace : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private uint _TraceNo = 1u;

        [DisplayAttribute("TraceNo", "", "Input Parameters", 2)]
        public uint TraceNo
        {
            get
            {
                return this._TraceNo;
            }
            set
            {
                this._TraceNo = value;
            }
        }

        private string _TraceType = "CLRW";

        [DisplayAttribute("TraceType", "CLRW - Clear/Write\r\nBLANk - Blank\r\nMAXH - Max Hold\r\nMINH - Min Hold\r\nAVG - Averag" +
            "e (this parameter only applies to trace averaging.)\r\nVIEW - View", "Input Parameters", 2)]
        public string TraceType
        {
            get
            {
                return this._TraceType;
            }
            set
            {
                this._TraceType = value;
            }
        }

        // Returns the current data trace values
        private Double[] OutputTraceValue;

        #endregion

        public Trace()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			// RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":TRACe{0}:TYPE {1}", TraceNo, TraceType);
            MyInst.ScpiCommand(":FORMat:DATA ASC,0");
            OutputTraceValue = MyInst.ScpiQuery<System.Double[]>(Scpi.Format(":TRACe{0}:DATA?", TraceNo), true);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
