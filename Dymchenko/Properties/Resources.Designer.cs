﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dymchenko.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
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
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dymchenko.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
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
        ///   Ищет локализованную строку, похожую на Failed to choose folder. Reason: {0}.
        /// </summary>
        internal static string Main_FailedToChooseFolder {
            get {
                return ResourceManager.GetString("Main_FailedToChooseFolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failed to show history. Reason: {0}.
        /// </summary>
        internal static string Main_FailedToShowHistory {
            get {
                return ResourceManager.GetString("Main_FailedToShowHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failed to get user.{0}Reason: {1}.
        /// </summary>
        internal static string SignIn_FailedToGetUser {
            get {
                return ResourceManager.GetString("SignIn_FailedToGetUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failed to validate password.{0}Reason: {1}.
        /// </summary>
        internal static string SignIn_FailedToValidatePassword {
            get {
                return ResourceManager.GetString("SignIn_FailedToValidatePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with login {0} doesn&apos;t exist!.
        /// </summary>
        internal static string SignIn_UserDoesntExist {
            get {
                return ResourceManager.GetString("SignIn_UserDoesntExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Wrong password!.
        /// </summary>
        internal static string SignIn_WrongPassword {
            get {
                return ResourceManager.GetString("SignIn_WrongPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Email address {0} is not valid!.
        /// </summary>
        internal static string SignUp_EmailIsNotValid {
            get {
                return ResourceManager.GetString("SignUp_EmailIsNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failed to create user.{0}Reason: {1}.
        /// </summary>
        internal static string SignUp_FailedToCreateUser {
            get {
                return ResourceManager.GetString("SignUp_FailedToCreateUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failed to validate data.{0}Reason: {1}.
        /// </summary>
        internal static string SignUp_FailedToValidateData {
            get {
                return ResourceManager.GetString("SignUp_FailedToValidateData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with login {0} already exists!.
        /// </summary>
        internal static string SignUp_UserAlreadyExists {
            get {
                return ResourceManager.GetString("SignUp_UserAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User with login {0} doesn&apos;t exist!.
        /// </summary>
        internal static string SignUp_UserdoesntExist {
            get {
                return ResourceManager.GetString("SignUp_UserdoesntExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на User {0} successfully created!.
        /// </summary>
        internal static string SignUp_UserSuccessfulyCreated {
            get {
                return ResourceManager.GetString("SignUp_UserSuccessfulyCreated", resourceCulture);
            }
        }
    }
}
