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
	[Display("Load", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Load : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private string _LoadAntenna = "MyAntenna";

        [DisplayAttribute("LoadAntenna", "", "Input Parameters", 2)]
        public string LoadAntenna
        {
            get
            {
                return this._LoadAntenna;
            }
            set
            {
                this._LoadAntenna = value;
            }
        }

        private string _LoadMode = "INTernal";

        [DisplayAttribute("LoadMode", "{ INTernal, USB, SD }", "Input Parameters", 2)]
        public string LoadMode
        {
            get
            {
                return this._LoadMode;
            }
            set
            {
                this._LoadMode = value;
            }
        }

        private string _LoadCable = "MyCable";

        [DisplayAttribute("LoadCable", "", "Input Parameters", 2)]
        public string LoadCable
        {
            get
            {
                return this._LoadCable;
            }
            set
            {
                this._LoadCable = value;
            }
        }

        private string _LoadSourceAntenna = "MyAntenna.ant";

        [DisplayAttribute("LoadSourceAntenna", "", "Input Parameters", 2)]
        public string LoadSourceAntenna
        {
            get
            {
                return this._LoadSourceAntenna;
            }
            set
            {
                this._LoadSourceAntenna = value;
            }
        }

        private string _LoadSourceCable = "MyCable.csv";

        [DisplayAttribute("LoadSourceCable", "", "Input Parameters", 2)]
        public string LoadSourceCable
        {
            get
            {
                return this._LoadSourceCable;
            }
            set
            {
                this._LoadSourceCable = value;
            }
        }

        private string _LoadState = "MyState.sta";

        [DisplayAttribute("LoadState", "", "Input Parameters", 2)]
        public string LoadState
        {
            get
            {
                return this._LoadState;
            }
            set
            {
                this._LoadState = value;
            }
        }


        #endregion

        public Load()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":MMEMory:LOAD:ANTenna {0},{1}", LoadAntenna, LoadMode);
            MyInst.ScpiCommand(":MMEMory:LOAD:CABLe {0},{1}", LoadCable, LoadMode);
            MyInst.ScpiCommand(":MMEMory:LOAD:SANTenna {0},{1}", LoadSourceAntenna, LoadMode);
            MyInst.ScpiCommand(":MMEMory:LOAD:SCABle {0},{1}", LoadSourceCable, LoadMode);
            MyInst.ScpiCommand(":MMEMory:LOAD:STATe {0}", LoadState);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
