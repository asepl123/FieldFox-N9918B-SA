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
	[Display("Power", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Power : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private bool _PowerAttenAuto = false;

        [DisplayAttribute("PowerAttenAuto", "", "Input Parameters", 2.1)]
        public bool PowerAttenAuto
        {
            get
            {
                return this._PowerAttenAuto;
            }
            set
            {
                this._PowerAttenAuto = value;
            }
        }

        private double _PowerAtten = 30D;

        [DisplayAttribute("PowerAtten", "", "Input Parameters", 2.2)]
        [EnabledIf("PowerAttenAuto", false, HideIfDisabled = true)]
        public double PowerAtten
        {
            get
            {
                return this._PowerAtten;
            }
            set
            {
                this._PowerAtten = value;
            }
        }

        private double _ExtGain = 0D;

        [DisplayAttribute("ExtGain", "Min : -100 dB\r\nMax : 100 dB", "Input Parameters", 2.3)]
        [EnabledIf("PowerAttenAuto", false, HideIfDisabled = true)]
        public double ExtGain
        {
            get
            {
                return this._ExtGain;
            }
            set
            {
                this._ExtGain = value;
            }
        }

		#endregion

		public Power()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            if (PowerAttenAuto == true)
			{
                MyInst.ScpiCommand(":SENSe:POWer:RF:ATTenuation:AUTO ON");
            }
			else
			{
                MyInst.ScpiCommand(":SENSe:POWer:RF:ATTenuation:AUTO OFF");
                MyInst.ScpiCommand(":SENSe:POWer:RF:ATTenuation {0}", PowerAtten);
                MyInst.ScpiCommand(":SENSe:POWer:RF:EXTGain {0}", ExtGain);
            }
            
        }
	}
}
