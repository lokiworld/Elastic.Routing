﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elastic.Routing.Parsing
{
    /// <summary>
    /// Represents the parameter path segment which can match a URL part also with '/' character.
    /// </summary>
    public class WildcardPathSegment : ParameterPathSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WildcardPathSegment"/> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="customPattern">The custom regex pattern.</param>
        public WildcardPathSegment(string name, string customPattern = null)
            : base(name, customPattern)
        {
        }

        /// <summary>
        /// Gets the default regex pattern if the custom one has not been passed.
        /// </summary>
        /// <returns>
        /// Returns the pattern which matches 1 or more characters.
        /// </returns>
        protected override string GetDefaultRegexPattern()
        {
            return ".+";
        }

        /// <summary>
        /// Gets the URL part for this segment. Used in URLs construction.
        /// </summary>
        /// <param name="valueGetter">The route value getter delegate.</param>
        /// <returns>
        /// Returns the corresponding part of the URL or <c>null</c> when the value is missing.
        /// </returns>
        public override SegmentValue GetUrlPart(Func<string, SegmentValue> valueGetter)
        {
            var value = valueGetter(Name);
            return MatchesPattern((string)value) ? value : null;
        }
    }
}
