﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizGoApp.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("QuizGoApp.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Quiz Wizard.
        /// </summary>
        internal static string APPLICATION_NAME {
            get {
                return ResourceManager.GetString("APPLICATION_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 1. The quiz consists of 10 questions..
        /// </summary>
        internal static string INSTRUCTION_TEXT {
            get {
                return ResourceManager.GetString("INSTRUCTION_TEXT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 2. The quiz is divided as 2 subjective questions, 5 multiple choice questions and 3 multiple choice questions among which 1 correct answer is mandatory to pass..
        /// </summary>
        internal static string INSTRUCTION_TEXT1 {
            get {
                return ResourceManager.GetString("INSTRUCTION_TEXT1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select any option to continue.
        /// </summary>
        internal static string NO_OPTION_SELECTED_ERROR {
            get {
                return ResourceManager.GetString("NO_OPTION_SELECTED_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter User Name to enter the quiz.
        /// </summary>
        internal static string USERNAME_NOT_ENTERED_ERROR {
            get {
                return ResourceManager.GetString("USERNAME_NOT_ENTERED_ERROR", resourceCulture);
            }
        }
    }
}
