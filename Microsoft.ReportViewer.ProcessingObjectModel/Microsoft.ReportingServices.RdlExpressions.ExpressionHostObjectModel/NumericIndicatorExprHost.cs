using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel
{
	public abstract class NumericIndicatorExprHost : GaugePanelItemExprHost
	{
		public GaugeInputValueExprHost GaugeInputValueHost;

		[CLSCompliant(false)]
		protected IList<NumericIndicatorRangeExprHost> m_numericIndicatorRangesHostsRemotable;

		public GaugeInputValueExprHost MinimumValueHost;

		public GaugeInputValueExprHost MaximumValueHost;

		[CLSCompliant(false)]
		public IList<NumericIndicatorRangeExprHost> NumericIndicatorRangesHostsRemotable
		{
			[StrongNameIdentityPermission(SecurityAction.LinkDemand, PublicKey = "0024000004800000940000000602000000240000525341310004000001000100272736ad6e5f9586bac2d531eabc3acc666c2f8ec879fa94f8f7b0327d2ff2ed523448f83c3d5c5dd2dfc7bc99c5286b2c125117bf5cbe242b9d41750732b2bdffe649c6efb8e5526d526fdd130095ecdb7bf210809c6cdad8824faa9ac0310ac3cba2aa0523567b2dfa7fe250b30facbd62d4ec99b94ac47c7d3b28f1f6e4c8")]
			get
			{
				return m_numericIndicatorRangesHostsRemotable;
			}
		}

		public virtual object DecimalDigitColorExpr => null;

		public virtual object DigitColorExpr => null;

		public virtual object UseFontPercentExpr => null;

		public virtual object DecimalDigitsExpr => null;

		public virtual object DigitsExpr => null;

		public virtual object MultiplierExpr => null;

		public virtual object NonNumericStringExpr => null;

		public virtual object OutOfRangeStringExpr => null;

		public virtual object ResizeModeExpr => null;

		public virtual object ShowDecimalPointExpr => null;

		public virtual object ShowLeadingZerosExpr => null;

		public virtual object IndicatorStyleExpr => null;

		public virtual object ShowSignExpr => null;

		public virtual object SnappingEnabledExpr => null;

		public virtual object SnappingIntervalExpr => null;

		public virtual object LedDimColorExpr => null;

		public virtual object SeparatorWidthExpr => null;

		public virtual object SeparatorColorExpr => null;
	}
}
