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
	[Display("Store", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Store : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private string _AntennaName = "MyAntenna_1";

        [DisplayAttribute("AntennaName", "", "Input Parameters", 2)]
        public string AntennaName
        {
            get
            {
                return this._AntennaName;
            }
            set
            {
                this._AntennaName = value;
            }
        }

        private string _AntennaLocation = "USB";

        [DisplayAttribute("AntennaLocation", "{ INTernal, USB, SD }", "Input Parameters", 2)]
        public string AntennaLocation
        {
            get
            {
                return this._AntennaLocation;
            }
            set
            {
                this._AntennaLocation = value;
            }
        }

        private string _CableName = "MyCable_1";

        [DisplayAttribute("CableName", "", "Input Parameters", 2)]
        public string CableName
        {
            get
            {
                return this._CableName;
            }
            set
            {
                this._CableName = value;
            }
        }

        private string _CableLocation = "USB";

        [DisplayAttribute("CableLocation", "", "Input Parameters", 2)]
        public string CableLocation
        {
            get
            {
                return this._CableLocation;
            }
            set
            {
                this._CableLocation = value;
            }
        }

        private string _DataFile = "MyFile.csv";

        [DisplayAttribute("DataFile", "", "Input Parameters", 2)]
        public string DataFile
        {
            get
            {
                return this._DataFile;
            }
            set
            {
                this._DataFile = value;
            }
        }

        private string _ScreenImage = "MyPic.png";

        [DisplayAttribute("ScreenImage", "", "Input Parameters", 2)]
        public string ScreenImage
        {
            get
            {
                return this._ScreenImage;
            }
            set
            {
                this._ScreenImage = value;
            }
        }
        #endregion

        public Store()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.


            MyInst.ScpiCommand(":MMEMory:STORe:ANTenna {0},{1}", AntennaName, AntennaLocation);
            MyInst.ScpiCommand(":MMEMory:STORe:CABLe {0},{1}", CableName, CableLocation);
            MyInst.ScpiCommand(":MMEMory:STORe:FDATa {0}", DataFile);
            MyInst.ScpiCommand(":MMEMory:STORe:IMAGe {0}", ScreenImage);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
