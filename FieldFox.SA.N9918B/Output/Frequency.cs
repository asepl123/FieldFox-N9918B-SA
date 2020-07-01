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
	[Display("Frequency", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Frequency : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private double _CenterFreq = 10000000D;

        [DisplayAttribute("CenterFreq", "", "Input Parameters", 2)]
        public double CenterFreq
        {
            get
            {
                return this._CenterFreq;
            }
            set
            {
                this._CenterFreq = value;
            }
        }

        private double _FreqSpan = 10000000D;

        [DisplayAttribute("FreqSpan", "", "Input Parameters", 2)]
        public double FreqSpan
        {
            get
            {
                return this._FreqSpan;
            }
            set
            {
                this._FreqSpan = value;
            }
        }

        private double _StartFreq = 10000D;

        [DisplayAttribute("StartFreq", "", "Input Parameters", 2)]
        public double StartFreq
        {
            get
            {
                return this._StartFreq;
            }
            set
            {
                this._StartFreq = value;
            }
        }

        private double _StopFreq = 10000000000D;

        [DisplayAttribute("StopFreq", "", "Input Parameters", 2)]
        public double StopFreq
        {
            get
            {
                return this._StopFreq;
            }
            set
            {
                this._StopFreq = value;
            }
        }

        #endregion

        public Frequency()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
            // ToDo: Add test case code.
            // RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:FREQuency:CENTer {0}", CenterFreq);
            MyInst.ScpiCommand(":SENSe:FREQuency:SPAN {0}", FreqSpan);
            MyInst.ScpiCommand(":SENSe:FREQuency:STARt {0}", StartFreq);
            MyInst.ScpiCommand(":SENSe:FREQuency:STOP {0}", StopFreq);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
