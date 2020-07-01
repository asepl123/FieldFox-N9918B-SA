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
	[Display("AMDemod", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class AMDemod : TestStep
	{
		#region enum
		public enum EDtype { AM, FMN, FMW }
		#endregion enum

		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private EDtype _Dtype = EDtype.AM;

        [DisplayAttribute("Dtype", "Select the type of metrics  { AM, FMN, FMW }", "Input Parameters", 2)]
        public EDtype Dtype
        {
            get
            {
                return this._Dtype;
            }
            set
            {
                this._Dtype = value;
            }
        }

        private double _AmYTop = 100D;

        [DisplayAttribute("AmYTop", "Sets the AM window Y axis top percentage value (10-100%).", "Input Parameters", 2)]
        public double AmYTop
        {
            get
            {
                return this._AmYTop;
            }
            set
            {
                this._AmYTop = value;
            }
        }

        private double _FmYTop = 100D;

        [DisplayAttribute("FmYTop", "Set the FM window Y axis top percentage value (10-100%)", "Input Parameters", 2)]
        public double FmYTop
        {
            get
            {
                return this._FmYTop;
            }
            set
            {
                this._FmYTop = value;
            }
        }

        private bool _AudioOnOff = false;

        [DisplayAttribute("AudioOnOff", "Enable or disable the audio while AM/FM metrics are on.", "Input Parameters", 2)]
        public bool AudioOnOff
        {
            get
            {
                return this._AudioOnOff;
            }
            set
            {
                this._AudioOnOff = value;
            }
        }

        private double _ListenTime = 100D;

        [DisplayAttribute("ListenTime", "Sets the listen time (100 ms to 100 s)", "Input Parameters", 2)]
        public double ListenTime
        {
            get
            {
                return this._ListenTime;
            }
            set
            {
                this._ListenTime = value;
            }
        }

        private bool _EnableModeDepth = false;

        [DisplayAttribute("EnableModeDepth", "", "Input Parameters", 2)]
        public bool EnableModeDepth
        {
            get
            {
                return this._EnableModeDepth;
            }
            set
            {
                this._EnableModeDepth = value;
            }
        }

        private double _TimeSpan = 0.002D;

        [DisplayAttribute("TimeSpan", "Sets the time span of the modulation window. (50us to 50ms)", "Input Parameters", 2)]
        public double TimeSpan
        {
            get
            {
                return this._TimeSpan;
            }
            set
            {
                this._TimeSpan = value;
            }
        }

        private double _TuneFrequency = 6000000D;

        [DisplayAttribute("TuneFrequency", " Sets the tune frequency ", "Input Parameters", 2)]
        public double TuneFrequency
        {
            get
            {
                return this._TuneFrequency;
            }
            set
            {
                this._TuneFrequency = value;
            }
        }

        #endregion

        public AMDemod()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
            // ToDo: Add test case code.
            // RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:DTYPe {0}", Dtype);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:AMTY {0}", AmYTop);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:FMTY {0}", FmYTop);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:LON {0}", AudioOnOff);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:LTIMe {0}", ListenTime);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:MMENable {0}", EnableModeDepth);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:STIMe {0}", TimeSpan);
            MyInst.ScpiCommand(":SENSe:ADEMod:METRics:TFReq {0}", TuneFrequency);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
