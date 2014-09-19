﻿// ---------------------------------------------------------------------------
// <copyright file="ApprovalRequestData.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the ApprovalRequestData class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;

    /// <summary>
    /// Represents approval request information.
    /// </summary>
    public sealed class ApprovalRequestData : ComplexProperty
    {
        private bool isUndecidedApprovalRequest;
        private int approvalDecision;
        private string approvalDecisionMaker;
        private DateTime approvalDecisionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalRequestData"/> class.
        /// </summary>
        internal ApprovalRequestData()
        {
        }

        /// <summary>
        /// Tries to read element from XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>True if element was read.</returns>
        internal override bool TryReadElementFromXml(EwsServiceXmlReader reader)
        {
            switch (reader.LocalName)
            {
                case XmlElementNames.IsUndecidedApprovalRequest:
                    this.isUndecidedApprovalRequest = reader.ReadElementValue<bool>();
                    return true;
                case XmlElementNames.ApprovalDecision:
                    this.approvalDecision = reader.ReadElementValue<int>();
                    return true;
                case XmlElementNames.ApprovalDecisionMaker:
                    this.approvalDecisionMaker = reader.ReadElementValue<string>();
                    return true;
                case XmlElementNames.ApprovalDecisionTime:
                    this.approvalDecisionTime = reader.ReadElementValueAsDateTime().Value;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Loads from json.
        /// </summary>
        /// <param name="jsonProperty">The json property.</param>
        /// <param name="service">The service.</param>
        internal override void LoadFromJson(JsonObject jsonProperty, ExchangeService service)
        {
            foreach (string key in jsonProperty.Keys)
            {
                switch (key)
                {
                    case XmlElementNames.IsUndecidedApprovalRequest:
                        this.isUndecidedApprovalRequest = jsonProperty.ReadAsBool(key);
                        break;
                    case XmlElementNames.ApprovalDecision:
                        this.approvalDecision = jsonProperty.ReadAsInt(key);
                        break;
                    case XmlElementNames.ApprovalDecisionMaker:
                        this.approvalDecisionMaker = jsonProperty.ReadAsString(key);
                        break;
                    case XmlElementNames.ApprovalDecisionTime:
                        this.approvalDecisionTime = service.ConvertUniversalDateTimeStringToLocalDateTime(jsonProperty.ReadAsString(key)).Value;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is an undecided approval request.
        /// </summary>
        public bool IsUndecidedApprovalRequest
        {
            get { return this.isUndecidedApprovalRequest; }
        }

        /// <summary>
        /// Gets the approval decision on the request.
        /// </summary>
        public int ApprovalDecision 
        {
            get { return this.approvalDecision; }
        }

        /// <summary>
        /// Gets the name of the user who made the decision.
        /// </summary>
        public string ApprovalDecisionMaker
        {
            get { return this.approvalDecisionMaker; }
        }

        /// <summary>
        /// Gets the time at which the decision was made.
        /// </summary>
        public DateTime ApprovalDecisionTime
        {
            get { return this.approvalDecisionTime; }
        }
    }
}