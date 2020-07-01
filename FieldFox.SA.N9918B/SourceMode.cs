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
	[Display("SourceMode", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class SourceMode : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private bool _EnableSource = true;

        [DisplayAttribute("EnableSource", "", "Input Parameters", 2)]
        public bool EnableSource
        {
            get
            {
                return this._EnableSource;
            }
            set
            {
                this._EnableSource = value;
            }
        }

        private string _SoueceMode = "CW";

        [DisplayAttribute("SoueceMode", "{ CW, TCW, SRTS }", "Input Parameters", 2)]
        public string SoueceMode
        {
            get
            {
                return this._SoueceMode;
            }
            set
            {
                this._SoueceMode = value;
            }
        }

        private double _CWFreq = 1000000D;

        [DisplayAttribute("CWFreq", "", "Input Parameters", 2)]
        public double CWFreq
        {
            get
            {
                return this._CWFreq;
            }
            set
            {
                this._CWFreq = value;
            }
        }

        private bool _Normalize = false;

        [DisplayAttribute("Normalize", "", "Input Parameters", 2)]
        public bool Normalize
        {
            get
            {
                return this._Normalize;
            }
            set
            {
                this._Normalize = value;
            }
        }

        private double _Power = -15D;

        [DisplayAttribute("Power", "", "Input Parameters", 2)]
        public double Power
        {
            get
            {
                return this._Power;
            }
            set
            {
                this._Power = value;
            }
        }

        #endregion

        public SourceMode()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.


            MyInst.ScpiCommand(":SOURce:MODE {0}", SoueceMode);
            // CW
            MyInst.ScpiCommand(":SOURce:FREQuency:CW {0}", CWFreq);
            MyInst.ScpiCommand(":SOURce:ENABle {0}", EnableSource);
            MyInst.ScpiCommand(":SOURce:NORMalize {0}", Normalize);
            MyInst.ScpiCommand(":SOURce:POWer {0}", Power);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
