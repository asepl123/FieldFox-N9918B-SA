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
	[Display("Memory", Group: "FieldFox.SA.N9918B", Description: "Insert a description here")]
	public class Memory : TestStep
	{
        #region Settings

        [Display("Instrument", Group: "FieldFox.NA.N9918B", Description: "Insert a description here")]
        public N9918B MyInst { get; set; }

        private string _CDirectory = "C:\\temp\\";

        [DisplayAttribute("CDirectory", "", "Input Parameters", 2)]
        public string CDirectory
        {
            get
            {
                return this._CDirectory;
            }
            set
            {
                this._CDirectory = value;
            }
        }

        private string _SourceFile = "source";

        [DisplayAttribute("SourceFile", "", "Input Parameters", 2)]
        public string SourceFile
        {
            get
            {
                return this._SourceFile;
            }
            set
            {
                this._SourceFile = value;
            }
        }

        private string _DestinationFile = "destination";

        [DisplayAttribute("DestinationFile", "", "Input Parameters", 2)]
        public string DestinationFile
        {
            get
            {
                return this._DestinationFile;
            }
            set
            {
                this._DestinationFile = value;
            }
        }

        private string _Delete = "file";

        [DisplayAttribute("Delete", "", "Input Parameters", 2)]
        public string Delete
        {
            get
            {
                return this._Delete;
            }
            set
            {
                this._Delete = value;
            }
        }

        private string _MDirectory = "[USBDISK]:\\MyFolder";

        [DisplayAttribute("MDirectory", "", "Input Parameters", 2)]
        public string MDirectory
        {
            get
            {
                return this._MDirectory;
            }
            set
            {
                this._MDirectory = value;
            }
        }

        private string _FromFile = "file1";

        [DisplayAttribute("FromFile", "", "Input Parameters", 2)]
        public string FromFile
        {
            get
            {
                return this._FromFile;
            }
            set
            {
                this._FromFile = value;
            }
        }

        private string _ToFile = "file2";

        [DisplayAttribute("ToFile", "", "Input Parameters", 2)]
        public string ToFile
        {
            get
            {
                return this._ToFile;
            }
            set
            {
                this._ToFile = value;
            }
        }

        private string _RDirectory = "C:\\temp\\";

        [DisplayAttribute("RDirectory", "", "Input Parameters", 2)]
        public string RDirectory
        {
            get
            {
                return this._RDirectory;
            }
            set
            {
                this._RDirectory = value;
            }
        }

        private string _RDirectoryRecursive = "recursive";

        [DisplayAttribute("RDirectoryRecursive", "", "Input Parameters", 2)]
        public string RDirectoryRecursive
        {
            get
            {
                return this._RDirectoryRecursive;
            }
            set
            {
                this._RDirectoryRecursive = value;
            }
        }

        #endregion

        public Memory()
		{
			// ToDo: Set default values for properties / settings.
		}

		public override void Run()
		{
			// ToDo: Add test case code.
			RunChildSteps(); //If the step supports child steps.

            MyInst.ScpiCommand(":MMEMory:CDIRectory {0}", CDirectory);
            MyInst.ScpiCommand(":MMEMory:COPY {0},{1}", SourceFile, DestinationFile);
            MyInst.ScpiCommand(":MMEMory:DELete {0}", Delete);
            MyInst.ScpiCommand(":MMEMory:MDIRectory {0}", MDirectory);
            MyInst.ScpiCommand(":MMEMory:MOVE {0},{1}", FromFile, ToFile);
            MyInst.ScpiCommand(":MMEMory:RDIRectory {0},{1}", RDirectory, RDirectoryRecursive);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
	}
}
