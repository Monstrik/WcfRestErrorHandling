﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.ServiceModel.Web;
using System.Web;

namespace WcfFormatAutoSelect
{
    /// <summary>
    /// Enables the ExtendedWebHttpBehavior for an endpoint through configuration.
    /// Note: Since the ExtendedWebHttpBehavior is derived of the WebHttpBehavior we wanted to have the exact same configuration.  
    /// However during the coding we've relized that the WebHttpElement is sealed so we've grabbed its code using reflector and
    /// modified it to our needs.
    /// </summary>
    public sealed class ExtendedWebHttpElement : BehaviorExtensionElement
    {
        private ConfigurationPropertyCollection properties;
        /// <summary>Gets or sets a value that indicates whether help is enabled.</summary>
        /// <returns>true if help is enabled; otherwise, false. </returns>
        [ConfigurationProperty("helpEnabled")]
        public bool HelpEnabled
        {
            get
            {
                return (bool)base["helpEnabled"];
            }
            set
            {
                base["helpEnabled"] = value;
            }
        }
        /// <summary>Gets and sets the default message body style.</summary>
        /// <returns>One of the values defined in the <see cref="T:System.ServiceModel.Web.WebMessageBodyStyle" /> enumeration.</returns>
        [ConfigurationProperty("defaultBodyStyle")]
        public WebMessageBodyStyle DefaultBodyStyle
        {
            get
            {
                return (WebMessageBodyStyle)base["defaultBodyStyle"];
            }
            set
            {
                base["defaultBodyStyle"] = value;
            }
        }
        /// <summary>Gets and sets the default outgoing response format.</summary>
        /// <returns>One of the values defined in the <see cref="T:System.ServiceModel.Web.WebMessageFormat" /> enumeration.</returns>
        [ConfigurationProperty("defaultOutgoingResponseFormat")]
        public WebMessageFormat DefaultOutgoingResponseFormat
        {
            get
            {
                return (WebMessageFormat)base["defaultOutgoingResponseFormat"];
            }
            set
            {
                base["defaultOutgoingResponseFormat"] = value;
            }
        }
        /// <summary>Gets or sets a value that indicates whether the message format can be automatically selected.</summary>
        /// <returns>true if the message format can be automatically selected; otherwise, false. </returns>
        [ConfigurationProperty("automaticFormatSelectionEnabled")]
        public bool AutomaticFormatSelectionEnabled
        {
            get
            {
                return (bool)base["automaticFormatSelectionEnabled"];
            }
            set
            {
                base["automaticFormatSelectionEnabled"] = value;
            }
        }
        /// <summary>Gets or sets the flag that specifies whether a FaultException is generated when an internal server error (HTTP status code: 500) occurs.</summary>
        /// <returns>Returns true if the flag is enabled; otherwise returns false.</returns>
        [ConfigurationProperty("faultExceptionEnabled")]
        public bool FaultExceptionEnabled
        {
            get
            {
                return (bool)base["faultExceptionEnabled"];
            }
            set
            {
                base["faultExceptionEnabled"] = value;
            }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (this.properties == null)
                {
                    this.properties = new ConfigurationPropertyCollection
                {
                    new ConfigurationProperty("helpEnabled", typeof(bool), false, null, null, ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("defaultBodyStyle", typeof(WebMessageBodyStyle), WebMessageBodyStyle.Bare, null, null, ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("defaultOutgoingResponseFormat", typeof(WebMessageFormat), WebMessageFormat.Xml, null, null, ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("automaticFormatSelectionEnabled", typeof(bool), false, null, null, ConfigurationPropertyOptions.None),
                    new ConfigurationProperty("faultExceptionEnabled", typeof(bool), false, null, null, ConfigurationPropertyOptions.None)
                };
                }
                return this.properties;
            }
        }
        /// <summary>Gets the type of the behavior enabled by this configuration element.</summary>
        /// <returns>The <see cref="T:System.Type" /> for the behavior enabled with the configuration element: <see cref="T:System.ServiceModel.Description.WebHttpBehavior" />.</returns>
        public override Type BehaviorType
        {
            get
            {
                return typeof(ExtendedWebHttpBehavior);
            }
        }
        protected override object CreateBehavior()
        {
            return new ExtendedWebHttpBehavior
            {
                HelpEnabled = this.HelpEnabled,
                DefaultBodyStyle = this.DefaultBodyStyle,
                DefaultOutgoingResponseFormat = this.DefaultOutgoingResponseFormat,
                AutomaticFormatSelectionEnabled = this.AutomaticFormatSelectionEnabled,
                FaultExceptionEnabled = this.FaultExceptionEnabled
            };
        }
    }
}