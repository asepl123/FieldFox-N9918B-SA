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
	[Display("ACPower", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class ACPower : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private double _SetRefACPower = -1.5D;

        [DisplayAttribute("SetRefACPower", "", "Input Parameters", 2)]
        public double SetRefACPower
        {
            get
            {
                return this._SetRefACPower;
            }
            set
            {
                this._SetRefACPower = value;
            }
        }

        private bool _EnableLimitingACPower = true;

        [DisplayAttribute("EnableLimitingACPower", "", "Input Parameters", 2)]
        public bool EnableLimitingACPower
        {
            get
            {
                return this._EnableLimitingACPower;
            }
            set
            {
                this._EnableLimitingACPower = value;
            }
        }

        private uint _OffsetACPowern = 1u;

        [DisplayAttribute("OffsetACPower<n>", "", "Input Parameters", 2)]
        public uint OffsetACPowern
        {
            get
            {
                return this._OffsetACPowern;
            }
            set
            {
                this._OffsetACPowern = value;
            }
        }

        private double _OffsetBWACPower = 1000000D;

        [DisplayAttribute("OffsetBWACPower", "", "Input Parameters", 2)]
        public double OffsetBWACPower
        {
            get
            {
                return this._OffsetBWACPower;
            }
            set
            {
                this._OffsetBWACPower = value;
            }
        }

        private double _OffsetFreqACpower = 2000000D;

        [DisplayAttribute("OffsetFreqACpower", "", "Input Parameters", 2)]
        public double OffsetFreqACpower
        {
            get
            {
                return this._OffsetFreqACpower;
            }
            set
            {
                this._OffsetFreqACpower = value;
            }
        }

        private double _LowerLimit = -10D;

        [DisplayAttribute("LowerLimit", "", "Input Parameters", 2)]
        public double LowerLimit
        {
            get
            {
                return this._LowerLimit;
            }
            set
            {
                this._LowerLimit = value;
            }
        }

        private double _UpperLimit = 0D;

        [DisplayAttribute("UpperLimit", "", "Input Parameters", 2)]
        public double UpperLimit
        {
            get
            {
                return this._UpperLimit;
            }
            set
            {
                this._UpperLimit = value;
            }
        }

        #endregion

        public ACPower()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			// RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":SENSe:ACPower:MREFerence {0}", SetRefACPower);
            MyInst.ScpiCommand(":SENSe:ACPower:LIMit:STATe {0}", EnableLimitingACPower);
            MyInst.ScpiCommand(":SENSe:ACPower:OFFSet{0}:BWIDth {1}", OffsetACPowern, OffsetBWACPower);
            MyInst.ScpiCommand(":SENSe:ACPower:OFFSet{0}:FREQuency {1}", OffsetACPowern, OffsetFreqACpower);
            MyInst.ScpiCommand(":SENSe:ACPower:OFFSet{0}:LLIMit {1}", OffsetACPowern, LowerLimit);
            MyInst.ScpiCommand(":SENSe:ACPower:OFFSet{0}:ULIMit {1}", OffsetACPowern, UpperLimit);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
