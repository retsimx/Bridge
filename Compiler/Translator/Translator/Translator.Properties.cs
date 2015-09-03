﻿using Bridge.Contract;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp;

namespace Bridge.Translator
{
    public partial class Translator
    {
        public IAssemblyInfo AssemblyInfo
        {
            get;
            set;
        }

        public AssemblyDefinition AssemblyDefinition
        {
            get;
            set;
        }

        public Action<string, string> Log
        {
            get;
            set;
        }

        public IValidator Validator
        {
            get;
            private set;
        }

        public string BridgeLocation
        {
            get;
            set;
        }

        public string Location
        {
            get;
            protected set;
        }

        public string AssemblyLocation
        {
            get;
            protected set;
        }

        public string BuildArguments { get; set; }

        private string msbuildVersion = "4.0.30319";

        public string MSBuildVersion
        {
            get
            {
                return this.msbuildVersion;
            }
            set
            {
                this.msbuildVersion = value;
            }
        }

        public IList<string> SourceFiles
        {
            get;
            protected set;
        }

        public IList<ParsedSourceFile> ParsedSourceFiles
        {
            get;
            protected set;
        }

        private bool rebuild = true;

        public bool Rebuild
        {
            get
            {
                return this.rebuild;
            }
            set
            {
                this.rebuild = value;
            }
        }

        protected Dictionary<string, TypeDefinition> TypeDefinitions
        {
            get;
            set;
        }

        public Dictionary<string, ITypeInfo> TypeInfoDefinitions
        {
            get;
            set;
        }

        public List<ITypeInfo> Types
        {
            get;
            protected set;
        }

        public Dictionary<string, string> Outputs
        {
            get;
            protected set;
        }

        public IPlugins Plugins
        {
            get;
            set;
        }

        public BridgeTypes BridgeTypes
        {
            get;
            set;
        }

        public AstNode EmitNode
        {
            get;
            set;
        }

        public bool FolderMode
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public bool Recursive
        {
            get;
            set;
        }

        public string Configuration
        {
            get;
            set;
        }

        public List<string> DefineConstants
        {
            get;
            set;
        }

        public bool FromTask
        {
            get;
            set;
        }
		
		public virtual IEnumerable<AssemblyDefinition> References
        {
            get;
            set;
        }
    }
}