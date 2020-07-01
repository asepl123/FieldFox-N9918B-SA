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
	[Display("Average", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Average : TestStep
	{
		#region enum
        public enum EAverageType { AUTO, POWer, LOG, VOLT }
		#endregion enum

		#region Settings

		[Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
		public N9918B MyInst { get; set; }

        private int _AverageCount = 100;

        [DisplayAttribute("AverageCount", "Set the number of sweep averages", "Input Parameters", 2)]
        public int AverageCount
        {
            get
            {
                return this._AverageCount;
            }
            set
            {
                this._AverageCount = value;
            }
        }

        private EAverageType _AverageType = EAverageType.AUTO;

        [DisplayAttribute("AverageType", "{ AUTO, POWer, LOG, VOLT } only for SA and IQA", "Input Parameters", 2)]
        public EAverageType AverageType
        {
            get
            {
                return this._AverageType;
            }
            set
            {
                this._AverageType = value;
            }
        }

        #endregion

        public Average()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

			MyInst.ScpiCommand(":SENSe:AVERage:COUNt {0}", AverageCount);
			MyInst.ScpiCommand(":SENSe:AVERage:TYPE {0}", AverageType);

			// If no verdict is used, the verdict will default to NotSet.
			// You can change the verdict using UpgradeVerdict() as shown below.
			// UpgradeVerdict(Verdict.Pass);
		}
	}
}
