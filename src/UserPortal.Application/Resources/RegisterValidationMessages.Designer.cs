﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserPortal.Application.Resources {
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
    public class RegisterValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RegisterValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UserPortal.Application.Resources.RegisterValidationMessages", typeof(RegisterValidationMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email can&apos;t be null.
        /// </summary>
        public static string EmailCantBeNull {
            get {
                return ResourceManager.GetString("EmailCantBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email address must be at least 3 characters long.
        /// </summary>
        public static string EmailMustBe3AndMoreChars {
            get {
                return ResourceManager.GetString("EmailMustBe3AndMoreChars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The e-mail address must be valid.
        /// </summary>
        public static string EmailMustBeValid {
            get {
                return ResourceManager.GetString("EmailMustBeValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Province not found.
        /// </summary>
        public static string ErrorProvinceNotFound {
            get {
                return ResourceManager.GetString("ErrorProvinceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user already exists.
        /// </summary>
        public static string ErrorUserExists {
            get {
                return ResourceManager.GetString("ErrorUserExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password and password confirmation must be the same.
        /// </summary>
        public static string PasswordAndPassw2MustBeSame {
            get {
                return ResourceManager.GetString("PasswordAndPassw2MustBeSame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password cannot be null or empty.
        /// </summary>
        public static string PasswordCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("PasswordCannotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must be at least 2 characters long.
        /// </summary>
        public static string PasswordMustBeAtLeast2Symbols {
            get {
                return ResourceManager.GetString("PasswordMustBeAtLeast2Symbols", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must contain at least 1 digit and 1 character.
        /// </summary>
        public static string PasswordMustBeAtLeastOneNumAndOneChar {
            get {
                return ResourceManager.GetString("PasswordMustBeAtLeastOneNumAndOneChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A province cannot be null or empty.
        /// </summary>
        public static string ProvinceCanNotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("ProvinceCanNotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must be willing to work.
        /// </summary>
        public static string YouMustBeAgreeToWork {
            get {
                return ResourceManager.GetString("YouMustBeAgreeToWork", resourceCulture);
            }
        }
    }
}