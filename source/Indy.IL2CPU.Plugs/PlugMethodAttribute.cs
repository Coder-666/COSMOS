﻿using System;

namespace Indy.IL2CPU.Plugs {
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public sealed class PlugMethodAttribute: Attribute {
		public string Signature = null;
		public bool Enabled = true;
		public bool InMetalMode = true;
		public bool InNormalMode = true;
		public Type MethodAssembler = null;

		public const string SignaturePropertyName = "Signature";
		public const string EnabledPropertyName = "Enabled";
		public const string InMetalModePropertyName = "InMetalMode";
		public const string InNormalModePropertyName = "InNormalMode";
		public const string MethodAssemblerPropertyName = "MethodAssembler";
	}
}