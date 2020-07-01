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
	[Display("BW", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class BW : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private string _IF = "OFF";

        [DisplayAttribute("IF", "{ OFF, NARRow, WIDE }", "Input Parameters", 2)]
        public string IF
        {
            get
            {
                return this._IF;
            }
            set
            {
                this._IF = value;
            }
        }

        private double _Resolution = 10000D;

        [DisplayAttribute("Resolution", "", "Input Parameters", 2)]
        public double Resolution
        {
            get
            {
                return this._Resolution;
            }
            set
            {
                this._Resolution = value;
            }
        }

        private double _VBW = 1000D;

        [DisplayAttribute("VBW", "", "Input Parameters", 2)]
        public double VBW
        {
            get
            {
                return this._VBW;
            }
            set
            {
                this._VBW = value;
            }
        }
        #endregion

        public BW()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
        {
            MyInst.ScpiCommand(":SENSe:BANDwidth:IF:OUT {0}", IF);
            MyInst.ScpiCommand(":SENSe:BANDwidth:RESolution {0}", Resolution);
            MyInst.ScpiCommand(":SENSe:BANDwidth:VIDeo {0}", VBW);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
