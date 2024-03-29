﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clean.RGP.Core.PersonAggregate.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Clean.RGP.Core.PersonAggregate.Resources.ValidationMessages", typeof(ValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The cadastral number must consist of 11 digits..
        /// </summary>
        internal static string CadastralMarkValidationMessage {
            get {
                return ResourceManager.GetString("CadastralMarkValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Land properry must have at least one plot of land..
        /// </summary>
        internal static string LandPropertyPlotsNotEmptyValidationMessage {
            get {
                return ResourceManager.GetString("LandPropertyPlotsNotEmptyValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect status..
        /// </summary>
        internal static string LandPropertyStatusValidationMessage {
            get {
                return ResourceManager.GetString("LandPropertyStatusValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The area of ​​the land type must be greater than 0..
        /// </summary>
        internal static string LandTypeAreaValidationMessage {
            get {
                return ResourceManager.GetString("LandTypeAreaValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect land use type..
        /// </summary>
        internal static string LandTypeValidationMessage {
            get {
                return ResourceManager.GetString("LandTypeValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A person must own at least one land property..
        /// </summary>
        internal static string PersonLandPropertiesNotEmptyValidationMessage {
            get {
                return ResourceManager.GetString("PersonLandPropertiesNotEmptyValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect person type..
        /// </summary>
        internal static string PersonTypeValidationMessage {
            get {
                return ResourceManager.GetString("PersonTypeValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The total area of ​​the land plot must be greater than the sum of the land use areas..
        /// </summary>
        internal static string PlotLandTypesAreaSumValidationMessage {
            get {
                return ResourceManager.GetString("PlotLandTypesAreaSumValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uzmērīšanas datums nevar būt nākotnē..
        /// </summary>
        internal static string PlotSurveyDateInPastValidationMessage {
            get {
                return ResourceManager.GetString("PlotSurveyDateInPastValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The survey date must be valid..
        /// </summary>
        internal static string PlotSurveyDateValidationMessage {
            get {
                return ResourceManager.GetString("PlotSurveyDateValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The total area of ​​the plot must be greater than 0..
        /// </summary>
        internal static string PlotTotalAreaBiggerThanZerroValidationMessage {
            get {
                return ResourceManager.GetString("PlotTotalAreaBiggerThanZerroValidationMessage", resourceCulture);
            }
        }
    }
}
